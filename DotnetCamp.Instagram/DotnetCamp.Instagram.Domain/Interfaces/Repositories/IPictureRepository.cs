using DotnetCamp.Instagram.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Domain.Interfaces.Repositories
{
    public interface IPictureRepository
    {
        Task AddAsync(Picture data, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<Picture>> FindByUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
