using BookPubDB.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookPubDB.Repositories
{
    /// <include file = 'Documentation/Repositories/UserRepository.xml' path='doc/userrepository/member[@name="T:BookPubDB.Repositories.UserRepository"]' />
    public class UserRepository
    {
        /// <include file = 'Documentation/Repositories/UserRepository.xml' path='doc/userrepository/member[@name="M:BookPubDB.Repositories.UserRepository.DetermineLogin(BookPubDB.Model.Identity.LoginUser,Microsoft.AspNetCore.Identity.UserManager{Microsoft.AspNetCore.Identity.IdentityUser})"]' />
        public async Task<IdentityUser?> DetermineLogin(LoginUser model, UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByEmailAsync(model.Login);

            if (user == null)
            {
                user = await userManager.FindByNameAsync(model.Login);
            }

            return user!;
        }

        /// <include file = 'Documentation/Repositories/UserRepository.xml' path='doc/userrepository/member[@name="M:BookPubDB.Repositories.UserRepository.GenerateJwtToken(Microsoft.AspNetCore.Identity.IdentityUser,Microsoft.Extensions.Configuration.IConfiguration)"]' />
        public string GenerateJwtToken(IdentityUser user, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpirationMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}