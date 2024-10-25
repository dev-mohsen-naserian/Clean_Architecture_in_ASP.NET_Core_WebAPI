using Domain.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementation
{
    public class TokenService:ITokenService
    {
        #region Constructor
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            _configuration = configuration;
        }
        #endregion
        public string CreateToken(UserEntity user)
        {
            var claims = new List<Claim>()
            {
               // new Claim("UserId",user.Id.ToString()),
               // new Claim(JwtRegisteredClaimNames.NameId,user.UserName.ToString())
               new Claim(ClaimTypes.Name,user.UserName),
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Email,user.Email)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],claims,expires:DateTime.Now.AddDays(7),signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
