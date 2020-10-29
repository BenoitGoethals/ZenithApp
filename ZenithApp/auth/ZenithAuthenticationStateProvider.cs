using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ZenithApp.auth
{
    public class ZenithAuthenticationStateProvider:AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
           var an=new ClaimsIdentity(new List<Claim>()
           {
               new Claim(ClaimTypes.Name,"benoit")
          , new Claim(ClaimTypes.Role,"admin")
           }, "test");
           return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(an)));
        }
    }
}