using DataTier.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace BussinessTier
{
    public class JwtUtil
    {
        private JwtUtil()
        {

        }

        public static string GenerateJwtToken(User user)
        {
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

            // Tạo một chuỗi khóa ngẫu nhiên có độ dài là 32 bytes (256 bits)
            byte[] keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }
            string base64Key = Convert.ToBase64String(keyBytes);

            // Sử dụng chuỗi khóa để tạo SymmetricSecurityKey
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(base64Key));

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            List<Claim> claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Role, user.Role),
    };

            var expires = DateTime.Now.AddDays(10);
            var token = new JwtSecurityToken("A", null, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }

    }
}
