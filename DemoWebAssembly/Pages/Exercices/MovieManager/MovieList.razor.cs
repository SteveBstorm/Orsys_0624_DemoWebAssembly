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

        public HubConnection Connection { get; set; }

        public int SelectedId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Liste = new List<Movie>();
            Liste = (await Service.GetAll()).ToList();

            Connection = new HubConnectionBuilder().WithUrl("https://localhost:7170/moviehub").Build();
            await Connection.StartAsync();

            Connection.On("notifyNewMovie", async () =>
            {
                Liste = (await Service.GetAll()).ToList();
                StateHasChanged();
            });
        }

        //protected override bool ShouldRender()
        //{
        //    return Liste.Count() > 0;
        //}

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
