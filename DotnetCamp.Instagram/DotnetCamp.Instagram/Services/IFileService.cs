using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Services
{
    public interface IFileService
    {
        Task SaveAsync(Stream file, string filename);
    }
}
