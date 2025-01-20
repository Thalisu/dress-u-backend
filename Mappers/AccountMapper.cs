#pragma warning disable CS8601 // Possible null reference assignment.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Account;
using dress_u_backend.models;

namespace dress_u_backend.Mappers
{
    public static class AccountMapper
    {
        public static UserDto ToUserDto(this AppUser user, string token)
        {

            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = token
            };
        }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.