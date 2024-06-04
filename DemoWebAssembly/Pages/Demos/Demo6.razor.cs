using DemoWebAssembly.Models;

namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo6
    {
        public Movie newMovie { get; set; }

        protected override void OnInitialized()
        {
            newMovie = new Movie();
        }

        public void onValidSubmit()
        {
            Console.WriteLine("Formulaire OK");
        }

        public void onSubmit()
        {
            Console.WriteLine("Submit");
        }
    }
}
