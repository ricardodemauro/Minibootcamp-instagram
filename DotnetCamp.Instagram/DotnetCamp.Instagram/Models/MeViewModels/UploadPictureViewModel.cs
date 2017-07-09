using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Models.MeViewModels
{
    public class UploadPictureViewModel
    {
        public string Description { get; set; }

        public IFormFile Picture { get; set; }
    }
}
