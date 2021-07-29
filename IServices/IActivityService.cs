using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Models;

namespace gp2.IService
{
    public interface IActivityService 
    {

        /// <summary>
        /// 根据Actid返回活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Activity> FindActByKeyAsync(int id);

        List<Activity> FindActByUserId(int userId);

        List<Activity> GetAll();

    }
}
