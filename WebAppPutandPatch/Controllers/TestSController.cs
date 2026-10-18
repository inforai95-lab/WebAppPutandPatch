using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPutandPatch.Repositories;
using WebAppPutandPatch.Services;

namespace WebAppPutandPatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSController : ControllerBase
    {
        private readonly Iservices _iservices;
        private readonly IEmployeeRepository _employeeRepository1;

        public TestSController(Iservices iservices, IEmployeeRepository employeeRepository1)
        {
            _iservices = iservices;
            _employeeRepository1 = employeeRepository1;
        }
        [HttpGet]
        public IActionResult GetData()
        {
            var name = _iservices.GetMethod();
            var age = _iservices.GetAge();
            return Ok(
                new
                {
                    Name=name,
                    Age=age

                });
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllData1()
        {
            var emp1 = await _employeeRepository1.GetAllAsync();
            return Ok(emp1);
        }
    }
}
