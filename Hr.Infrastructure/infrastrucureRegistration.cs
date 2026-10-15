
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Infrastructure.Data;
using Hr.Infrastructure.Repositories;
using Hr.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUnitOfWorkRepo, UnitOfWorkRepo>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGeneralSettingService, GeneralSettingService>();



            return services;
        }
    }
}