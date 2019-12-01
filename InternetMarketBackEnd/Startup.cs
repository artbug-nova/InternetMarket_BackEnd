using InternetMarketBackEnd.Configuration;
using InternetMarketBackEnd.Infra.Data;
using InternetMarketBackEnd.token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Autofac;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using Autofac.Extensions.DependencyInjection;
using InternetMarketBackEnd.CrossCutting.Ioc.Module;

namespace InternetMarketBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MarketDatabase"));
                
            });
            services.AddControllers();
            //services.ConfigureAuth();
            services.ConfigureCors();
            services.ConfigureSwagger();
            //services.AddMvc(options=> options.EnableEndpointRouting = false);
            services.AddOptions();

            
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ServiceModule());
            //containerBuilder.RegisterModule(new InfrastructureModule());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("AllowAnyOrigin");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();

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
