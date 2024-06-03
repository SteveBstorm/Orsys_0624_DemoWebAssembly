using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo5
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        public IJSObjectReference jsModule;

        public string MyValue { get; set; }
        public string ValueFromStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            jsModule = await Js.InvokeAsync<IJSObjectReference>("import", "./script/myscript.js");
            await jsModule.InvokeVoidAsync("MyFunction");
        }

        public void Register()
        {
            Js.InvokeVoidAsync("alert", MyValue);
            Js.InvokeVoidAsync("localStorage.setItem", "macle", JsonConvert.SerializeObject(new {nom = "steve", age = "trop vieux"}));
        }

        public async Task GetValue()
        {
            ValueFromStorage = await Js.InvokeAsync<string>("localStorage.getItem", "macle");
            await Console.Out.WriteLineAsync(ValueFromStorage);
        }
    }
}
