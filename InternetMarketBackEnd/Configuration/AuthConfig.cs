using InternetMarketBackEnd.token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Configuration
{
    public static class AuthConfig
    {
        public static IServiceCollection ConfigureAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                                    // укзывает, будет ли валидироваться издатель при валидации токена
                                    ValidateIssuer = true,
                                    // строка, представляющая издателя
                                    ValidIssuer = AuthOptions.ISSUER,

                                    // будет ли валидироваться потребитель токена
                                    ValidateAudience = true,
                                    // установка потребителя токена
                                    ValidAudience = AuthOptions.AUDIENCE,
                                    // будет ли валидироваться время существования
                                    ValidateLifetime = true,

                                    // установка ключа безопасности
                                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                                    // валидация ключа безопасности
                                    ValidateIssuerSigningKey = true,
                    };
                });
            return services;
        }
    }
}
