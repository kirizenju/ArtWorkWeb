using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.View.User
{
    public class UserProfileViewModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
