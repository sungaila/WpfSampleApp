using Shared.Contracts;
using Shared.Models;

namespace StarWarsService.Clients
{
    public class StarWarsApiClient : IStarWarsRepository
    {
        private static readonly HttpClient _httpClient = new();

        public async Task<Person> GetPersonAsync(int id)
            => (await _httpClient.GetFromJsonAsync<Person>($"https://swapi.dev/api/people/{id}/?format=json"))!;

        public async Task<People> GetPeopleAsync()
            => (await _httpClient.GetFromJsonAsync<People>("https://swapi.dev/api/people/?format=json"))!;
    }
}