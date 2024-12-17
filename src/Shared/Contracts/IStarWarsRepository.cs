using Shared.Models;

namespace Shared.Contracts
{
    public interface IStarWarsRepository
    {
        Task<Person> GetPersonAsync(int id);

        Task<People> GetPeopleAsync();
    }
}