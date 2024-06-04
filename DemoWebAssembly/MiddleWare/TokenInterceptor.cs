using Microsoft.JSInterop;

namespace DemoWebAssembly.MiddleWare
{
    public class TokenInterceptor : DelegatingHandler
    {
        private IJSRuntime js;

        public TokenInterceptor(IJSRuntime js)
        {
            this.js = js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "bearer " + token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
