

using FluentValidation;
using Identity.Application.Interfaces;
using Identity.Data;
using Identity.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Adverts
{
    public class CreateAd
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string CarModel { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.CarModel).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
 
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
                var advert= new Advert
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    CarModel = request.CarModel,
                    Date = request.Date,
                    City = request.City
                  
                };

                _context.Adverts.Add(advert);

                var user = await _context.Users.SingleOrDefaultAsync(x =>
                    x.UserName == _userAccessor.GetCurrentUsername());

                var userAd = new UserAdvert
                {
                    AppUser = user,
                    Advert = advert,
                    DatePublished = DateTime.Now
                };

                _context.UserAdverts.Add(userAd);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
