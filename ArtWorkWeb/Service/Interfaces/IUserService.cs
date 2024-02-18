using BussinessTier.Payload;
using DataTier.Repository.Implement;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}