using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPutandPatch.Services;

namespace WebAppPutandPatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeTimeController : ControllerBase
    {
        private readonly IMyService _myservice;
        private readonly IMyService _myService1;
        public LifeTimeController(IMyService myService,IMyService myService1)
        {
            _myservice = myService;
            _myService1 = myService1;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Myservice2 = _myservice.GetInstanceId(),
                Myservice3 = _myService1.GetInstanceId()
            });
        }
    }
}
