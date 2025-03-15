using BookPubDB.Model.Identity;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookPub.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserRepository Repository;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Repository = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok("User registration successfull");
            }
            return BadRequest(result.Errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser model, [FromServices] IConfiguration config)
        {
            IdentityUser? user = await Repository.DetermineLogin(model, UserManager);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid login attempt" });
            }

            var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid login attempt" });
            }

            // Generate JWT Token
            var token = Repository.GenerateJwtToken(user, config);

            return Ok(new
            {
                message = "Login successful",
                token
            });
        }
    }
}
