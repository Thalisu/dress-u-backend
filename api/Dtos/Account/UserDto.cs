using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Dtos.Account
{
    public class UserDto
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Token { get; set; } = "";
    }
}