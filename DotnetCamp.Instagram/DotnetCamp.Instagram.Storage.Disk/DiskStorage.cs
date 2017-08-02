using DotnetCamp.Instagram.Storage.Exceptions;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Storage.Disk
{
    public class DiskStorage : IStorageService
    {
        private readonly string _baseDirectory;

        public DiskStorage(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        public async Task AddAsync(params FileItem[] files)
        {
            Guard.Null(files, nameof(files));

            Task[] taskColl = new Task[files.Length];

            foreach (FileItem file in files)
            {
                string fullPath = Path.Combine(_baseDirectory, file.Name);

                if (File.Exists(fullPath))
                    throw new FileAlreadyExistException(fullPath);

                using (MemoryStream memStream = new MemoryStream(file.Blob))
                using (FileStream fs = File.Create(fullPath))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        await memStream.CopyToAsync(writer.BaseStream);
                    }
                }
            }
        }

        public async Task AddAsync(string name, Stream stream)
        {
            Guard.StringNullOrEmpty(name, nameof(name));

            Guard.Null(stream, nameof(stream));

            Guard.FileFormat(name, nameof(name));

            string fullPath = Path.Combine(_baseDirectory, name);
            if (File.Exists(fullPath))
                throw new FileAlreadyExistException(fullPath);

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            using (FileStream fs = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(fs);
                await stream.CopyToAsync(writer.BaseStream);
            }
        }

        public Task<FileItem> GetAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Stream GetStream(string name)
        {
            Guard.StringNullOrEmpty(name, nameof(name));

            Guard.FileFormat(name, nameof(name));

            string fullPath = Path.Combine(_baseDirectory, name);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("File not found", name);

            FileStream fs = File.OpenRead(fullPath);
            return fs;
        }
    }
}
