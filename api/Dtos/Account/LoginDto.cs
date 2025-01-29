using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Dtos.Account
{
    public class LoginDto
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}