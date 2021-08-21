using AutoMapper;
using Identity.Application.Errors;
using Identity.Application.Profiles;
using Identity.Data;
using Identity.Domain;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Adverts
{
    public class DetailsAd
    {

        public class Query : IRequest<AdDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AdDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<AdDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var ad = await _context.Adverts
                    .FindAsync(request.Id);

                if (ad == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Advert = "Not found" });

                var advertToReturn = _mapper.Map<Advert, AdDto>(ad);

                return advertToReturn;
            }
        }
    }
}
