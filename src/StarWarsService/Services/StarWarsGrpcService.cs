using AutoMapper;
using Grpc.Core;
using Protobuf;
using Shared.Contracts;

namespace StarWarsService.Services
{
    public class StarWarsGrpcService(IStarWarsRepository repository, IMapper mapper) : StarWarsGrpc.StarWarsGrpcBase
    {
        public override async Task<GetPeopleReply> GetPeople(GetPeopleRequest request, ServerCallContext context)
        {
            Shared.Models.People people;

            try
            {
                people = await repository.GetPeopleAsync();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.NotFound, ex.Message, ex), "Could not retrieve data from Star Wars repository.");
            }

            var reply = new GetPeopleReply();
            reply.Results.AddRange(mapper.Map<Person[]>(people.Results));

            return reply;
        }
    }
}
