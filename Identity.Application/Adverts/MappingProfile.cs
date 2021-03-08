using AutoMapper;
using Identity.Domain;

namespace Identity.Application.Adverts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Advert, AdDto>();
        }
    }
}
