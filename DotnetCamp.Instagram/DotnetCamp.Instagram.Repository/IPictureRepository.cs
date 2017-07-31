using DotnetCamp.Instagram.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Repository
{
    public interface IPictureRepository
    {
        Task AddAsync(Picture data, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<Picture>> FindByUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
