using HRM.ERP.Data;
using HRM.ERP.Data.Helpers;
using HRM.ERP.Data.Repository;
using HRM.ERP.Data.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.ERP.Business.Helpers
{
    public static class ServicesExtensionHelper
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataServices(configuration);
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
