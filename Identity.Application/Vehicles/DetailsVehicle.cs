using AutoMapper;
using Identity.Application.Errors;
using Identity.Data;
using Identity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Vehicles
{
    public class DetailsVehicle
    {
        public class Query : IRequest<VehicleDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, VehicleDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<VehicleDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicle = await _context.Vehicles.FindAsync(request.Id);

                if (vehicle == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Advert = "Not found" });

                var vehicleToReturn = _mapper.Map<Vehicle, VehicleDto>(vehicle);

                return vehicleToReturn;
            }
        }
    }
}
