using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessTier.Enums;
namespace BussinessTier.Payload
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public UserResponse UserInfo { get; set; }
    }

    public class UserResponse
    {
        public Guid IdUser { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public RoleEnum Role { get; set; }
    }
}
