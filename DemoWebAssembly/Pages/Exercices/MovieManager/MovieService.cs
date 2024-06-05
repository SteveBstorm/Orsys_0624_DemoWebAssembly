using DemoWebAssembly.Models;
using System.Net.Http.Json;

namespace DemoWebAssembly.Pages.Exercices.MovieManager
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        
        public List<Movie> Liste { get; set; }
        public MovieService(HttpClient httpClient)
        {
            Liste = new List<Movie>();
            //Liste.Add(new Movie
            //{
            //    Id = 1,
            //    Title = "Star wars",
            //    Realisator = new Person
            //    {
            //        Firstname = "George",
            //        Lastname = "Lucas"
            //    },
            //    ReleaseYear = 1977,
            //    Synopsis = "Pan pan dans l'espace"

            //});

            //Liste.Add(new Movie
            //{
            //    Id = 2,
            //    Title = "Pacific Rim",
            //    Realisator = new Person
            //    {
            //        Firstname = "Guillermo",
            //        Lastname = "Del Toro"
            //    },
            //    ReleaseYear = 2013,
            //    Synopsis = "Des gros robots et des monstres"

            //});
           
            _httpClient = httpClient;

        }

        public async Task<Movie> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Movie>("movie/" + id);
            //return Liste.FirstOrDefault(x => x.Id == id);
        }

        public async Task Add(Movie movie)
        {
            //movie.Id = Liste.Max(x => x.Id) + 1;
            await _httpClient.PostAsJsonAsync("movie", movie);
            //Liste.Add(movie);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("movie");
        }
    }
}
