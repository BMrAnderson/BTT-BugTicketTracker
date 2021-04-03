using BTT.Domain.Models.Issues;
using BTT.WebMVC.Helper;
using BTT.WebMVC.Models;
using BTT.WebMVC.Models.ViewModels;
using BTT.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTT.WebMVC.Controllers
{
    public class IssueController : Controller
    {
        private static List<IssueViewModel> bugs = new List<IssueViewModel>();
        private readonly IIssueHttpService _service;

        public IssueController(IIssueHttpService service)
        {
            this._service = service;
        }

        //[HttpGet("{memberId}")]
        public IActionResult Index()
        {
           
            bugs.AddRange(GetBugs());

            return View();
        }

        [HttpGet]
        public IActionResult AddOrEdit()
        {

            var issue = new IssueViewModel();

            issue.Id = Guid.NewGuid();
            issue.DateCreated = DateTime.Now;
            issue.EndDueDate = DateTime.Now;

            return View(issue);
        }

        [HttpPost]
        public IActionResult AddOrEdit(IssueViewModel model)
        {
            //using (masterEntities db = new masterEntities())
            //{
            if (model.Id != Guid.Empty)
            {

                _service.Add(model);

                bugs.Add(model);

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
    

        //[HttpGet]
        public IActionResult GetAllIssues()
        {
            //var http = _httpClientFactory.CreateClient("Issue");
            //var request = $"{memberId}";
            //var response = http.GetAsync(request);

            List<IssueViewModel> issues = bugs.ToList();

            return Json(new { data = issues }, new JsonSerializerOptions());
        }


        private List<IssueViewModel> GetBugs()
        {
            List<IssueViewModel> bugs = new List<IssueViewModel>()
            {
            new IssueViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Test Title",
                Description = "Test Description",
                DateCreated = DateTime.Now,
                EndDueDate = DateTime.Now.AddDays(1),
                Priority = Priority.Low
            },
            new IssueViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Test Title",
                Description = "Test Description",
                DateCreated = DateTime.Now,
                EndDueDate = DateTime.Now.AddDays(1),
                Priority = Priority.Low
            },
            new IssueViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Test Title",
                Description = "Test Description",
                DateCreated = DateTime.Now,
                EndDueDate = DateTime.Now.AddDays(1),
                Priority = Priority.Low
            } 
            };
            return bugs;
        }
    }
}
