using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    public class StrategyRepository : Repository<Strategy>
    {
        private readonly Gp2Context _gp2Context;
        public StrategyRepository(Gp2Context gp2Context) : base(gp2Context)
        {
            _gp2Context = gp2Context;
        }

        /// <summary>
        /// 根据用户id查找游记
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Strategy> FindListByUserId(int userId)
        {
            return _gp2Context.Strategies.Where(p => p.StaWriter == userId);
        }

    }
}
