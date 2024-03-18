using DataTier.View.Common;
using DataTier.View.Product;
using DataTier.View.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repository.Interface
{
    public interface IUserRepository
    {
        bool DeleteUser(int id);
        Models.User? GetUserByID(int userid);
        bool UpdateProfile(ProfileUpdateRequest model);
    }
}
