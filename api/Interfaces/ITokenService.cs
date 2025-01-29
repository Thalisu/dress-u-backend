using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Models;

namespace dress_u_backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}