using DotnetCamp.Instagram.Identity;
using DotnetCamp.Instagram.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ControllerBase(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected string GetUserId()
        {
#if DEBUG
            return "USER";
#else
            return _userManager.GetUserId(HttpContext.User);
#endif
        }
    }
}
