using FluentValidation;
using Identity.Application.Interfaces;
using Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Profiles
{
    public class Edit
    {
        public class Command : IRequest
        {            
            public string Username { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string CompanyName { get; set; }

            public string ProfileDescription { get; set; }

            //public string URL { get; set; }

            //public DateTime? Birthday { get; set; }

            public string Street { get; set; }

            public string City { get; set; }

            public string County { get; set; }

            //public string ZipCode { get; set; }
            //public bool IsUserGarage { get; set; }
            //public string AdvertId { get; set; }
            public string Image { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Username).NotEmpty();
             
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

                //user.UserName = request.Username ?? user.UserName;

                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;
                user.CompanyName = request.CompanyName ?? user.CompanyName;
                user.ProfileDescription = request.ProfileDescription ?? user.ProfileDescription;
                user.Street = request.Street ?? user.Street;
                user.City = request.Street ?? user.Street;
                user.County = request.County ?? user.County;
                //user.Image = request.Image ?? user.Image;
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
