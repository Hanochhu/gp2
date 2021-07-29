using gp2.IService;
using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using gp2.Repository;
using AutoMapper;
using gp2.DTO;

namespace gp2.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据电话找user
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<User> FindUserByPhoneAsync(string phone)
        {

            return await _userRepository.FindByPhoneAsync(phone);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoByIdAsync(int id)
        {
            User u = await _userRepository.FindAsync(id);
            UserInfo userInfo = _mapper.Map<UserInfo>(u);
            if (userInfo != null)
            {
                return userInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 验证账号密码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> IsCorrectPwdAsync(string phone, string password)
        {
         
            User user=await _userRepository.FindByPhoneAsync(phone);
            if (user != null)
            {
                if (user.UserPassword.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// @TODO
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> Login(User user)
        {
            User u = await _userRepository.FindByPhoneAsync(user.UserPhone);
            if (u != null && u.UserPassword.Equals(user.UserPassword))
            {
                return u;
            }
            else
            {
                return null;
            }

        }

        
    }
}
