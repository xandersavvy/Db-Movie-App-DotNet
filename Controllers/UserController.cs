using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieDbAngDotNet.DataAccessLayer;
using MovieDbAngDotNet.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieDbAngDotNet.Controllers
{

    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserDb userDataAccess;
        private readonly IConfiguration configuration;
        public UserController(IUserDb userDataAccess, IConfiguration configuration)
        {
            this.userDataAccess = userDataAccess;
            this.configuration = configuration;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!userDataAccess.IsEmail(email)) return BadRequest();

            UserDb? user = await userDataAccess.Login(email, password);


            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new UserCreds(user.Email, CreateJWT(user.Email), user.Name));
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string name, string password)
        {
            bool userNoExist = await userDataAccess.UserAlreadyExists(email);
            if (userNoExist && userDataAccess.IsEmail(email) && userDataAccess.IsStrongPassword(password))
            {
                userDataAccess.Register(email, name, password);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private string CreateJWT(string userName)
        {
            string? secret = configuration["Jwt:Key"];
            if (secret == null) { secret = ""; }
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secret));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[] { new Claim(ClaimTypes.NameIdentifier, userName) };

            JwtSecurityToken token = new(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
