using Microsoft.EntityFrameworkCore;
using Shared.Contracts;
using Shared.Models;
using SqliteDb;

namespace StarWarsService.Clients
{
    /// <summary>
    /// Uses a lokal SQLite database file to receive Star Wars related data.
    /// </summary>
    /// <param name="dbContext"></param>
    public class SqliteDbClient(StarWarsContext dbContext) : IStarWarsRepository
    {
        public Task<People> GetPeopleAsync()
        {
            var people = dbContext.People.AsNoTracking().ToArray();

            return Task.FromResult(new People
            (
                people.Length,
                string.Empty,
                string.Empty,
                people
            ));
        }

        public Task<Person> GetPersonAsync(int id)
            => dbContext.People.AsNoTracking().SingleAsync(p => p.Id == id);
    }
}