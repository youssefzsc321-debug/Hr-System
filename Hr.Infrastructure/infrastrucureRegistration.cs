
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Infrastructure.Data;
using Hr.Infrastructure.Persistence.Seeds;
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
        public static async Task<IServiceCollection> InfrastructureConfigurationAsync(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUnitOfWorkRepo, UnitOfWorkRepo>();
            services.AddScoped<IEmployeeServices, EmployeeService>();
            services.AddScoped<IGeneralSettingServices, GeneralSettingService>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IUserService,UserService>();


           
            return services;
        }
    }
}