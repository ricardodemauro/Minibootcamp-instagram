using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.DTO.Profile
{
    public class CreatePictureDTO
    {
        public Stream Picture { get; set; }

        public string Description { get; set; }

        public string Extension { get; set; }
    }
}
