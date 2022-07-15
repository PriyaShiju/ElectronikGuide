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
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Storeitem 1","Storeitem 2", "Storeitem 3" };
        }
        [HttpGet("{Id}")]
        public string Get(int Id)
        {
            return "The value is " + Id;
        }
    }
}
