
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hr.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<Hr.Application.Mapping.EmployeeMapping>();
            });

            return services;
        }
    }
}