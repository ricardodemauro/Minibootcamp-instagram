using System;
using System.IO;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Storage
{
    public interface IFileStorage
    {
        Task AddAsync(params FileItem[] files);

        Task AddAsync(string name, Stream stream);

        Task<FileItem> GetAsync(string name);

        Stream GetStream(string name);
    }
}
