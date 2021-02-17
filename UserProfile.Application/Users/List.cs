using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserProfile.Data;
using UserProfile.Domain;


namespace UserProfile.Application.Users
{
    public class List
    {
        public class Query : IRequest<List<GarageInfoDto>> { }

        public class Handler : IRequestHandler<Query, List<GarageInfoDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<GarageInfoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var garages = await _context.AppUsersProfiles
                    .ToListAsync();

                return _mapper.Map<List<UserProfileDetails>, List<GarageInfoDto>>(garages);
            }
        }
    }
}
