using DotnetCamp.Instagram.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCamp.Instagram.DTO;
using DotnetCamp.Instagram.DTO.Profile;
using DotnetCamp.Instagram.Storage;
using DotnetCamp.Instagram.Domain.Interfaces.Repositories;
using DotnetCamp.Instagram.Domain.Entities;
using DotnetCamp.Instagram.Domain.Interfaces.Identity;
using AutoMapper;

namespace DotnetCamp.Instagram.Domain.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IStorageService _storageService;
        private readonly IPictureRepository _pictureRepository;
        private readonly ICurrentUserService _userService;
        private readonly IMapper _mapper;

        public ProfileService(IStorageService storageService,
            IPictureRepository pictureRepository,
            ICurrentUserService userService,
            IMapper mapper)
        {
            _storageService = storageService;
            _pictureRepository = pictureRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<PictureDTO> AddPicture(CreatePictureDTO data)
        {
            string fileName = GenerateRandomFileName(data.Extension);
            await _storageService.AddAsync(fileName, data.Picture);

            Picture picData = new Picture()
            {
                Date = DateTime.UtcNow,
                Description = data.Description,
                PicIdentity = fileName,
                UserId = _userService.GetUserId()
            };

            await _pictureRepository.AddAsync(picData);
            return _mapper.Map<Picture, PictureDTO>(picData);
        }

        public async Task<IEnumerable<PictureDTO>> GetPicturesStream(int page)
        {
            string userId = _userService.GetUserId();
            var picColl = await _pictureRepository.FindByUserAsync(userId);
            return _mapper.Map<IEnumerable<Picture>, IEnumerable<PictureDTO>>(picColl);
        }

        private string GenerateRandomFileName(string fileExtension)
        {
            return $"Guid.NewGuid().ToString().{fileExtension}";
        }
    }
}
