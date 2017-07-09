using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetCamp.Instagram.Models.MeViewModels;
using DotnetCamp.Instagram.Models;
using DotnetCamp.Instagram.Services;
using DotnetCamp.Instagram.Data;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace DotnetCamp.Instagram.Controllers
{
    public class MeController : ControllerBase
    {
        private const string ME_ACTION = "Me";

        private readonly IFileService _fileService;
        private readonly ApplicationDbContext _dbContext;

        public MeController(IFileService fileService,
            ApplicationDbContext dbcontext,
            UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _fileService = fileService;
            _dbContext = dbcontext;
        }

        [HttpGet(Name = ME_ACTION)]
        public IActionResult Index()
        {
            var userId = GetUserId();
            var picColl = _dbContext.Picture
                .Where(p => p.UserId == userId)
                .ToList();
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
                var picture = new Picture
                {
                    Date = DateTime.UtcNow,
                    Description = model.Description,
                    UserId = GetUserId(),
                    FilePath = "/cdn/pic/" + model.Picture.FileName
                };

                using (Stream fs = model.Picture.OpenReadStream())
                {
                    await _fileService.SaveAsync(fs, model.Picture.FileName);
                }
                _dbContext.Picture.Add(picture);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}