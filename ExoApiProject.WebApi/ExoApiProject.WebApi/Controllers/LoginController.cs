using ExoApiProject.WebApi.Interfaces;
using ExoApiProject.WebApi.Models;
using ExoApiProject.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExoApiProject.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        public LoginController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        [HttpPost]
       public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User researchedUser = _iUserRepository.Login(login.Email, login.Password);

                if (researchedUser == null)
                {
                    return Unauthorized(new { msg = "Email or Password incorret!"});
                }
                var myClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, researchedUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, researchedUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, researchedUser.Category)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapiproject-key-authenticator"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                    issuer: "ExoApiProject.WebApi",
                    audience: "ExoApiProject.WebApi",
                    claims: myClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                    );
                return Ok(
                    new { token = new JwtSecurityTokenHandler().WriteToken(myToken) 
                    });

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
