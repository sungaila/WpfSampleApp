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

            using var channel = GrpcChannel.ForAddress("https://localhost:7232");
            var client = new StarWarsGrpc.StarWarsGrpcClient(channel);

            var reply = await client.GetPeopleAsync(new());

            context.Results.Clear();

            foreach (var person in reply.Results)
            {
                context.Results.Add(_mapper.Map<PersonViewModel>(person));
            }
        },
        context => context != null);
    }
}