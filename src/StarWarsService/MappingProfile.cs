using AutoMapper;

namespace StarWarsService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shared.Models.Person, Protobuf.Person>();
        }
    }
}
