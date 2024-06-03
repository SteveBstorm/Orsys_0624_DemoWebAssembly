using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo2
    {
        public int MyValue { get; set; }
        protected override void OnInitialized()
        {
            MyValue =84;
        }

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        Console.WriteLine(MyValue);
        //        MyValue *= 2;
        //        StateHasChanged();
        //    }
        //    Console.WriteLine(MyValue);
        //}

        protected override bool ShouldRender()
        {
            return !(MyValue == 86);
        }

        public void SimulateRender()
        {
            MyValue++;
        }

        public string ReponseDeEnfant { get; set; }
        public void ReceptionDeEnfant(string reponse)
        {
            ReponseDeEnfant = reponse;
        }
    }
}
