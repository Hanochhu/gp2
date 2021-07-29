using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    public class ActcollectionRepository : Repository<ActcollectionRepository>
    {
        private readonly Gp2Context _gp2Context;
        public ActcollectionRepository(Gp2Context gp2Context) : base(gp2Context)
        {
            _gp2Context = gp2Context;
        }

       

        /// <summary>
        /// 根据userid查找用户收藏活动的记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Actcollection> FindListByUserId(int userId)
        {
            return _gp2Context.Actcollections.Where(p => p.ActcUserid == userId);
        }



    }
}
