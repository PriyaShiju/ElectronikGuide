using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronikData.Models;

namespace ElectronikData.Interfaces
{
    public interface IElectronikRepository
    {
        List<Project> GetAllProjects();
        Project GetProject(int Id);

    }
}
