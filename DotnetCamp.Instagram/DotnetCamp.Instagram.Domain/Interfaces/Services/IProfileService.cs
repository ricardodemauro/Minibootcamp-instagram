using DotnetCamp.Instagram.DTO;
using DotnetCamp.Instagram.DTO.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<PictureDTO> AddPicture(CreatePictureDTO data);

        Task<IEnumerable<PictureDTO>> GetPicturesStream(int page);
    }
}
