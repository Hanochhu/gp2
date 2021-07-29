using gp2.IService;
using gp2.Models;
using gp2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Controllers
{
    [ApiController]
    [Route("api/scenic")]
    public class ScenicspotController
    {
        private readonly IScenicspotService _scenicspotService;

        public ScenicspotController(IScenicspotService scenicspotService)
        {
            _scenicspotService = scenicspotService;
        }

        /// <summary>
        /// 获取所有景点信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        //[Authorize]
        public List<Scenicspot> GetAll()
        {
            return _scenicspotService.GetAllSpots().ToList();
        }

        /// <summary>
        /// 根据景点id查找景点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("scenic")]
        public async Task<Scenicspot> GetScenicAsync(int id)
        {
            var scenic =await _scenicspotService.GetScenic(id);
            if (scenic != null)
            {
                return scenic;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 景点页面搜索功能
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public List<Scenicspot> SearchScenic(String mes)
        {
            List<Scenicspot> list = _scenicspotService.GetAllSpots().ToList();
            List<Scenicspot> res = new List<Scenicspot>();
            for (int i = 0; i < list.Count; i++)
            {

                //先查询景点名称是否符合
                if (list[i].SpotName.Contains(mes)
                        || list[i].SpotCity.Contains(mes)
                )
                {
                    //如果景点名称或所在地符合加入到结果集
                    res.Add(list[i]);
                    continue;
                }
                //直辖市没有省份单独处理
                if (list[i].SpotProvince != null && !list[i].SpotProvince.Equals(""))
                {
                    if (list[i].SpotProvince.Contains(mes))
                    {
                        res.Add(list[i]);
                    }
                }
            }
            if (res.Count != 0)
            {
                return res;
            }
            else
            {
                return null;
            }



        }

        /// <summary>
        /// 地图周边景点推荐
        /// </summary>
        /// <param name="ScenicSpot"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("recommend")]
        public List<Scenicspot> Recommend(Scenicspot scenicSpot1)
        {
            List<Scenicspot> list = _scenicspotService.GetAllSpots().ToList();
            List<Scenicspot> res = new List<Scenicspot>();
            double lng = (double)scenicSpot1.SpotLng;
            double lat = (double)scenicSpot1.SpotLat;
            string lng1= lng.ToString("0.#");
            string lat1=lat.ToString("0.#");
            Console.Write(lng + " " + lat);

            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    double iLng = (double)list[i].SpotLng;
                    double iLat = (double)list[i].SpotLat;
                    string iLng1 = iLng.ToString("0.#");
                    string iLat1 = iLat.ToString("0.#");

                    if (lng1.Equals(iLng1)== true && lat1.Equals(iLat1) == true)
                    {
                        res.Add(list[i]);
                    }
                }
            }
            return res;
        }


    }
}
