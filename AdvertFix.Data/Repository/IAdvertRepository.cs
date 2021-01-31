using AdvertFix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Data.Repository
{
    public interface IAdvertRepository
    {
        IEnumerable<Advert> GetAllAdverts();
        Advert GetAdvertByID(int advertId);
        //Advert GetAdvertOwnerByAdvertID(int advertId);
        //Advert GetPhotosByAdvertID(int advertId);
        void AddAdvert(Advert advert);
        void DeleteAdvert(int advertId);
        void UpdateAdvert(Advert advert);
        void Save();
    }
}
