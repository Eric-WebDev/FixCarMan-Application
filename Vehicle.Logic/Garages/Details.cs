using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Data.DBContexts;
using Vehicle.Data.Models;

namespace Vehicle.Logic.Garages
{
    public class Details
    {
     public class Query : IRequest<Garage>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Garage>
        {
            private readonly VehicleContext _context;

            public Handler(VehicleContext context)
            {
                _context = context;
            }

            public async Task<Garage> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var garage = await _context.Garages.FindAsync(request.Id);
                return garage;
            }
        }
    }
}
