using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}
