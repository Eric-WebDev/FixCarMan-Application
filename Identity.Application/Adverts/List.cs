using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.Application.Interfaces;
using Identity.Application.Profiles;
using Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Adverts
{
    public class List
    {
       
        public class AdsEnvelope
        {
            public List<UserAdDto> Adverts { get; set; }
            public int AdvertCount { get; set; }
        }
        public class Query : IRequest<AdsEnvelope>
        {
            public Query(int? limit, int? offset,  bool isAdvertCreator)
            {
                Limit = limit;
                Offset = offset;
                IsAdvertCreator = isAdvertCreator;
                //StartDate = startDate ?? DateTime.Now;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public bool IsAdvertCreator { get; set; }
            //public DateTime? StartDate { get; set; }
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
            var queryable = _context.UserAdverts
                //.Where(x => x.Date >= request.StartDate)
                .OrderBy(x => x.DatePublished)
                .ProjectTo<UserAdDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

                if (!request.IsAdvertCreator)
                {
                    queryable = queryable.Where((a => a.AdvertiserUsername == _userAccessor.GetCurrentUsername()));
                }
                if (!request.IsAdvertCreator)
                {
                    queryable = queryable.Where((a => a.AdvertiserUsername == _userAccessor.GetCurrentUsername() && a.IsAdvertCreator));
         
                }

                var adverts = await queryable
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 5)
                .ToListAsync();

            return new AdsEnvelope
            {
                Adverts = (adverts),
                AdvertCount = queryable.Count()
            };
        }
        }
    }
}
