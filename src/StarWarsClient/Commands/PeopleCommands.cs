using AutoMapper;
using CommunityToolkit.Mvvm.Input;
using Grpc.Net.Client;
using Protobuf;
using StarWarsClient.ViewModels;
using System.Windows.Input;

namespace StarWarsClient.Commands
{
    public static class PeopleCommands
    {
        private static readonly IMapper _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();

        public static ICommand RefreshCommand { get; } = new AsyncRelayCommand<PeopleViewModel>(async context =>
        {
            if (context == null)
                return;

            // open a gRPC channel and create a client
            using var channel = GrpcChannel.ForAddress("https://localhost:7232");
            var client = new StarWarsGrpc.StarWarsGrpcClient(channel);

            // call the endpoint for people
            // exceptions are not caught and handled here
            var reply = await client.GetPeopleAsync(new());

            // clear any existing people (this will reset any changes made by the user)
            context.Results.Clear();

            // map and add each person to the collection
            // sadly there is no AddRange for ObservableCollection
            foreach (var person in reply.Results)
            {
                context.Results.Add(_mapper.Map<PersonViewModel>(person));
            }
        },
        context => context != null);
    }
}