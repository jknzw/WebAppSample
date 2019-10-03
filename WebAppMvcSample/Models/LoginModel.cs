using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvcSample.Models
{
    public class LoginModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string LableUserId { get; set; } = "UserId";
        public string LablePassword { get; set; } = "Password";
        public string LableLoginButton { get; set; } = "Login";
    }
}
