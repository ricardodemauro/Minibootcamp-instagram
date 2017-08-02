using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public string PicIdentity { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}
