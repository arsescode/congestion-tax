using congestion_tax_calculator_net_core.Contract;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IContext ctx,
            ICityRepository city,
            IVehicleRepository vehicle,
            ICongestionTaxRepository congestionTax,
            ICongestionTaxRuleRepository congestionTaxRule

        )
        {

            //------------------
            this.Ctx = ctx;
            this.City = city;
            this.Vehicle = vehicle;
            this.CongestionTax = congestionTax;
            this.CongestionTaxRule = congestionTaxRule;
        }
        public IContext Ctx { get; set; }
        public ICityRepository City { get; set; }
        public IVehicleRepository Vehicle { get; set; }
        public ICongestionTaxRepository CongestionTax { get; set; }
        public ICongestionTaxRuleRepository CongestionTaxRule { get; set; }

        public async Task Complete()
        {
            await Ctx.SaveChanges();
        }
    }
}
