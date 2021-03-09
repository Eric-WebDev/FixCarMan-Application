using FluentValidation;
using Identity.Application.Errors;
using Identity.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Adverts
{
    public class EditAd
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string CarModel { get; set; }
            public string Description { get; set; }
            public DateTime? Date { get; set; }
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
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var ad = await _context.Adverts.FindAsync(request.Id);

                if (ad == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Advert = "Not found" });

                ad.Title = request.Title ?? ad.Title;
                ad.Description = request.Description ?? ad.Description;
                ad.CarModel= request.CarModel ?? ad.CarModel;
                ad.Date = request.Date ?? ad.Date;
                ad.City = request.City ?? ad.City;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }

    }
}
