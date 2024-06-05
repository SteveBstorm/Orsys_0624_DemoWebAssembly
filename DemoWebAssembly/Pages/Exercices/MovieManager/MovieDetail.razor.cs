using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public partial class MovieDetail
    {
        [Inject]
        public MovieService Service { get; set; }

        [Parameter]
        public int MovieId { get; set; }

        public Movie CurrentMovie { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            CurrentMovie = await Service.GetById(MovieId);
        }
    }
}
