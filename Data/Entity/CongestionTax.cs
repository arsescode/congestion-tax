using System;

namespace congestion_tax_calculator_net_core.Data.Entity
{
    public class CongestionTax : BaseEntity
    {

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Time { get; set; }

        public int Amount { get; set; }
    }
}
