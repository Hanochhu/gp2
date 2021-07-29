using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Models;

namespace gp2.IService
{
    public interface IStrategyService
    {
        List<Strategy> GetAll();

        void Create(Strategy strategy);

        Task<List<Strategy>> FindStaByUserIdAsync(User user);

        Task<Strategy> FindStaByKeyAsync(int id);

    }
}
