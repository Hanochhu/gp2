using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.IService;
using gp2.Models;
using gp2.Repository;

namespace gp2.Services
{
    public class StrategyService : IStrategyService
    {
        private readonly StrategyRepository _strategyRepository;
        private readonly UserRepository _userRepository;

        public StrategyService(StrategyRepository strategyRepository, UserRepository userRepository)
        {
            _strategyRepository = strategyRepository;
            _userRepository = userRepository;
        }


        /// <summary>
        /// 创建一个新的游记
        /// </summary>
        /// <param name="strategy"></param>
        public void Create(Strategy strategy)
        {
            _strategyRepository.Add(strategy);
        }

        /// <summary>
        /// 获取所有游记
        /// </summary>
        /// <returns></returns>
        public List<Strategy> GetAll()
        {
           return _strategyRepository.GetAll().ToList();
        }

        /// <summary>
        /// 获取用户发布的游记
        /// </summary>
        /// <param name="userPhone"></param>
        /// <returns></returns>
        public async Task<List<Strategy>> FindStaByUserIdAsync(User user)
        {
            User u =await _userRepository.FindByPhoneAsync(user.UserPhone);

            return _strategyRepository.FindListByUserId(u.UserId).ToList();
        }


        /// <summary>
        /// 根据主键查找游记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Strategy> FindStaByKeyAsync(int id)
        {
           return await _strategyRepository.FindAsync(id);
        }
    }
}
