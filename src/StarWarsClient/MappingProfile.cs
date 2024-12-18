using AutoMapper;
using StarWarsClient.ViewModels;

namespace StarWarsClient
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Protobuf.Person, ViewModels.PersonViewModel>()
                .ForMember(x => x.Gender, o => o.MapFrom(s => ConvertStringToGender(s.Gender)));
            CreateMap<ViewModels.PersonViewModel, ViewModels.PersonViewModel>();
        }

        private static PersonViewModel.GenderKind ConvertStringToGender(string gender) => gender.ToLowerInvariant() switch
        {
            "male" => PersonViewModel.GenderKind.Male,
            "female" => PersonViewModel.GenderKind.Female,
            "n/a" => PersonViewModel.GenderKind.NotApplicable,
            "unknown" => PersonViewModel.GenderKind.Unknown,
            _ => PersonViewModel.GenderKind.Unknown
        };
    }
}