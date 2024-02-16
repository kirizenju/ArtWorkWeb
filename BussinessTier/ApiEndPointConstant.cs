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

        public static class Category
        {
            public const string CategoriesEndPoint = ApiEndpoint + "/categories";
            public const string CategoryEndPoint = CategoriesEndPoint + "/{id}";
        }
        public static class Product
        {
            public const string ProductsEndPoint = ApiEndpoint + "/products";
            public const string ProductEndPoint = ProductsEndPoint + "/{id}";
        }

        public static class ProductRetail
        {
            public const string ProductRetailsEndPoint = ApiEndpoint + "/productRetails";
            public const string ProductRetailEndPoint = ProductRetailsEndPoint + "/{id}";
        }

        public static class ProductReview
        {
            public const string ProductReviewsEndPoint = ApiEndpoint + "/productReviews";
            public const string ProductReviewEndPoint = ProductReviewsEndPoint + "/{id}";
        }

        public static class Order
        {
            public const string OrdersEndPoint = ApiEndpoint + "/orders";
            public const string OrderEndPoint = OrdersEndPoint + "/{id}";
        }

        public static class User
        {
            public const string UsersEndPoint = ApiEndpoint + "/users";
            public const string UserEndPoint = UsersEndPoint + "/{id}";
            public const string UserPhoneEndPoint = UsersEndPoint + "/phoneNumber";
            public const string UserLoginEndPoint = UsersEndPoint + "/login";
        }
    }
}
