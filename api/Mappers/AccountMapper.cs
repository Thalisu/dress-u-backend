using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Account;
using dress_u_backend.Models;

namespace dress_u_backend.Mappers
{
    public static class AccountMapper
    {
        public static UserDto ToUserDto(this AppUser user, string token)
        {
            if (user.Email == null || user.UserName == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = token
            };
        }
    }
}