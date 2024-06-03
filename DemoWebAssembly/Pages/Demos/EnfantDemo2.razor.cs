using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class EnfantDemo2
    {
        [Parameter]
        public int ValueFromCaller { get; set; }

        [Parameter]
        public EventCallback<string> MyResponseEvent { get; set; }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            await Console.Out.WriteLineAsync("test");
            Console.WriteLine(parameters.GetValueOrDefault<int>(nameof(ValueFromCaller)));
            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnParametersSetAsync()
        {
            await Console.Out.WriteLineAsync("param : " + ValueFromCaller);
            ValueFromCaller *= 2;
           
        }

        protected override bool ShouldRender()
        {
            return !(ValueFromCaller == 182);
        }

        public void Declenche()
        {
             MyResponseEvent.InvokeAsync("Ca y est j'ai la bonne valeur");

        }
    }
}
