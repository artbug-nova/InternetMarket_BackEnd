using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace InternetMarketBackEnd.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "SwaggerDefault",
                    Description = @"Swagger  
                    {
                    'code': 200,
                    'msg': 'New',
                    'data': { }
                    }",
                });
            });

            return services;
        }
    }
}
