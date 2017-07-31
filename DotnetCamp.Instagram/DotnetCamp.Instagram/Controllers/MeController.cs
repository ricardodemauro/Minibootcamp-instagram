using DotnetCamp.Instagram.Identity;
using DotnetCamp.Instagram.Models;
using DotnetCamp.Instagram.Models.MeViewModels;
using DotnetCamp.Instagram.Repository;
using DotnetCamp.Instagram.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Controllers
{
    public class MeController : ControllerBase
    {
        private const string ME_ACTION = "Me";

        private readonly IFileStorage _fileService;
        private readonly IPictureRepository _pictureRepository;
        private readonly ILogger _logger;

        public MeController(IFileStorage fileService,
            IPictureRepository pictureRepository,
            UserManager<ApplicationUser> userManager,
            ILogger<MeController> logger)
            : base(userManager)
        {
            _fileService = fileService;
            _pictureRepository = pictureRepository;
        }

        [HttpGet(Name = ME_ACTION)]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var picColl = await _pictureRepository.FindByUserAsync(userId);
            return View(picColl);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(UploadPictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Stream fs = model.Picture.OpenReadStream())
                {
                    await _fileService.AddAsync(model.Picture.FileName, fs);
                }
                var picture = new Picture
                {
                    Date = DateTime.UtcNow,
                    Description = model.Description,
                    UserId = GetUserId(),
                    FilePath = $"/pic/{model.Picture.FileName}"
                };
                await _pictureRepository.AddAsync(picture);
            }

            return RedirectToAction(nameof(Index));
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

                    using (Stream fs = file.OpenReadStream())
                    {
                        await _fileService.AddAsync(file.FileName, fs);
                    }
                    var picture = new Picture
                    {
                        Date = DateTime.UtcNow,
                        Description = file.FileName,
                        UserId = GetUserId(),
                        FilePath = $"/pic/{file.FileName}"
                    };
                    await _pictureRepository.AddAsync(picture);
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