using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Services
{
    public class FileService : IFileService
    {
        private readonly string _baseDirectory;

        public FileService(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        public async Task SaveAsync(Stream file, string filename)
        {
            string fullpath = Path.Combine(_baseDirectory, filename);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
            }
            using (FileStream fs = new FileStream(fullpath, FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    await file.CopyToAsync(writer.BaseStream);
                    
                }
            }
        }
    }
}
