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
        Task<IPaginate<GetUserResponse>> GetAllUsers(UserFilter filter, PagingModel pagingModel);
        KeyValuePair<MessageViewModel, UserProfileViewModel> GetUser(int id);
        Task<LoginResponse> Login(LoginRequest loginRequest);

        MessageViewModel UpdateProfile(ProfileUpdateRequest model);
    }
}