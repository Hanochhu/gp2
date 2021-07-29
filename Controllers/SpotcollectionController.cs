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
    [Route("api/spotc")]
    public class SpotcollectionController
    {
        public readonly ISpotcollectionService _spotcollectionService;

        public SpotcollectionController(ISpotcollectionService spotcollectionService)
        {
            _spotcollectionService = spotcollectionService;
        }

        [HttpPost("spotclist")]
        public async Task<List<Scenicspot>> GetSpotcListAsync(Spotcollection spotcollection)
        {
            return await _spotcollectionService.FindSpotByUserIdAsync((int)spotcollection.SpotcUserid);
        }

    }
}
