using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.ERP.Data.Helpers
{
    public static class ServicesExtensionHelper
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(d =>
                d.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(ServicesExtensionHelper));

            return services;
        }
    }
}
