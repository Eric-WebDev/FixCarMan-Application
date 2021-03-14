using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.Application.Profiles;
using Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Profiles
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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<UserAdDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UserAdverts
                .Where(u => u.AppUser.UserName == request.Username)
                .OrderBy(a => a.Advert.Date)
                .ProjectTo<UserAdDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
                query = request.Predicate switch
                {
                    "expired" => query.Where(a => a.Date <= DateTime.Now),
                    "created" => query.Where(a => a.AdvertiserUsername == request.Username), _ => query.Where(a => a.Date >= DateTime.Now)
                };
                var adverts = await query.ToListAsync();
                return (adverts);
            }
        }
    }
}