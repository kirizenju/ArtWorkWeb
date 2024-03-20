using DataTier.Models;
using DataTier.View.User;

namespace DataTier.Repository.Interface
{
    public interface IUserRepository
    {
        bool DeleteUser(int id);
        List<UserProfileViewModel> GetAllUser();
        User GetUserByEmail(string? email);
        Models.User? GetUserByID(int userid);
        User GetUserByUsername(string username);
        Task<User> Register(User user);
        bool UpdateProfile(ProfileUpdateRequest model);
    }
}
