using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetCamp.Instagram.Storage;
using System.IO;
using System.Net.Http;
using System.Net;
using Microsoft.Net.Http.Headers;

namespace DotnetCamp.Instagram.Controllers
{
    public class PicController : Controller
    {
        private readonly IStorageService _fileStorage;

        public PicController(IStorageService fileStorage)
        {
            _fileStorage = fileStorage;
        }

        [Route("pic/{name}")]
        public IActionResult Index(string name)
        {
            Stream fs = _fileStorage.GetStream(name);

            return File(fs, "image/jpg");
        }
    }
}