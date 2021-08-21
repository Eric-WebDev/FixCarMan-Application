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
    public class Create
    {
        public class Command : IRequest
        {
            public int GarageId { get; set; }
            public string CompanyName { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string URL { get; set; }
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
                var garage = new Garage
                {
                    GarageId = request.GarageId,
                    CompanyName = request.CompanyName,
                    Street=request.Street,
                    City=request.City,
                    County=request.County,
                    URL=request.URL
                };
                _context.Garages.Add(garage);
                var succes = await _context.SaveChangesAsync() > 0;
                if (succes)
                {
                    return Unit.Value;
                }
                throw new Exception("Problem  saving changes");
            }
        }
    }
}
