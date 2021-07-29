using gp2.DTO;
using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.IService
{
    public interface IUserService 
    {
        Task<User> Login(User user);

        Task<UserInfo> GetUserInfoByIdAsync(int id);

        Task<bool> IsCorrectPwdAsync(string phone,string password);

        Task<User> FindUserByPhoneAsync(string phone);
    }
}
