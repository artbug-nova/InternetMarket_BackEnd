using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Configuration
{
    public class AuthBasicConfig : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserAuhorizeService _userAuhorizeService;

        public AuthBasicConfig(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserAuhorizeService userAuhorizeService) : base(options, logger, encoder, clock)
        {
            this._userAuhorizeService = userAuhorizeService;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing headers");

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authentication"]);
                var creditionalsBytes = Convert.FromBase64String(authHeader.Parameter);
                var creditials = Encoding.UTF8.GetString(creditionalsBytes).Split(':', 2);
                var userName = creditials[0];
                var password = creditials[1];
                var user = _userAuhorizeService.Authenticate(userName, password);

                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, userName),
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);

                }
                return AuthenticateResult.Fail("Fail login");
            }

            catch(Exception exp)
            {
                return AuthenticateResult.Fail("Fail: " + exp.Message);
            }
        }
    }

    public static class AuthBasicServiceConfig
    {
        public static IServiceCollection SetBasicAuth(this IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthBasicConfig>("BasicAuthentication", null);
            return services;
        }
    }

    public  interface IUserAuhorizeService
    {
        UserAuthorize Authenticate(String userName, String password);
    }

    public class UserAuhorizeService : IUserAuhorizeService
    {
        private readonly IEnumerable<UserAuthorize> _users;
        public UserAuthorize Authenticate(string userName, string password)
        {
            return _users.SingleOrDefault(us => us.Login == userName && us.Password == password);
        }
    }

    public class UserAuthorize
    {
        public String? Login { get; set; }
        public String? Password { get; set; }
        public String? Role { get; set; }
    }

}