using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public partial class MovieCreate
    {
        [Inject]
        public MovieService Service { get; set; }
        public Movie newMovie { get; set; }
        [Parameter]
        public EventCallback NotifyNewMovie { get; set; }
        protected override void OnInitialized()
        {
            newMovie = new Movie();
        }
        public void ValidSubmit()
        {
            Service.Add(newMovie);
            newMovie = new Movie();
            NotifyNewMovie.InvokeAsync();
        }
    }
}
