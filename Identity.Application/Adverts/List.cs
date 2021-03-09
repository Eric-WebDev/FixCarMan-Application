using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Adverts
{
    public class List
    {
       
        public class AdsEnvelope
        {
            public List<AdDto> Adverts { get; set; }
            public int AdvertCount { get; set; }
        }
        public class Query : IRequest<AdsEnvelope>
        {
            public Query(int? limit, int? offset,  DateTime? startDate)
            {
                Limit = limit;
                Offset = offset;
                StartDate = startDate ?? DateTime.Now;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public DateTime? StartDate { get; set; }
        }

        public class Handler : IRequestHandler<Query, AdsEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<AdsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Adverts
                    .Where(x => x.Date >= request.StartDate)
                    .OrderBy(x => x.Date)
                    .AsQueryable();

                queryable = queryable.Where(x => x.UserAdverts.Any(a => a.AppUser.UserName == _userAccessor.GetCurrentUsername()));
               
                var adverts = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 3).ToListAsync();

                return new AdsEnvelope
                {
                    Adverts = _mapper.Map<List<Advert>, List<AdDto>>(adverts),
                    AdvertCount = queryable.Count()
                };
            }
        }
    }

   
}
