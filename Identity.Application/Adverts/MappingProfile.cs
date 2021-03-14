using AutoMapper;
using Identity.Domain;

namespace Identity.Application.Adverts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAdvert, Profiles.UserAdDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.AdvertId))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Advert.Title))
                .ForMember(d => d.CarModel, o => o.MapFrom(s => s.Advert.CarModel))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.DatePublished))
                .ForMember(d => d.AdvertiserUsername, o => o.MapFrom(s => s.AppUser.UserName));
        }
    }
}
