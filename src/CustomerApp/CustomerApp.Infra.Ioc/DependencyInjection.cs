using CustomerApp.Application.Interfaces;
using CustomerApp.Application.Mappings;
using CustomerApp.Application.Services;
using CustomerApp.Domain.Interfaces;
using CustomerApp.Infra.Data.Context;
using CustomerApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApp.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
