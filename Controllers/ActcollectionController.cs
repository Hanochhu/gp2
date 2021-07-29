using gp2.IService;
using gp2.Models;
using gp2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace gp2.Controllers
{

    [ApiController]
    [Route("api/actc")]
    public class ActcollectionController
    {
        private readonly IActcollectionService _actcollectionService;

        public ActcollectionController(IActcollectionService actcollectionService)
        {
            _actcollectionService = actcollectionService;

        }

        [HttpPost("actlist")]
        public List<Activity> FindActByUserId(Actcollection actcollection)
        {
            return _actcollectionService.FindActByUserId(actcollection);
        } 


    }
}
