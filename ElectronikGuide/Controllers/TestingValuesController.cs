using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronikGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Item1", "item2" };
        }
        //[HttpGet("{Id, strName }")]
        //public string Get(int Id ,string strName)
        //{
        //    return "the value of " + "  "+ strName + " = " +  Id ;

        //}

    }
}
