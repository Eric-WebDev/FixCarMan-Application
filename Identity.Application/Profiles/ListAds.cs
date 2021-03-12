using Identity.Application.Adverts;
using Identity.Application.Errors;
using Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Profiles
{
    public class ListAds
    {
        public class Query : IRequest<List<UserAdDto>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<UserAdDto>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<UserAdDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.Username);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, new { User = "Not found" });

                var queryable = user.UserAdverts
                    .OrderBy(a => a.Advert.Date)
                    .AsQueryable();


                switch (request.Predicate)
                {
                    case "expired":
                        queryable = queryable.Where(a => a.Advert.Date <= DateTime.Now);
                        break;
                    case "created":
                        queryable = queryable.Where(a => a.IsAdvertCreator);
                        break;
                    default:
                        queryable = queryable.Where(a => a.Advert.Date >= DateTime.Now);
                        break;
                } 
                var adverts = queryable.ToList();
                var advertsToReturn = new List<UserAdDto>();

                foreach (var advert in adverts)
                {
                    var userAdvert= new UserAdDto
                    {
                        Id = advert.Advert.Id,
                        Title = advert.Advert.Title,
                        CarModel = advert.Advert.CarModel,
                        Date = advert.Advert.Date
                    };

                    advertsToReturn.Add(userAdvert);
                }

                return advertsToReturn;
            }
        }
    }
}
