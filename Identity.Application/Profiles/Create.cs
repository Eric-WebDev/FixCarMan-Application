using FluentValidation;
using Identity.Application.Interfaces;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Profiles
{
    public class Create
    {
        public class Command : IRequest
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string CompanyName { get; set; }

            public string ProfileDescription { get; set; }

            public string URL { get; set; }

            public DateTime? Birthday { get; set; }

            public string Street { get; set; }

            public string City { get; set; }

            public string County { get; set; }

            public string ZipCode { get; set; }
            public bool IsUserGarage { get; set; }
            public string AdvertId { get; set; }
            public string Image { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.County).NotEmpty();
                RuleFor(x => x.IsUserGarage).NotEmpty();
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
                var profile = new UserProfileDetails
                {
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    CompanyName = request.CompanyName,
                    ProfileDescription=request.ProfileDescription,
                    URL = request.URL,
                    Birthday = request.Birthday,
                    Street = request.Street,
                    City = request.City,
                   County=request.County,
                   ZipCode=request.ZipCode,
                   IsUserGarage=request.IsUserGarage,
                   AdvertId=request.AdvertId,
                   Image=request.Image
                };

                _context.AppUsersProfiles.Add(profile);

                var user = await _context.Users.SingleOrDefaultAsync(x =>
                    x.UserName == _userAccessor.GetCurrentUsername());

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
