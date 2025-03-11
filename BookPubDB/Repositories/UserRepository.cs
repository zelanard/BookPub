using BookPubDB.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookPubDB.Repositories
{
    public class UserRepository
    {
        public async Task<IdentityUser?> DetermineLogin(LoginUser model, UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByEmailAsync(model.Login);

            if (user == null)
            {
                user = await userManager.FindByNameAsync(model.Login);
            }

            return user!;
        }

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
