using CQRS_Service.Application.Absreactions;
using CQRS_Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Service.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ICQRSDBContext, CQRSDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Defoult"));
            });

            return services;
        }



    }
}
