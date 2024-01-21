
using congestion_tax_calculator_net_core.Contract;
using congestion_tax_calculator_net_core.Data.Entity;
using congestion_tax_calculator_net_core.Data.Enum;
using congestion_tax_calculator_net_core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace congestion_tax_calculator_net_core
{
    public static class Extension
    {     
        public static void AddApplicationServices(this IServiceCollection services)     
        {
            var applicationServiceType = typeof(IApplicationService).Assembly;
            var AllApplicationServices = applicationServiceType.ExportedTypes
               .Where(x => x.IsClass && x.IsPublic && x.FullName.Contains("ApplicationService")).ToList();
            foreach (var type in AllApplicationServices)
            {
                if (type.IsAbstract && type.IsSealed)
                {
                    continue;
                }
                Console.WriteLine(type.Name);
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            var repositpryType = typeof(Repository<>).Assembly;
            var AllRepositories = repositpryType.ExportedTypes
               .Where(x => x.IsClass && x.IsPublic && x.Name.Contains("Repository") && !x.Name.StartsWith("Repository")).ToList();
            foreach (var type in AllRepositories)
            {
                Console.WriteLine(type.Name);
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
        }

        public static void SeedData(this ModelBuilder builder)
        {


            Guid gothenburgId = Guid.Parse("1114eb2e-3588-4239-98a4-f7e3023674e8");
            var gothenburg = new City
            {
                Id = gothenburgId,
                CreatedAt = new DateTime(2000 , 1 , 1),
                MaxTax = 60 ,
                Name = "Gothenburg"
            };
            builder.Entity<City>().HasData(gothenburg);

            builder.Entity<CongestionTaxRule>().HasData(
                new CongestionTaxRule { Id = Guid.Parse("1114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,6,0,0) , To = new DateTime(2000,1,1,6,29,59),Type = RuleTypes.TaxTime, Amount = 8 },
                new CongestionTaxRule { Id = Guid.Parse("2114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,6,30,0) , To = new DateTime(2000,1,1,6,59,59),Type = RuleTypes.TaxTime, Amount = 13 },
                new CongestionTaxRule { Id = Guid.Parse("3114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,7,0,0) , To = new DateTime(2000,1,1,7,59,59),Type = RuleTypes.TaxTime, Amount = 18 },
                new CongestionTaxRule { Id = Guid.Parse("4114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,8,0,0) , To = new DateTime(2000,1,1,8,29,59),Type = RuleTypes.TaxTime, Amount = 13 },
                new CongestionTaxRule { Id = Guid.Parse("5114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,8,30,0) , To = new DateTime(2000,1,1,14,59,59),Type = RuleTypes.TaxTime, Amount = 8 },
                new CongestionTaxRule { Id = Guid.Parse("6114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,15,0,0) , To = new DateTime(2000,1,1,15,29,59),Type = RuleTypes.TaxTime, Amount = 13 },
                new CongestionTaxRule { Id = Guid.Parse("7114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,15,30,0) , To = new DateTime(2000,1,1,16,59,59),Type = RuleTypes.TaxTime, Amount = 18 },
                new CongestionTaxRule { Id = Guid.Parse("8114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,17,0,0) , To = new DateTime(2000,1,1,17,59,59),Type = RuleTypes.TaxTime, Amount = 13 },
                new CongestionTaxRule { Id = Guid.Parse("9114eb2e-3588-4239-98a4-f7e3023674e9"), CityId = gothenburgId ,From=new DateTime(2000,1,1,18,0,0) , To = new DateTime(2000,1,1,18,29,59),Type = RuleTypes.TaxTime, Amount = 8 }
                );

        }

        
    }
}
