using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Data.DBContexts;
using Vehicle.Data.Models;

namespace Vehicle.Logic.Garages
{
   public class List
    {
        public class Query: IRequest<List<Garage>> { }
        public class Handler : IRequestHandler<Query, List<Garage>>
        {
            private readonly VehicleContext _context;

            public Handler(VehicleContext context)
            {
                _context = context;
            }
            // handler to return list of garages
            public async Task<List<Garage>> Handle(Query request, 
                CancellationToken cancellationToken)
            {
                var garages = await _context.Garages.ToListAsync();
                return garages;
            }
        }

    }
}
