using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configurationManager;
        public AuthController(IMediator mediator, IConfiguration configurationManager)
        {
            _mediator = mediator;
            _configurationManager = configurationManager;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest("Username and/or Password not specified");
                }
                var data = await _mediator.Send(new GetUserLoginQuery(request));

                if (data == null || data?.RequestCode == "404")
                {
                    return Unauthorized();
                    //return NotFound("not found username");
                }
                var result = data.Data;
                var secretKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(_configurationManager["JWT:Secret"]));
                var signinCredentials = new SigningCredentials
               (secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim("username", result.UserName));
                claims.Add(new Claim("displayname", result.FirstName));
                claims.Add(new Claim("userid", result.Id.ToString()));

                claims.Add(new Claim(ClaimTypes.Role, result.UserRoles.RoleName));

                var jwtSecurityToken = new JwtSecurityToken(
                            issuer: _configurationManager["JWT:ValidAudience"],
                            audience: _configurationManager["JWT:ValidAudience"],
                            claims: claims,//new List<Claim>(),
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: signinCredentials
                        );

                var res = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                //string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
                return Ok(new UserLoginDtoResponse { Token = res });
            }
            catch(Exception err)
            {
                return BadRequest(new {Message = err.Message,StackTrace = err.StackTrace });
                //("An error occurred in generating the token");
            }

        }
    }
}
