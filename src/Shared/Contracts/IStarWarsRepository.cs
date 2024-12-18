using Shared.Models;

namespace Shared.Contracts
{
    /// <summary>
    /// An abstraction for a source of Star Wars related data.
    /// </summary>
    public interface IStarWarsRepository
    {
        /// <summary>
        /// Gets a single person for the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the person to find.</param>
        Task<Person> GetPersonAsync(int id);

        /// <summary>
        /// Gets all the people.
        /// </summary>
        Task<People> GetPeopleAsync();
    }
}