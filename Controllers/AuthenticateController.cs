using gp2.DTO;
using gp2.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace gp2.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthenticateController(IConfiguration configuration,
            IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            //1.验证用户名和密码
            

            if (!await _userService.IsCorrectPwdAsync(loginDto.Phone,loginDto.Password))
            {
                return BadRequest();
            }

            var user = await _userService.FindUserByPhoneAsync(loginDto.Phone);


            //2.创建JWT
            //header
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            //payload
            var claims = new[]
            {
                //sub
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString())
            };

            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials
             );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            //3.return 200ok +JWT
            return Ok(tokenStr);


        }


    }
}
