using congestion_tax_calculator_net_core.Data.Entity;
using congestion_tax_calculator_net_core.Data.Enum;
using System;

namespace congestion_tax_calculator_net_core.Data.Dto
{
    public class VehicleDto
    {

        public Guid Id { get; set; }
        public string NumberPlates { get; set; }
        public VehicleTypes Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public static implicit operator VehicleDto(Vehicle x)
        {
            return x == null ? null : new VehicleDto
            {
                Id = x.Id,
                NumberPlates = x.NumberPlates,
                Type = x.Type,
                CreatedAt = x.CreatedAt,
            };

        }

    }
}
