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
            try
            {
                context.IsRefreshing = true;

                using var channel = GrpcChannel.ForAddress("https://localhost:7232");
                var client = new StarWarsGrpc.StarWarsGrpcClient(channel);

                GetPeopleReply reply;

                try
                {
                    reply = await client.GetPeopleAsync(new());
                }
                catch (Exception ex)
                {
                    throw;
                }

                context.Results.Clear();

                foreach (var person in reply.Results)
                {
                    context.Results.Add(_mapper.Map<PersonViewModel>(person));
                }
            }
            finally
            {
                context.IsRefreshing = false;
            }
        });
    }
}