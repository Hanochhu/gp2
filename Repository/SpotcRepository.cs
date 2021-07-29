using gp2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    
    public class SpotcRepository : Repository<Spotcollection>
    {
        private readonly Gp2Context _gp2Context;

        public SpotcRepository(Gp2Context gp2Context) : base(gp2Context)
        {
            _gp2Context = gp2Context;
        }

       /// <summary>
       /// 根据用户id查找景点
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
        public IEnumerable<Spotcollection> FindListByUserId(int userId)
        {   
            return _gp2Context.Spotcollections.Where(p => p.SpotcUserid == userId);
        }


    }
}
