using Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Seciurity
{
    public class IsAdvertCreatorRequirment : IAuthorizationRequirement
    {
    }

    public class IsAdvertCreatorRequirementHandler : AuthorizationHandler<IsAdvertCreatorRequirment>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        public IsAdvertCreatorRequirementHandler(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdvertCreatorRequirment requirement)
        {
            if (context.Resource is AuthorizationFilterContext authContext)
            {
              
                // get the auth current user name
                var currentUserName = _httpContextAccessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                // get the edited ad id
                var advertId = Guid.Parse(authContext.RouteData.Values["id"].ToString());
                var ad = _context.Adverts.FindAsync(advertId).Result;

                // find edited ad
                var advertCreator = ad.UserAdvert;
                
                if (advertCreator?.AppUser?.UserName == currentUserName) 
                    context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
