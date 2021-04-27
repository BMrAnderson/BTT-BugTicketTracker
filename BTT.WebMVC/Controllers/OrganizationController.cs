using BTT.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationHttpService _organizationHttpService;
        public OrganizationController(IOrganizationHttpService organizationHttpService)
        {
            this._organizationHttpService = organizationHttpService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
