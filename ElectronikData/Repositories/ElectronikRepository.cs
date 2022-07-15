using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronikData.Interfaces;
using ElectronikData.Models;

namespace ElectronikData.Repositories
{
    public class ElectronikRepository : IElectronikRepository
    {
        public List<Project> Projects = new ()
        {
            new Project {ProjectId = 1 ,ProjectTitle="Ohmlaw", Description="Ohms law to measure current" },
            new Project {ProjectId = 2 ,ProjectTitle="law2", Description="laws to measure water in milk" }
        };

        public List<Project> GetAllProjects()
        {
            //throw new NotImplementedException();
            return Projects;
        }
        public Project GetProject(int Id)
        {
            return Projects.FirstOrDefault(x => x.ProjectId == Id);

        }

    }
}
