using DotnetCamp.Instagram.Domain.Entities;
using DotnetCamp.Instagram.Domain.Interfaces.Repositories;
using DotnetCamp.Instagram.Repository.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Repository.EntityFramework
{
    public class EfPictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPictureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Picture data, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Picture.Add(data);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Picture>> FindByUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbContext.Picture
                .Where(e => e.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}
