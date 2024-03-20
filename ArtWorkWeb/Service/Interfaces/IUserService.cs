using BussinessTier.Payload;
using BussinessTier.Payload.User;
using DataTier.Repository.Implement;
using DataTier.View.Common;
using DataTier.View.Product;
using DataTier.View.User;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface IUserService
    {
        bool BanUser(int id);

        KeyValuePair<MessageViewModel, UserProfileViewModel> GetUser(int id);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        KeyValuePair<MessageViewModel,List<UserProfileViewModel>> GetAllUser();
        MessageViewModel UpdateProfile(ProfileUpdateRequest model);
        Task<bool> Register(RegisterRequest request);
    }
}