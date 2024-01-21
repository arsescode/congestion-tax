using congestion_tax_calculator_net_core.Data.Entity;
using congestion_tax_calculator_net_core.Data.Enum;
using System;

namespace congestion_tax_calculator_net_core.Data.Dto
{
    public class GetCongestionsDto : PaginationDto
    {

        public Guid? VehicleId { get; set; }
    }

    public class CongestionTaxDto
    {

        public Guid Id { get; set; }
        public VehicleDto Vehicle { get; set; }

        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        public static implicit operator CongestionTaxDto(CongestionTax c)
        {
            return c == null ? null : new CongestionTaxDto
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                Amount = c.Amount,
                Vehicle = c.Vehicle,
            };

        }

    }
    public class CheckVehicleEntranceDto
    {

        public string NumberPlates { get; set; }
        public VehicleTypes Type { get; set; }
        public Guid CityId { get; set; }
    }
}
