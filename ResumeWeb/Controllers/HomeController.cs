using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ResumeWeb.Controllers
{
    public class HomeController : Controller
    {
        ResumeWebSettings _settings;

        public HomeController(IOptions<ResumeWebSettings> options)
        {
            _settings = options.Value;
        }

        public IActionResult Index()
        {
            var cguid = Request.Query["cguid"];
            _settings.Company = cguid;

            this.ViewBag.InitData = _settings;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
