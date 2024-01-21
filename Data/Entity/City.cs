
using System.Collections.Generic;

namespace congestion_tax_calculator_net_core.Data.Entity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int MaxTax { get; set; }
        public virtual ICollection<CongestionTaxRule> CongestionTaxRules { get;set;}
        

    }
}