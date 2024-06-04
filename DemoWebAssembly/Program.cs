using DemoWebAssembly;
using DemoWebAssembly.MiddleWare;
using DemoWebAssembly.Pages.Exercices.MovieManager;
using DemoWebAssembly.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7170/api/") });
builder.Services.AddScoped<MovieService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();

/*
 Configuration Interceptor
    Nuget : Microsoft.Extensions.Http
 */
builder.Services.AddTransient<TokenInterceptor>();
builder.Services.AddHttpClient("withToken", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7170/api/");
}).AddHttpMessageHandler<TokenInterceptor>();

builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("withToken"));

await builder.Build().RunAsync();
