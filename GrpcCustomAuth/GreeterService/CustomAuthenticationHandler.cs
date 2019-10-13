using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GreeterService.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GreeterService
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        public CustomAuthenticationHandler(
            IOptionsMonitor<CustomAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // authentication logic
            // return Task.FromResult(AuthenticateResult.Fail("Some reason"));
            var claimsIdentity = new ClaimsIdentity(AuthConstants.SCHEMA);
            
            return Task.FromResult(AuthenticateResult.Success(
                new AuthenticationTicket(
                    new ClaimsPrincipal(claimsIdentity),
                    AuthConstants.SCHEMA
                )));
        }
    }
}