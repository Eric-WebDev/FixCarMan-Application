using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Vehicles
{
    public class ListVehicle
    {
        public class Query : IRequest<List<Vehicle>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<Vehicle>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<Vehicle>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Vehicles
                .Where(u => u.VehicleOwner.UserName == request.Username)
                //.ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
                query = request.Predicate switch
                {
                    "vehicles" => query.Where(i => i.VehicleOwner.UserName == request.Username),
                    _ => query.Where(i => i.VehicleOwner.UserName == request.Username)
                };
                var vehicles = await query.ToListAsync();
                return (vehicles);
            }
        }
    }
}
