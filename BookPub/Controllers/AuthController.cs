using BookPubDB.Model.Identity;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/member[@name="T:BookPub.Controllers.AuthController"]' />
    [ApiController]
    [Route("api/authenticate")]
    public class AuthController : ControllerBase
    {
        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/member[@name="F:BookPub.Controllers.AuthController.UserManager"]' />
        private readonly UserManager<IdentityUser> UserManager;

        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/member[@name="F:BookPub.Controllers.AuthController.SignInManager"]' />
        private readonly SignInManager<IdentityUser> SignInManager;

        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/member[@name="F:BookPub.Controllers.AuthController.Repository"]' />
        private readonly UserRepository Repository;

        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/member[@name="C:BookPub.Controllers.AuthController"]' />
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Repository = new();
        }

        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/methods/member[@name="M:BookPub.Controllers.AuthController.Register"]' />
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

        /// <include file='Documentation/Controllers/AuthController.xml' path='doc/authcontroller/methods/member[@name="M:BookPub.Controllers.AuthController.Login"]' />
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
