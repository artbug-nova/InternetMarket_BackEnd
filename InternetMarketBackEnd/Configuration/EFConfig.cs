using InternetMarketBackEnd.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternetMarketBackEnd.Configuration
{
    public static class EFConfig
    {
        public static IServiceCollection EFConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}
