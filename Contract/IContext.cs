using congestion_tax_calculator_net_core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Contract
{
    public interface IContext
    {
        DbSet<CongestionTax> CongestionTax { get; set; }
        DbSet<CongestionTaxRule> CongestionTaxRule { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<City> City { get; set; }
        Task SaveChanges();
    }
}
