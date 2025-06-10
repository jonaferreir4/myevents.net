using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Library.Utils.Authorization
{
    public class AuthorizationHelper
    {
        public static long GetAuthenticatedUserId(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            var subClaim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier) 
                ?? httpContextAccessor.HttpContext.User.FindFirst("sub");

            if (subClaim == null || !long.TryParse(subClaim.Value, out var user) || user <= 0)
            {
                throw new UnauthorizedAccessException("Invalid user identifier");
            }

            return user;
        }
    }
}