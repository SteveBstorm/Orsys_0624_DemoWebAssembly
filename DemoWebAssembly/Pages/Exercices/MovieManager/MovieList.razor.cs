using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public partial class MovieList
    {
        [Inject]
        public MovieService Service { get; set; }
        public List<Movie> Liste { get; set; }

        public int SelectedId { get; set; }

        protected override void OnInitialized()
        {
            Liste = Service.Liste;
        }

        public void SelectId(int id)
        {
            SelectedId = id;
        }

        public void NewMovieReceived()
        {
            StateHasChanged();
            //Liste = Service.Liste;
        }
    }
}
