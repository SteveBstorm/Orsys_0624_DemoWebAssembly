using DemoWebAssembly;
using DemoWebAssembly.MiddleWare;
using DemoWebAssembly.Pages.Exercices.MovieManager;
using DemoWebAssembly.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

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

#region Config I18N
// Spécifier le dossier ou se trouvent les RESX
builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

// Config des cultures autorisées dans l'app
// Ne pas oublier d'ajouter 
// <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
// Dans le csproj
// Créer un composant CultureSelector
builder.Services.Configure<RequestLocalizationOptions>(o =>
{
    List<CultureInfo> cultureInfos = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR")
    };

    o.SetDefaultCulture("fr-FR");
    o.SupportedCultures = cultureInfos;
    o.SupportedUICultures = cultureInfos;
});
#endregion

//await builder.Build().RunAsync();

WebAssemblyHost host = builder.Build();

CultureInfo cultureInfo;
IJSRuntime js = host.Services.GetRequiredService<IJSRuntime>();
string currentCulture = await js.InvokeAsync<string>("localStorage.getItem", "blazorCulture");

if (currentCulture is not null)
    cultureInfo = new CultureInfo(currentCulture);
else
{
    cultureInfo = new CultureInfo("fr-FR");
    await js.InvokeVoidAsync("localStorage.setItem", "blazorCulture", "fr-FR");
}

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

await host.RunAsync();