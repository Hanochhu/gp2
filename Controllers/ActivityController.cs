using gp2.IService;
using gp2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace gp2.Controllers
{
    [ApiController]
    [Route("api/act")]
    public class ActivityController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// 根据id查找活动
        /// </summary>
        /// <param name="actId"></param>
        /// <returns></returns>
        [HttpGet("activity")]
        public async Task<Activity> FindActByKeyAsync(int actId)
        {
            return await _activityService.FindActByKeyAsync(actId);
        }


        /// <summary>
        /// 根据用户id获得活动列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("person")]
        public List<Activity> FindActListByUserId(int userId)
        {
            return _activityService.FindActByUserId(userId);
        }

        /// <summary>
        /// 获得所有活动
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public List<Activity> GetAll()
        {
            return _activityService.GetAll();
        }


    }
}
