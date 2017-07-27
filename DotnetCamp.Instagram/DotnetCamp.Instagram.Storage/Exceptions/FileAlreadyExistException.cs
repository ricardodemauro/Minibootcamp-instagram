using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Storage.Exceptions
{
    public class FileAlreadyExistException : Exception
    {
        public FileAlreadyExistException(string filename)
            : base($"File {filename} already exist")
        {
        }
    }
}
