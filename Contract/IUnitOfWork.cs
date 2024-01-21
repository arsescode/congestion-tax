using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Contract
{
    public interface IUnitOfWork
    {

        IVehicleRepository Vehicle { get; set; }
        ICongestionTaxRepository CongestionTax { get; set; }
        ICityRepository City { get; set; }
        ICongestionTaxRuleRepository CongestionTaxRule { get; set; }
        
        Task Complete();
    }
}
