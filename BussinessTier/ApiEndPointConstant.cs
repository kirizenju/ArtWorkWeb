using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier
{
    public static class ApiEndPointConstant
    {

        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public static class Authentication
        {
            public const string AuthenticationEndpoint = ApiEndpoint + "/auth";
            public const string Login = AuthenticationEndpoint + "/login";
        }
        public static class User
        {
            public const string UsersEndpoint = ApiEndpoint + "/users";
            public const string UserEndpoint = UsersEndpoint + "/{id}";
            //public const string UserUpdateEndpoint = UserEndpoint + "/roles";
        }
        public static class ArtWork
        {
            public const string ArtWorksEndPoint = ApiEndpoint + "/artworks";
            public const string ArtWorkEndPoint = ArtWorksEndPoint + "/{id}";
        }
    }
}
