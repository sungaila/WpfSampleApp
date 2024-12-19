using Shared.Contracts;
using Shared.Models;

namespace StarWarsService.Clients
{
    /// <summary>
    /// Uses <see href="https://swapi.dev"/> APIs to receive Star Wars related data.
    /// </summary>
    public class StarWarsApiClient : IStarWarsRepository
    {
        private static readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://swapi.py4e.com") };

        public async Task<Person> GetPersonAsync(int id)
            => (await _httpClient.GetFromJsonAsync<Person>($"/api/people/{id}/?format=json"))!;

        public async Task<People> GetPeopleAsync()
        {
            var people = new List<Person>();

            // keep requesting on this endpoint until Next is null
            for (var response = await _httpClient.GetFromJsonAsync<People>("api/people/?format=json");
                 response != null;
                 response = await _httpClient.GetFromJsonAsync<People>(response.Next))
            {
                people.AddRange(response.Results);

                if (response.Next == null)
                    break;
            }

            return new People(people.Count, null, null, [.. people]);
        }
    }
}