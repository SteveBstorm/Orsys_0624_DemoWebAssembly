using DemoWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public partial class MovieCreate
    {
        [Inject]
        public MovieService Service { get; set; }
        public Movie newMovie { get; set; }
        [Parameter]
        public EventCallback NotifyNewMovie { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        //[Inject]
        //public IHttpClientFactory Factory { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        protected override void OnInitialized()
        {
            newMovie = new Movie();
        }
        public async Task ValidSubmit()
        {
            Service.Add(newMovie);
            //Client = Factory.CreateClient("withToken");
            //string token = await js.InvokeAsync<string>("localStorage.getItem", "token");
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",token);
            await Client.PostAsJsonAsync("movie", newMovie);
            newMovie = new Movie();
            await NotifyNewMovie.InvokeAsync();
        }
    }
}
