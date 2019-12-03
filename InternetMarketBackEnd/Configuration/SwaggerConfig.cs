using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;

namespace InternetMarketBackEnd.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketStore", Version = "v1" });
            });


            return services;
        }
        public static IApplicationBuilder ApplicationSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketApi V1");
            });
            return builder;
        }
    }
}
