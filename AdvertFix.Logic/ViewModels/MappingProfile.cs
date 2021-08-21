using AdvertFix.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Advert, AdvertDTO>();
            CreateMap<Advertiser, AdvertiserDTO>();           
        }
    }
}
