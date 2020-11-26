using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Landlyst.Controllers
{
    public class CleanersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
