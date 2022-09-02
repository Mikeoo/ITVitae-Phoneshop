using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Phoneshop.Domain.Interfaces;
using PhoneShop.api.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace PhoneShop.api.Controllers
{
    public class UserControllerJwt : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UserControllerJwt(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ITokenService tokenService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        [Route("RegisterJwt")]
        public async Task<IActionResult> Register([FromBody] UserDetails userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }
        
            var identityUser = new IdentityUser() { UserName = userDetails.UserName, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, identityUser.Id),
                new(ClaimTypes.Role, "User"),
                new(ClaimTypes.Email, identityUser.Email),
                new(ClaimTypes.Name, identityUser.UserName)
            };
            await _userManager.AddClaimsAsync(identityUser, claims);

            return Ok(new { Message = "User Registration Successful" });
        }

        [HttpPost]
        [Route("LoginJwt")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            if (!ModelState.IsValid || credentials == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var identityUser = await _userManager.FindByNameAsync(credentials.Username);
            if (identityUser == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var result =
                _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash,
                    credentials.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var userClaims = (List<Claim>)await _userManager.GetClaimsAsync(identityUser);
            var token = _tokenService.Generate(userClaims);

            if (await _signInManager.PasswordSignInAsync(identityUser, credentials.Password, true, false) == SignInResult.Success)
                return Ok(new { Message = "Success", Token = token, Role = userClaims[1].Value });

            return BadRequest("Failed to login");
        }

    }
}