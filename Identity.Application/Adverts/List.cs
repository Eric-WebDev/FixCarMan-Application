using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.Application.Interfaces;
using Identity.Application.Profiles;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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
        public class Query : IRequest<AdsEnvelope> { }
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
                var query = _context.UserAdverts
                    .ProjectTo<UserAdDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();
               
                var adverts = await query.ToListAsync();
                return new AdsEnvelope
                {
                    Adverts = (adverts),
                    AdvertCount = adverts.Count()
                };

            }
        }
    }
}
