using DotnetCamp.Instagram.Domain.Interfaces.Services;
using DotnetCamp.Instagram.DTO.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Controllers
{
    public class MeController : Controller
    {
        private const string ME_ACTION = "Me";

        private readonly IProfileService _profileService;
        private readonly ILogger _logger;

        public MeController(IProfileService profileService,
            ILogger<MeController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpGet(Name = ME_ACTION)]
        public async Task<IActionResult> Index(int page = 0)
        {
            var picColl = await _profileService.GetPicturesStream(page);
            return View(picColl);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (IFormFile file in Request.Form.Files)
                {
                    //Save file content goes here
                    fName = file.FileName;

                    CreatePictureDTO dto = new CreatePictureDTO();
                    dto.Description = fName;

                    using (Stream fs = file.OpenReadStream())
                    {
                        dto.Picture = file.OpenReadStream();
                    }

                    await _profileService.AddPicture(dto); ;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error trying to process {nameof(SaveUploadedFile)} method. Exception --> {ex.Message}");
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully)
            {
                return Ok(new { Message = fName });
            }
            else
            {
                return Ok(new { Message = "Error in saving file" });
            }
        }
    }
}