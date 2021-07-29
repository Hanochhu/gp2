using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    public class ActivityRepository : Repository<Activity>
    {
        private readonly Gp2Context _gp2Context;
        public ActivityRepository(Gp2Context gp2Context) : base(gp2Context)
        {
            _gp2Context = gp2Context;
        }

        public IEnumerable<Activity> FindListByUserId(int userId)
        {
           return _gp2Context.Activities.Where(p => p.ActWriter == userId);
        }

    }
}
