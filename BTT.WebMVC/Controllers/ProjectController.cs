using BTT.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View(GetProjects());
        }

        private IEnumerable<ProjectViewModel> GetProjects()
        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>();

            for (int i = 0; i < 20; i++)
            {
                projects.Add(
                    new ProjectViewModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "Project Test",
                        Description = "Description test",
                        DateCreated = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(5),
                    });
            }
            return projects;
        }
    }
}
