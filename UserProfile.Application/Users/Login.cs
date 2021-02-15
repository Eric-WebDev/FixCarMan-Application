using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UserProfile.Application.Errors;
using UserProfile.Application.Interfaces;
using UserProfile.Domain;

namespace UserProfile.Application
{
    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<Domain.AppUser> _userManager;
            private readonly SignInManager<Domain.AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            public Handler(UserManager<Domain.AppUser> userManager, SignInManager<Domain.AppUser> signInManager, IJwtGenerator jwtGenerator)
            {
                _jwtGenerator = jwtGenerator;
                _signInManager = signInManager;
                _userManager = userManager;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                    throw new RestException(HttpStatusCode.Unauthorized);

                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    // TODO: generate token
                    return new User
                    {
                        UserName = user.UserName,
                        Token = _jwtGenerator.CreateToken(user)
                    };
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}