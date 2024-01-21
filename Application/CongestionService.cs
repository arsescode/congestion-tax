
using congestion_tax_calculator_net_core.Contract;
using congestion_tax_calculator_net_core.Contract.ApplicationService;
using congestion_tax_calculator_net_core.Data.Constants;
using congestion_tax_calculator_net_core.Data.Dto;
using congestion_tax_calculator_net_core.Data.Entity;
using congestion_tax_calculator_net_core.Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.ApplicationService
{
    public class CongestionService : ICongestionService
    {
        private readonly IUnitOfWork _unit;

        public CongestionService(IUnitOfWork unit)
        {
            this._unit = unit;
        }


        public async Task<ApiResult<CongestionTaxDto?>> CheckVehicleEntrance(CheckVehicleEntranceDto dto)
        {
            ApiResult<CongestionTaxDto?> result = new ApiResult<CongestionTaxDto> { Message = Messages.OK, };

            City city = await _unit.City.Query().Include(x => x.CongestionTaxRules).FirstOrDefaultAsync(x => x.Id == dto.CityId);


            if (CheckFreeTime(city))
            {
                return result.Error(Messages.FreeTime);
            }

            Vehicle vehicle = await GetVehicle(dto);

            if (CheckExempt(vehicle.Type))
            {
                return result.Error(Messages.ExemptVehicle);
            }


            if (GetVehicleRemainingTax(vehicle, city) <= 0)
            {
                return result.Error(Messages.MaxTax);
            }


            int taxAmount = CalculateTaxAmount(vehicle , city);

            var addRes = await _unit.CongestionTax.Add(new CongestionTax()
            {
                CreatedAt = DateTime.Now,
                Time = DateTime.Now,
                VehicleId = vehicle.Id,
                Amount = CalculateTaxAmount(vehicle, city),
            });
            

            await _unit.Complete();
            result.Data = addRes.Entity;
            return result;
        }

        private bool CheckFreeTime(City city)
        {
            DateTime now = DateTime.Now;
            return city.CongestionTaxRules.Any(x => x.IsIncluded(now) && x.Type == RuleTypes.FreeTime);
        }

        private int CalculateTaxAmount(Vehicle vehicle, City city)
        {
            DateTime now = DateTime.Now;
            CongestionTaxRule? rule = city.CongestionTaxRules.FirstOrDefault(x => x.IsIncluded(now) && x.Type == RuleTypes.TaxTime);
            if (rule == null)
            {
                return 0;
            }

            int taxAmount = rule.Amount;
            int remainingTaxAmount = GetVehicleRemainingTax(vehicle, city);

            if (taxAmount > remainingTaxAmount)
            {
                taxAmount = remainingTaxAmount;
            }

            return taxAmount;
        }
        private async Task<Vehicle> GetVehicle(CheckVehicleEntranceDto dto)
        {
            Vehicle? vehicle = await _unit.Vehicle.Query().Include(x => x.CongestionTaxes)
                .FirstOrDefaultAsync(x => x.NumberPlates == dto.NumberPlates);
            if (vehicle == null)
            {

                
                var addRes =  await _unit.Vehicle.Add(new Vehicle
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    NumberPlates = dto.NumberPlates,
                    Type = dto.Type,
                });
                vehicle = addRes.Entity;
            }
            return vehicle;
        }
        private bool CheckExempt(VehicleTypes type)
        {
            return type != VehicleTypes.Car;
        }
        private int GetVehicleRemainingTax(Vehicle vehicle , City city)
        {
            DateTime startDay = DateTime.Today;
            DateTime endDay = DateTime.Today.AddDays(1);
            return city.MaxTax - vehicle.CongestionTaxes.Where(x => x.Time >= startDay && x.Time < endDay).Sum(x => x.Amount);
            
        }

        public async Task<ApiResult<List<CongestionTaxDto>>> GetCongestionTaxes(GetCongestionsDto dto)
        {
            return new ApiResult<List<CongestionTaxDto>>
            {
                Status = true,
                Data = await _unit.CongestionTax.Query()
                .Where(x => dto.VehicleId == null || dto.VehicleId == x.VehicleId)
                .Select(x => (CongestionTaxDto)x).ToListAsync()
            };
        }
    }
}
