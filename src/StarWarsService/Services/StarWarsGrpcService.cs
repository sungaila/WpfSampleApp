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
                // try to request the Star Wars people
                people = await repository.GetPeopleAsync();
            }
            catch (Exception ex)
            {
                // throw a RpcException if anything goes wrong
                // the gRPC client will receive the given status code and message
                throw new RpcException(new Status(StatusCode.NotFound, ex.Message, ex), "Could not retrieve data from Star Wars repository.");
            }

            // create a gRPC reply and map the Star Wars people to it
            var reply = new GetPeopleReply();
            reply.Results.AddRange(mapper.Map<Person[]>(people.Results));

            return reply;
        }
    }
}
