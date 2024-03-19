using ArtWorkWeb.Service.Interfaces;
using AutoMapper;
using BussinessTier;
using BussinessTier.Enums;
using BussinessTier.Payload;
using DataTier.Models;
using DataTier.Repository.Interface;
using DataTier.View.Common;
using DataTier.View.User;
using System;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ArtWorkWeb.Service.Implement
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<UserService> logger, IUserRepository userRepository, IMapper mapper) : base(unitOfWork, logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool BanUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public KeyValuePair<MessageViewModel, List<UserProfileViewModel>> GetAllUser()
        {
            var users = _userRepository.GetAllUser();
            if (users == null)
            {
                return new KeyValuePair<MessageViewModel, List<UserProfileViewModel>>(
                    new MessageViewModel
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        Message = string.Empty,
                    },null
                    );
            }
            return new KeyValuePair<MessageViewModel, List<UserProfileViewModel>>(
                new MessageViewModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = string.Empty,
                }, users
                );
        }

        public KeyValuePair<MessageViewModel, UserProfileViewModel> GetUser(int id)
        {
            var user = _userRepository.GetUserByID(id);
            if (user == null)
            {
                return new KeyValuePair<MessageViewModel, UserProfileViewModel>
                    (
                    new MessageViewModel
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        Message = "Not found this user"
                    },
                    null
                    );
            }
            var reponse = _mapper.Map<UserProfileViewModel>(user);
            return new KeyValuePair<MessageViewModel, UserProfileViewModel>(
                new MessageViewModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = string.Empty
                }, reponse
                );
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
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

        public MessageViewModel UpdateProfile(ProfileUpdateRequest model)
        {
            var success = _userRepository.UpdateProfile(model);

            if (success)
            {
                return new MessageViewModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Profile updated successfully"
                };
            }
            else
            {
                return new MessageViewModel
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "User not found or profile update failed"
                };
            }
        }
    }
}
