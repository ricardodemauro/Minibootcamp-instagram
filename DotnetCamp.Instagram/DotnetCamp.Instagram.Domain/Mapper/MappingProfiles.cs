using AutoMapper;
using DotnetCamp.Instagram.Domain.Entities;
using DotnetCamp.Instagram.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Domain.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PictureDTO, Picture>().ReverseMap();
        }
    }
}
