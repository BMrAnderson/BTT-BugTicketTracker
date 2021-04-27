using BTT.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberHttpService _memberHttpService;
        private readonly ILogger<MemberController> _logger;
        public MemberController(IMemberHttpService memberHttpService, ILogger<MemberController> logger)
        {
            _memberHttpService = memberHttpService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
