using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDbAngDotNet.DataAccessLayer;
using MovieDbAngDotNet.Models;

namespace MovieDbAngDotNet.Controllers
{
   
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserDb userDataAccess;
        public UserController(IUserDb userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        [HttpGet("api/login")]
        public async Task<IActionResult> Login(string email,string password)
        {
            if(!userDataAccess.IsEmail(email)) return BadRequest();
            
            UserDb? user = await userDataAccess.Login(email, password);
            
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(user);
            }
            
        }

        [HttpPost("api/register")]
        public async Task<IActionResult> Register(string email,string name,string password)
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
    }
}
