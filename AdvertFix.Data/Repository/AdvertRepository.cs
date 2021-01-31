using AdvertFix.Data.Context;
using AdvertFix.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertFix.Data.Repository
{
    public class AdvertRepository:IAdvertRepository
    {
        private readonly AdvertFixContext _dbContext;

        public AdvertRepository(AdvertFixContext context)
        {
            _dbContext = context;
        }
        public void AddAdvert(Advert advert)
        {
            _dbContext.Add(advert);
            Save();
        }

        public void DeleteAdvert(int advertId)
        {
            var advert = _dbContext.Adverts.Find(advertId);
            _dbContext.Adverts.Remove(advert);
            Save();
        }

        public Advert GetAdvertByID(int advertId)
        {
            return _dbContext.Adverts.Find(advertId);
        }

        public IEnumerable<Advert> GetAllAdverts()
        {
            return _dbContext.Adverts.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAdvert(Advert advert)
        {
            _dbContext.Entry(advert).State = EntityState.Modified;
            Save();
        }
    }
}
