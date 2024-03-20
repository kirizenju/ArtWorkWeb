using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Constants
{
    public static class MessageConstant
    {
        public static class LoginMessage
        {
            public const string InvalidUsernameOrPassword = "Tên đăng nhập hoặc mật khẩu không chính xác";
            public const string DeactivatedAccount = "Tài khoản đang bị vô hiệu hoá";
        }
        public static class ArtWork
        {
            public const string ArtWorkNameExisted = "ArtWork đã tồn tại";
            public const string CreateNewArtWorkFailedMessage = "Tạo mới ArtWork thất bại";
            public const string UpdateArtWorkFailedMessage = "Cập nhật thông tin ArtWork thất bại";
            public const string UpdateArtWorkSuccessMessage = "Cập nhật thông tin ArtWork thành công";
            public const string EmptyArtWorkIdMessage = "ArtWork Id không hợp lệ";
            public const string ArtWorkNotFoundMessage = "ArtWork không tồn tại trong hệ thống";
            public const string UpdateStatusSuccessMessage = "Cập nhật trạng thái thành công";
            public const string UpdateStatusFailedMessage = "Cập nhật trạng thái thất bại";
          

        }
        public static class Sub
        {
            public const string SubNameExisted = "Subscription đã tồn tại";
            public const string CreateNewSubFailedMessage = "Tạo mới Subscription thất bại";
            public const string UpdateSubFailedMessage = "Cập nhật thông tin Subscriptionthất bại";
            public const string UpdateSubSuccessMessage = "Cập nhật thông tin Subscription thành công";
            public const string EmptySubIdMessage = "Subscription Id không hợp lệ";
            public const string SubNotFoundMessage = "Subscription không tồn tại trong hệ thống";
            public const string UpdateSuccessMessage = "Cập nhật trạng thái thành công";
            public const string UpdateFailedMessage = "Cập nhật trạng thái thất bại";


        }
    }
}
