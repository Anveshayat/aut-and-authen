using aut_and_authen.AppModels;
using aut_and_authen.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aut_and_authen.Repository
{
    public class RepClass
    {
        public readonly IConfiguration _configuration;
        public RepClass(IConfiguration confi)
        {
            _configuration = confi;
        }
        public static Anu login(PropertiesClass models)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var record = db.Anus.Where(a => a.Email == models.Email && a.Passeord == models.password).FirstOrDefault();
                if (record != null)
                {
                    return record;
                }
                return null;
            }
        }
        public string Getoken(Anu token)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var cred = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, token.Role),
        };
            var Token = new JwtSecurityToken
            (_configuration["jwt:issuer"],
            _configuration["jwt:key"],
            null,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(Token);
                

        }
    }
}
