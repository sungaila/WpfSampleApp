using AutoMapper;

namespace StarWarsClient
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Protobuf.Person, ViewModels.PersonViewModel>();
        }
    }
}