using gp2.IService;
using gp2.Models;
using gp2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Services
{
    public class ActcollectionService : IActcollectionService
    {
        private readonly ActcollectionRepository _actcollectionRepository;
        private readonly IRepository<Activity> _activityRepository;

        public ActcollectionService(ActcollectionRepository actcollectionRepository, IRepository<Activity> activityRepository)
        {
            _actcollectionRepository = actcollectionRepository;
            _activityRepository = activityRepository;
        }

        public List<Activity> FindActByUserId(Actcollection actcollection)
        {
            //根据活动id获得
            List<Actcollection> list = _actcollectionRepository.FindListByUserId((int)actcollection.ActcUserid).ToList();

            List<Activity> res = new List<Activity>();
          
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //获得list中每个元素的活动id
                    int actId=(int)list[i].ActcActid;
                    //根据获得的id查找到相应的活动信息并加入结果集
                    res.Add(_activityRepository.Find(actId));
                }
            }
            return res;



        }
    }
}
