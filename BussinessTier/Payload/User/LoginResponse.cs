using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessTier.Enums;
namespace BussinessTier.Payload.User
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public UserResponse UserInfo { get; set; }
    }

    public class UserResponse
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = null!;
        public RoleEnum Role { get; set; }
    }
}
