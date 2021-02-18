using Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Seciurity
{
    public class IsGarageRequirement : IAuthorizationRequirement
    {
    }

    public class IsGarageRequirementHandler : AuthorizationHandler<IsGarageRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        public IsGarageRequirementHandler(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsGarageRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext authContext)
            {
                var currentUserName = _httpContextAccessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var UserProfileId = Guid.Parse(authContext.RouteData.Values["id"].ToString());

                var userProfileDetails = _context.AppUsersProfiles.FindAsync(UserProfileId).Result;
                if (userProfileDetails.IsUserGarage == true)
                {
                    var garage = userProfileDetails;
                    if (garage?.AppUser?.UserName == currentUserName)
                        context.Succeed(requirement);
                }

            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
