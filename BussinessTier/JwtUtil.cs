using DataTier.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            SymmetricSecurityKey secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NumberOne"));
            var credentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256Signature);
            List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role,user.Role),
        };
            var expires = DateTime.Now.AddDays(10);
            var token = new JwtSecurityToken("A", null, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }
    }
}
