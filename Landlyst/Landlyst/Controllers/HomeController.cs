using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landlyst.Models;
using Landlyst.Models.TempModels;
using Landlyst.DataHandling;
using Landlyst.DataHandling.Managers;

namespace Landlyst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult TermsofService()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(TempLogin user)
        {
            if (HotelManager.ConfirmUser(user.Initials, user.Password))
            {
                switch (HotelManager.user.Position)
                {
                    case 1:
                        return RedirectToAction("Privacy", "Receptionists");
                    case 2:
                        return Redirect("");
                    case 3:
                        return Redirect("");
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
