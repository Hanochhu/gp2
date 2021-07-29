using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.IService;
using gp2.Models;
using gp2.Repository;

namespace gp2.Services
{
    public class ActivityService : IActivityService
    {

        private readonly ActivityRepository _activityRepository;

        public ActivityService(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<Activity> FindActByKeyAsync(int id)
        {
           return await _activityRepository.FindAsync(id);
        }


        public List<Activity> FindActByUserId(int userId)
        {
            return  _activityRepository.FindListByUserId(userId).ToList();
        }

        public List<Activity> GetAll()
        {
            return _activityRepository.GetAll().ToList();
        }
    }
}
