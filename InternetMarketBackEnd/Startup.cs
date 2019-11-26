using InternetMarketBackEnd.Configuration;
using InternetMarketBackEnd.token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InternetMarketBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.ConfigureAuth();
            services.ConfigureCors();
            services.ConfigureSwagger();
            //services.AddMvc(options=> options.EnableEndpointRouting = false);
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
