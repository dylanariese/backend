using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Coffee.Api.Authorization
{
    public class AdminEntryHandler : AuthorizationHandler<AdminEntryRequirement>
    {
        private readonly IConfiguration configuration;

        public AdminEntryHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminEntryRequirement requirement)
        {
            var authorized = context.User.IsInRole(configuration["ADBeheerGroup"]);

            if (authorized)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
