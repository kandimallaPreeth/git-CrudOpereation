using CRUDOperations_WebAPI.Data;
using CRUDOperations_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUDOperations_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class LoginController : Controller
    {
        private readonly ContextClass _context;
        public LoginController(ContextClass context)
        {
            _context = context;
        }
        [HttpPost("SigUp")]
        public async Task<IActionResult> Signup(SignUp signUp)
        {
            try
            {
               _context.SignUp.Add(signUp);
                _context.SaveChanges();
                return Ok(signUp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                if (login is null)
                {
                    return BadRequest("Invalid client request");
                }
                var user = _context.SignUp.Where(s =>
                                      s.Email.Contains(login.UserName) &&
                                      s.Password.Contains(login.Password)&&
                                      s.Role.Contains(login.Role));

                if (user !=null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Greeting")]
        public IActionResult Greetings()
        {
            return Ok("Hello User");
        }
    }
}
