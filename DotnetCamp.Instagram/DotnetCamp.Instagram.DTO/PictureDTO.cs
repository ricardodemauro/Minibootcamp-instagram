using System;

namespace DotnetCamp.Instagram.DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }

        public string PicIdentity { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}
