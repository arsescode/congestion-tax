using congestion_tax_calculator_net_core.Data.Enum;
using System;

namespace congestion_tax_calculator_net_core.Data.Entity
{
    public class CongestionTaxRule : BaseEntity
    {

        public Guid CityId { get; set; }
        public City City { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Amount { get; set; }
        public RuleTypes Type { get; set; }


        public bool IsIncluded(DateTime dateTime)
        {
            return dateTime.TimeOfDay >= From.TimeOfDay && dateTime.TimeOfDay <= To.TimeOfDay;
        }
    }
}
