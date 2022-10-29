using BlazorApiBackend.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiBackend.Models;

namespace WebApiBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        #region fields

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        #endregion

        #region constructor

        public SecurityController(ILogger<PersonsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        #endregion

        #region APIs

        // POST api/<AuthenticationController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (login is null)
                return BadRequest("Invalid login request");

            if (login.UserName == "User123" && login.Password == "Pw123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: new List<Claim>()
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    },
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(tokenString);
            }

            return Unauthorized();
        }

        #endregion
    }
}
