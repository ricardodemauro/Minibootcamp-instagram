using DotnetCamp.Instagram.Domain.Interfaces.Repositories;
using DotnetCamp.Instagram.Repository.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCamp.Instagram.Repository
{
    public static class DIConfig
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IPictureRepository, EfPictureRepository>();
        }
    }
}
