using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CafeWebApp.Controllers
{
    public class DrinksMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}