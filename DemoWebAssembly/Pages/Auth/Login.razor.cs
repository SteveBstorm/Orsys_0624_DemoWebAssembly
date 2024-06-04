using DemoWebAssembly.Models;
using DemoWebAssembly.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public AuthenticationStateProvider provider{ get; set; }

        public LoginForm myForm { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            myForm = new LoginForm();

            //await Console.Out.WriteLineAsync(await Client.GetStringAsync("movie"));
        }

        public async Task SubmitLogin()
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("auth/login", myForm);
            if (!response.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync(response.Content.ReadAsStringAsync().Result);
            }
            string token = await response.Content.ReadAsStringAsync();

            await JS.InvokeVoidAsync("localStorage.setItem", "token", token);
            ((MyStateProvider)provider).NotifyUserChanged();
        }
    }
}
