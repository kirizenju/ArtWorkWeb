using BussinessTier.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload
{
    public class AccountRequest
    {

        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; }

        [EnumDataType(typeof(RoleEnum))]
        public RoleEnum Role { get; set; }
     
    }
}
