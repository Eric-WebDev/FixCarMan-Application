using FluentValidation;
using Identity.Application.Errors;
using Identity.Application.Interfaces;
using Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Vehicles
{
    public class EditVehicle
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string RegistrationNumber { get; set; }
            public string Description { get; set; }
            public string RegistrationYear { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public string BodyStyle { get; set; }
            public string Transmission { get; set; }
            public string FuelType { get; set; }
            public int? NumberOfSeats { get; set; }
            public int? NumberOfDoors { get; set; }
            public double? EngineSize { get; set; }
            public string Vin { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RegistrationNumber).NotEmpty();
                RuleFor(x => x.CarMake).NotEmpty();
                RuleFor(x => x.CarModel).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var vehicle = await _context.Vehicles.FindAsync(request.Id);
                if (vehicle == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Advert = "Vehicle Not found" });
                if (vehicle.Id == user.Id)
                {

                    vehicle.RegistrationNumber = request.RegistrationNumber ?? vehicle.RegistrationNumber;
                    vehicle.Description = request.Description ?? vehicle.Description;
                    vehicle.RegistrationYear = request.RegistrationYear ?? vehicle.RegistrationYear;
                    vehicle.CarMake = request.CarMake ?? vehicle.CarMake;
                    vehicle.CarModel = request.CarModel ?? vehicle.CarModel;
                    vehicle.BodyStyle = request.BodyStyle ?? vehicle.BodyStyle;
                    vehicle.Transmission = request.Transmission ?? vehicle.Transmission;
                    vehicle.FuelType = request.FuelType ?? vehicle.FuelType;
                    vehicle.NumberOfSeats = request.NumberOfSeats ?? vehicle.NumberOfSeats;
                    vehicle.NumberOfDoors = request.NumberOfDoors ?? vehicle.NumberOfDoors;
                    vehicle.EngineSize = request.EngineSize ?? vehicle.EngineSize;
                    vehicle.Vin = request.Vin ?? vehicle.Vin;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Unit.Value;

                    throw new Exception("Problem saving changes");
                }
                else
                {
                    throw new Exception("Not authorized");
                }
            }
        }
    }
}
