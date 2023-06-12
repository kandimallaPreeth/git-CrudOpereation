using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRUDOperations_WebAPI.Models;

namespace CRUDOperations_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        //frombody:"shoud be bound with the request body"
        public IActionResult Login([FromBody] Login user)
        {
            try
            {

                if (user is null)
                {
                    return BadRequest("Invalid client request");
                }
                if (user.UserName == "abc" && user.Password == "abc@123")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    //symmetricsecuritykey used to signing and validation
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    //signingcredentials is used to spcifty signing key ,indtify singing key
                    var tokeOptions = new JwtSecurityToken(
                        //jwtsecurity is the open industry standard used to share infomation b/w clint & sever 
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        //if the values are not null then for each claims store in the key,value pair.duplicates are found store in key ,list 
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        //signingcredentials used to sign into the token
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new Response { Token = tokenString });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

