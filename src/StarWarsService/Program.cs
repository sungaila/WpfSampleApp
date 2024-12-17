using Microsoft.EntityFrameworkCore;
using Shared.Contracts;
using SqliteDb;
using StarWarsService.Clients;
using StarWarsService.Services;
using System.Reflection;

namespace StarWarsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
#endif

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<StarWarsContext>(options => options.UseSqlite(connectionString));

            // Add services to the container.
            builder.Services.AddGrpc();

            if (builder.Configuration.GetValue<bool>("UseSqliteDb"))
            {
                builder.Services.AddScoped<IStarWarsRepository, SqliteDbClient>();
            }
            else
            {
                builder.Services.AddScoped<IStarWarsRepository, StarWarsApiClient>();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<StarWarsGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}