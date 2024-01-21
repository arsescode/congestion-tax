using System;

namespace congestion_tax_calculator_net_core.Data.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
