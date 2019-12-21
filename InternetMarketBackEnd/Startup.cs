using InternetMarketBackEnd.Configuration;
using InternetMarketBackEnd.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.IdentityModel.Tokens;
using Autofac;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using Autofac.Extensions.DependencyInjection;
using InternetMarketBackEnd.CrossCutting.Ioc.Module;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;

namespace InternetMarketBackEnd
{
    public class Startup
    {
        public Startup(/*IConfiguration configuration*/IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            
            this.Configuration = builder.Build();
            //Configuration = configuration;
        }

        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.ConfigureAuth();
            services.ConfigureEF(Configuration.GetConnectionString("MarketDatabase"));
            services.ConfigureCors();
            services.ConfigureSwagger();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            services.AddMvc();
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new InfrastructureModule());
            containerBuilder.RegisterModule(new ServiceModule());
            containerBuilder.RegisterModule(new RepositoryModule());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowAnyOrigin");
            app.UseRouting();
            app.UseSwagger();
            app.ApplicationSwagger();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
