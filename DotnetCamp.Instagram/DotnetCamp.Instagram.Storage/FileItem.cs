using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Storage
{
    public class FileItem
    {
        public string Name { get; set; }

        public byte[] Blob { get; set; }
    }
}
