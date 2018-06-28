using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ResumeWeb.Controllers
{
    public class HomeController : Controller
    {
        ResumeWebSettings _settings;
        ILogger<HomeController> _logger;

        public HomeController(IOptions<ResumeWebSettings> options, ILogger<HomeController> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.ViewBag.InitData = _settings;
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            _settings.Company = id;

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
