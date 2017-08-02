using DotnetCamp.Instagram.Domain.Interfaces.Identity;
using DotnetCamp.Instagram.Identity.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Identity
{
    public static class DIConfig
    {
        public static void AddCurrentUserService(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUserService, UserService>();
        }
    }
}
