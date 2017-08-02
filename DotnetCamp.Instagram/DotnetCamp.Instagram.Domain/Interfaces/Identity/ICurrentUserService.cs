using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Domain.Interfaces.Identity
{
    public interface ICurrentUserService
    {
        string GetUserId();

        bool IsLogged();
    }
}
