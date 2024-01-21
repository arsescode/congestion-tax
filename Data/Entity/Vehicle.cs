using congestion_tax_calculator_net_core.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Data.Entity
{
    public class Vehicle : BaseEntity
    {
        public string NumberPlates { get; set; }
        public VehicleTypes Type { get; set; }
        public virtual ICollection<CongestionTax> CongestionTaxes {get;set;} = new List<CongestionTax>();
        

    }
}