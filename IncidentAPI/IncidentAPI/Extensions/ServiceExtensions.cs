using Business.Interfaces;
using Business.Services;
using Data.Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
