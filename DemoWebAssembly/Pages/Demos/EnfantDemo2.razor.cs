using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class EnfantDemo2
    {
        [Parameter]
        public int ValueFromCaller { get; set; }

        [Parameter]
        public EventCallback<string> MyResponseEvent { get; set; }

        protected override async Task OnParametersSetAsync()
        {
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
