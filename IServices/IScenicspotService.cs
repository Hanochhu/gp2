using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Models;

namespace gp2.IService
{
    public interface IScenicspotService
    {
        /// <summary>
        /// 获取全部景点
        /// </summary>
        /// <returns></returns>
        IEnumerable<Scenicspot> GetAllSpots();

        Task<Scenicspot> GetScenic(int id);

    }
}
