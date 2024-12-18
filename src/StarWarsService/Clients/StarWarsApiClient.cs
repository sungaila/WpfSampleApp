using Shared.Contracts;
using Shared.Models;

namespace StarWarsService.Clients
{
    public class StarWarsApiClient : IStarWarsRepository
    {
        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://swapi.dev") };

        public async Task<Person> GetPersonAsync(int id)
            => (await _httpClient.GetFromJsonAsync<Person>($"/api/people/{id}/?format=json"))!;

        public async Task<People> GetPeopleAsync()
            => (await _httpClient.GetFromJsonAsync<People>("/api/people/?format=json"))!;
    }
}