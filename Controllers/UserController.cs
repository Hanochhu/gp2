using gp2.DTO;
using gp2.IService;
using gp2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gp2.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 用户登录接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<User> Login(User user)
        {
            return await _userService.Login(user);
            
        }

        /// <summary>
        /// 获取用户信息接口
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("userinfo")]
        public async Task<UserInfo> GetUserInfoById(int id)
        {
            return await _userService.GetUserInfoByIdAsync(id);

        }


    }
}
