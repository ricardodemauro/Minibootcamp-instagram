using DotnetCamp.Instagram.Repository.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Repository
{
    public static class IoCConfig
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IPictureRepository, EfPictureRepository>();
        }
    }
}
