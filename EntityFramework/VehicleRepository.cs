using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator_net_core.Data.Entity;
using congestion_tax_calculator_net_core.Contract;

namespace congestion_tax_calculator_net_core.EF
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly IContext ctx;

        public VehicleRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }


    }
}
