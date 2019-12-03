using System;
using InternetMarketBackEnd.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternetMarketBackEnd.Configuration
{
    public static class EFConfig
    {
        public static IServiceCollection ConfigureEF(this IServiceCollection services, String connectionString)
        {
            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });
            return services;
        }
    }
}
