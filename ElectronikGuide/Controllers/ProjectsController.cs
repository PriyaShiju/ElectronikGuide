using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ElectronikData.Models;
//using ElectronikData.Interfaces;
//using ElectronikData.Repositories;
using ElectronikGuide.Models;
//using ElectronikGuide.Interface;
using ElectronikGuide.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace ElectronikGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IMemoryCache _memcache;

        public List<Project> Projects = new List<Project>()
        {
            new Project {ProjectId = 1 ,ProjectTitle="Ohmlaw", Description="Ohms law to measure current" },
            new Project {ProjectId = 2 ,ProjectTitle="law2", Description="laws to measure water in milk" }
        };
        //private readonly IElectronikRepository Projects = new ElectronikRepository();


        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
            //return Projects.GetAllProjects();
            //_logger.LogWarning("Found Records");
            return Projects;
        }


        [HttpGet("{Id}")]
        public ActionResult<Project> GetProject(int Id)
        {
            //var Project = Projects.GetProject(Id);

            var Project = Projects.FirstOrDefault(x => x.ProjectId == Id);

            if (Project == null)
                return NotFound();
            else
                return Project;
        }
       
       

    }
}
