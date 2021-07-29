using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Models;

namespace gp2.IService
{
    public interface IActcollectionService
    {

        /// <summary>
        /// 根据用户id查找活动列表
        /// </summary>
        /// <param name="actcollection"></param>
        /// <returns></returns>
        List<Activity> FindActByUserId(Actcollection actcollection);
        


    }
}
