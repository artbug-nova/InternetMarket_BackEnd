using InternetMarketBackEnd.Configuration;
using InternetMarketBackEnd.Infra.Data;
using InternetMarketBackEnd.token;
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
            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MarketDatabase"));
                
            });
            services.AddControllers();
            //services.ConfigureAuth();
            services.ConfigureCors();
            services.ConfigureSwagger();
            //services.AddMvc(options=> options.EnableEndpointRouting = false);

            
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new InfrastructureModule());
            containerBuilder.RegisterModule(new ServiceModule());
            containerBuilder.RegisterModule(new RepositoryModule());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowAnyOrigin");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/

  
        }
    }
}
