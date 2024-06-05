using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public partial class MovieList
    {
        [Inject]
        public MovieService Service { get; set; }
        public List<Movie> Liste { get; set; }

        public int SelectedId { get; set; }
        public HubConnection Connection { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Liste = Service.Liste;

            //Connection au hub
            Connection = new HubConnectionBuilder().WithUrl("https://localhost:7170/moviehub").Build();
            await Connection.StartAsync();

            //Abonnement à un event du hub
            Connection.On("notifyNewMovie", (Movie newMovie) =>
            {
                Liste.Add(newMovie);
                StateHasChanged();
            });
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
