using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo4
    {
        [Inject]
        public NavigationManager Nav { get; set; }

        public void Redirect(int info)
        {
            Nav.NavigateTo("/cible/" + info);
        }
    }
}
