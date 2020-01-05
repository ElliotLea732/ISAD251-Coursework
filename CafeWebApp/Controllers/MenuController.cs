using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeWebApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly ISAD251_ELeaContext _context;


        public MenuController(ISAD251_ELeaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<SelectListItem> ItemList = (from p in _context.Stock.AsEnumerable() //creates a list of the items for sale for use in the drop down box
                                                      select new SelectListItem
                                                      (
                                                          text: p.ItemName,
                                                          value: p.ItemId.ToString()
                                                      )).ToList();

            ViewBag.Stock = ItemList;

            return View();
        }
    }
}