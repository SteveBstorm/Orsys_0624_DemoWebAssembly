using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoWebAssembly.Security
{
    /*NUGET : Microsoft.AspNetCore.Components.Authorization*/
    public class MyStateProvider : AuthenticationStateProvider
    {
        public string token { get; set; }
        private readonly IJSRuntime js;
        public MyStateProvider(IJSRuntime _js)
        {
            js = _js;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            token = await js.InvokeAsync<string>("localStorage.getItem", "token");

            if(!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
            }

            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));

        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
         }
    }
}
