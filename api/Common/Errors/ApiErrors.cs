using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Common.Errors
{
    public class ApiErrors
    {
        public static Error NotFound(string what) => new(
            Code: "404", Message: $"{what} not found");
    }
}