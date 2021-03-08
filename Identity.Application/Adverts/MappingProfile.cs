using AutoMapper;
using Identity.Domain;

namespace Identity.Application.Adverts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Advert, AdDto>();
            CreateMap<UserAdvert, AppUserAdDto>()
                .ForMember(d => d.AdvertiserUserName, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.AppUser.Email))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Image.Url))
                .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber));
        }
    }
}
