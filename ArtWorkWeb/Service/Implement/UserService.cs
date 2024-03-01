using ArtWorkWeb.Service.Interfaces;
using BussinessTier;
using BussinessTier.Enums;
using BussinessTier.Payload;
using DataTier.Models;
using DataTier.Repository.Interface;
using System.Linq.Expressions;
using System.Security.Principal;

namespace ArtWorkWeb.Service.Implement
{
    public class UserService : BaseService<UserService>, IUserService
    {
        public UserService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<UserService> logger) : base(unitOfWork, logger)
        {

        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            //string hashedPassword = PasswordUtil.HashPassword(loginRequest.Password);

            Expression<Func<User, bool>> searchFilter = p =>
                p.Username.Equals(loginRequest.Username) &&
                p.Password.Equals(loginRequest.Password);

            User user = await _unitOfWork.GetRepository<User>()
                .SingleOrDefaultAsync(predicate: searchFilter);

            if (user == null) return null;

            var token = JwtUtil.GenerateJwtToken(user);

            LoginResponse loginResponse = new LoginResponse()
            {
                AccessToken = token,
                UserInfo = new UserResponse()
                {
                    IdUser = user.IdUser,
                    Username = user.Username,
                    Role = EnumUtil.ParseEnum<RoleEnum>(user.Role),
                }
            };

            return loginResponse;
        }

    }
}