using AutoMapper;

namespace StarWarsService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // create a map from our model to the protobuf DTO
            CreateMap<Shared.Models.Person, Protobuf.Person>();
        }
    }
}
