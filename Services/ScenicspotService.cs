using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.IService;
using gp2.Models;
using gp2.Repository;

namespace gp2.Services
{
    public class ScenicspotService : IScenicspotService
    {
        private readonly IRepository<Scenicspot> _scenicSpotRepository;

        public ScenicspotService(IRepository<Scenicspot> scenicSpotRepository)
        {
            _scenicSpotRepository = scenicSpotRepository;
        }

        public IEnumerable<Scenicspot> GetAllSpots()
        {
            return _scenicSpotRepository.GetAll();
        }

        /// <summary>
        /// 根据景点id查找景点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Scenicspot> GetScenic(int id)
        {
            return await _scenicSpotRepository.FindAsync(id);
        }
    }
}
