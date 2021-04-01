using FluentValidation;
using Identity.Application.Interfaces;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Vehicles
{
    public class CreateVehicle
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string RegistrationNumber { get; set; }
            public string Description { get; set; }
            public string RegistrationYear { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public AppUser VehicleOwnerUsername { get; set; }
            public string BodyStyle { get; set; }
            public string Transmission { get; set; }
            public string FuelType { get; set; }
            public int NumberOfSeats { get; set; }
            public int NumberOfDoors { get; set; }
            public double EngineSize { get; set; }
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
                var vehicle = new Vehicle
                {
                    Id = user.Id,
                    RegistrationNumber = request.RegistrationNumber,
                    Description = request.Description,
                    RegistrationYear = request.RegistrationYear,
                    CarMake = request.CarMake,
                    CarModel = request.CarModel,
                    BodyStyle = request.BodyStyle,
                    Transmission = request.Transmission,
                    FuelType = request.FuelType,
                    NumberOfSeats = request.NumberOfSeats,
                    NumberOfDoors = request.NumberOfDoors,
                    EngineSize = request.EngineSize,
                    Vin = request.Vin

                };

                _context.Vehicles.Add(vehicle);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }

}