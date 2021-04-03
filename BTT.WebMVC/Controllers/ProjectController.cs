using BTT.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Controllers
{
    public class ProjectController : Controller
    {
        private static List<ProjectViewModel> projects = new List<ProjectViewModel>();

        public IActionResult Index()
        {
            projects.AddRange(GetProjects());

            return View(projects);
        }

        [HttpGet]
        public IActionResult AddOrEdit()
        {
            var project = new ProjectViewModel();

            project.Id = Guid.NewGuid();
            project.DateCreated = DateTime.Now;
            project.DueDate = DateTime.Now;

            return View(project);
        }

        [HttpPost]
        public IActionResult AddOrEdit(ProjectViewModel project)
        {
            if (project.Id != Guid.Empty)
            {
                projects.Add(project);

                //db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, new JsonSerializerOptions());
            }
            else
            {
                //    //db.Entry(emp).State = EntityState.Modified;
                //    //db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, new JsonSerializerOptions());
            }
        }

        public IActionResult GetAllProjects()
        {
            List<ProjectViewModel> p = projects.ToList();

            return Json(new { data = p }, new JsonSerializerOptions());
        }

        private IEnumerable<ProjectViewModel> GetProjects()
        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>();

            for (int i = 0; i < 5; i++)
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
