using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Data.DBContexts;

namespace Vehicle.Logic.Garages
{
   public class Delete
    {
        public class Command : IRequest
        {
            public int GarageId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly VehicleContext _context;
            public Handler(VehicleContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var garage = await _context.Garages.FindAsync(request.GarageId);

                if (garage == null)
                    throw new Microsoft.Rest.RestException("Could not find");

                _context.Remove(garage);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
