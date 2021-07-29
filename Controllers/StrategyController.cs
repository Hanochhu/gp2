using AutoMapper;
using gp2.DTO;
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
    [Route("api/strategy")]
    public class StrategyController
    {
        public readonly IStrategyService _strategyService;
        public readonly IMapper _mapper;

        public StrategyController(IStrategyService strategyService,IMapper mapper)
        {
            _strategyService = strategyService;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取所有游记
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public List<Strategy> GetAll()
        {
            return _strategyService.GetAll().ToList();
        }

        /// <summary>
        /// 创建一个新的游记
        /// </summary>
        /// <param name="strategy"></param>
        [HttpPost("new")]
        public void Create(Strategy strategy)
        {
            _strategyService.Create(strategy);
        }



        class StrategyComparer : IComparer<Strategy>
        {
            public int Compare(Strategy x, Strategy y)
            {
                return (int)(y.StaLove??0 - x.StaLove??0);
            }
        }

        /// <summary>
        /// 获取热门游记
        /// </summary>
        /// <returns></returns>
        [HttpGet("popular")]
        public List<StaItem> GetPop()
        {
            List<Strategy> list = _strategyService.GetAll().ToList();
            list.Sort(new StrategyComparer());
            
            List<StaItem> res = _mapper.Map<List<StaItem>>(list);

            
            return res;
        }

        /// <summary>
        /// 获取用户发布的游记
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("person")]
        public Task<List<Strategy>> FindStaCollection(User user)
        {
            return _strategyService.FindStaByUserIdAsync(user);
        }


        /// <summary>
        /// 根据游记id查找游记
        /// </summary>
        /// <param name="staId"></param>
        /// <returns></returns>
        [HttpGet("strategy")]
        public async Task<Strategy> FindStaAsync(int staId)
        {
            return await _strategyService.FindStaByKeyAsync(staId);
        }


    }
}
