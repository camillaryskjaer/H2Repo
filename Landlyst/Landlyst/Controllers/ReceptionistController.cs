using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models.TempModels;
using Microsoft.AspNetCore.Mvc;

namespace Landlyst.Controllers
{
    public class ReceptionistController : Controller
    {
        private TempUser currentUser;

        public TempUser SetUser
        {
            set
            {
                if (currentUser == null)
                {
                    currentUser = value;
                }
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TermsofService()
        {
            return View();
        }
    }
}
