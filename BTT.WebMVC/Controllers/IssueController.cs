using BTT.Domain.Models.Issues;
using BTT.WebMVC.Helper;
using BTT.WebMVC.Models;
using BTT.WebMVC.Models.ViewModels;
using BTT.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IIssueHttpService _issueHttpService;
        private readonly ILogger<IssueController> _logger;

        public IssueController(IIssueHttpService service, ILogger<IssueController> logger)
        {
            this._issueHttpService = service;
            this._logger = logger;
        }

        //[HttpGet("{memberId}")]
        public IActionResult Index()
        {
           
            bugs.AddRange(GetBugs());

            return View();
        }

        [HttpGet]
        public IActionResult Attachments(Guid issueId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Attachments(AttachmentViewModel attachment)
        {
            return View(attachment);
        }

        [HttpGet]
        public IActionResult Comments(Guid issueId)
        {
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

                _issueHttpService.Add(model);

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

        [HttpGet]
        public IActionResult Edit(Guid issueId)
        {
            //var issue = _issueHttpService.Get(issueId);
            var issue = GetBugs().Where(i => i.Id == issueId).FirstOrDefault();

            return View(issue);
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

        //[HttpDelete]
        //public IActionResult Remove(Guid issueId)
        //{
        //    bool isRemoved = _issueHttpService.Remove(issueId);

        //    string messageResult = isRemoved ? "Saved Successfully" : "Error";

        //    return Json(new { success = isRemoved, message = messageResult }, new JsonSerializerOptions());
        //}

        //[HttpPut]
        //public IActionResult Edit(IssueViewModel issueVM)
        //{
        //    bool isUpdated = _issueHttpService.Edit(issueVM);

        //    string messageResult = isUpdated ? "Updated Successfully" : "Error";

        //    return Json(new { success = isUpdated, message = messageResult }, new JsonSerializerOptions());
        //}
    }
}
