using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.IService;
using gp2.Models;
using gp2.Repository;

namespace gp2.Services
{
    public class SpotcollectionService : ISpotcollectionService
    {
        private readonly SpotcRepository _spotcRepository;
        private readonly IRepository<Scenicspot> _scenicSpotRepository;
       

        public SpotcollectionService(IRepository<Scenicspot> scenicSpotRepository, SpotcRepository spotcRepository)
        {
            _scenicSpotRepository = scenicSpotRepository;
            _spotcRepository = spotcRepository;
        }

        /// <summary>
        /// 获取用户收藏的景点
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Scenicspot>> FindSpotByUserIdAsync(int userId)
        {
            //根据用户id查找到该用户收藏的景点list
            List<Spotcollection> list = _spotcRepository.FindListByUserId(userId).ToList();
            //景点结果集
            List<Scenicspot> res = new List<Scenicspot>();
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int sid= (int)list[i].SpotcSpotid;
                    res.Add(await _scenicSpotRepository.FindAsync(sid));
                }
            }
            return res;

        }

        
    }
}
