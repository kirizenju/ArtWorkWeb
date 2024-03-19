using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload.User
{
    public class GetUserResponse
    {
        public int IdUser { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
