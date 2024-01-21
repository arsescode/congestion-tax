using congestion_tax_calculator_net_core.Data.Dto;
using congestion_tax_calculator_net_core.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Contract.ApplicationService
{
    public interface ICongestionService : IApplicationService
    {
        Task<ApiResult<CongestionTaxDto?>> CheckVehicleEntrance(CheckVehicleEntranceDto dto);
        Task<ApiResult<List<CongestionTaxDto>>> GetCongestionTaxes(GetCongestionsDto dto);
    }
}
