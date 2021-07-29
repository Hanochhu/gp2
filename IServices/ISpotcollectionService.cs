using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp2.Models;

namespace gp2.IService
{
    public interface ISpotcollectionService
    {
        Task<List<Scenicspot>> FindSpotByUserIdAsync(int userId);


    }
}
