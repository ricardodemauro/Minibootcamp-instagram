using DotnetCamp.Instagram.Domain.Interfaces.Services;
using DotnetCamp.Instagram.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCamp.Instagram.Domain
{
    public static class DIConfig
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>();
        }
    }
}
