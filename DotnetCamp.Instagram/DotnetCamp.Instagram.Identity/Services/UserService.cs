using DotnetCamp.Instagram.Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Identity.Services
{
    public class UserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetUserId()
        {
#if DEBUG
            return "USER";
#else
            return _httpContext.HttpContext.User.Identity.Name;
#endif
        }

        public bool IsLogged()
        {
#if DEBUG
            return true;
#else
            return _httpContext.HttpContext.User.Identities.Any(x => x.IsAuthenticated);
#endif
        }
    }
}
