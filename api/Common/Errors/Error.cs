using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Common.Errors
{
    public sealed record Error(string Code, string? Message = null)
    {
        public static readonly Error None = new("");
    }
}