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
            // in debugging the working directory is not the output directory
            // this is an issue for the connection string using a relative path to the sqlite database
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
#endif

            var builder = WebApplication.CreateBuilder(args);

            // initialize AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // initialize the connection string and EF db context
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<StarWarsContext>(options => options.UseSqlite(connectionString));

            // add gRPC services
            builder.Services.AddGrpc();

            // depending on the value set in appsettings.json
            // either the SQLite db or the HTTP enpoint is used as data source
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

            // write a message for people trying to use this enpoint in a browser
            app.MapGet("/", () => "Dieser Service bietet nur einen gRPC-Endpunkt an. Der gRPC-Endpunkt kann mit der WPF-Anwendung StarWarsClient angesprochen werden.");

            app.Run();
        }
    }
}