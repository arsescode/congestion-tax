using congestion_tax_calculator_net_core.Contract.ApplicationService;
using congestion_tax_calculator_net_core.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Controllers
{

    public class CongestionController : SimpleController
    {

        private readonly ICongestionService _congestionService;

        public CongestionController(ICongestionService congestionService)
        {
            _congestionService = congestionService;
        }

        [HttpGet]
        public Task<ApiResult<List<CongestionTaxDto>>> GetCongestionTaxes([FromQuery] GetCongestionsDto dto)
        {
            return _congestionService.GetCongestionTaxes(dto);
        }

        [HttpPost]
        public Task<ApiResult<CongestionTaxDto?>> CheckVehicleEntrance([FromBody] CheckVehicleEntranceDto dto)
        {
            return _congestionService.CheckVehicleEntrance(dto);
        }
    }
}
