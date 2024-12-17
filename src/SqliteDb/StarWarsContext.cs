using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace SqliteDb
{
    public class StarWarsContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public StarWarsContext() { }

        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options) { }
    }
}