using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class HasPermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly string _permission;

        public HasPermissionAttribute(string permission)
        {
            _permission = permission;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user == null || !user.Identity?.IsAuthenticated == true)
            {
                context.Result = new ChallengeResult();
                return;
            }

            bool hasPermission = user.Claims.Any(c => c.Type == "Permission" && c.Value == _permission);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}