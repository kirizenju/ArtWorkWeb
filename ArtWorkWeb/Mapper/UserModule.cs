using AutoMapper;
using DataTier.Models;
using DataTier.View.User;
namespace ArtWorkWeb.Mapper
{
    public class UserModule : Profile
    {
        public UserModule()
        {
            CreateMap<UserProfileViewModel, User>().ReverseMap();
        }
    }
}
