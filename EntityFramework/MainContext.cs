using System.Linq;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using congestion_tax_calculator_net_core.Contract;
using congestion_tax_calculator_net_core.Data.Entity;
using System.Reflection;
using System;

namespace congestion_tax_calculator_net_core.EF
{
    public class MainContext : DbContext, IContext
    {
        
        public DbSet<CongestionTax> CongestionTax { get; set; }
        public DbSet<CongestionTaxRule> CongestionTaxRule { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<City> City { get; set; }


        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public MainContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                builder.ApplyConfiguration(configurationInstance);
            }
            builder.SeedData();
        }

        public async Task SaveChanges()
        {
            await this.SaveChangesAsync();
        }
    }
}
