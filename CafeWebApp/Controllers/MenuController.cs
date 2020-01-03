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

        IEnumerable<SelectListItem> PriceList;

        public MenuController(ISAD251_ELeaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<SelectListItem> DrinksList = (from p in _context.Stock.AsEnumerable()
                                                      select new SelectListItem
                                                      (
                                                          text: p.ItemName,
                                                          value: p.ItemId.ToString()
                                                      )).ToList();

            ViewBag.Stock = DrinksList;

           PriceList = (from p in _context.Stock.AsEnumerable()
                        select new SelectListItem
                        (
                        text: p.ItemId.ToString(),
                        value: p.ItemPrice.ToString()
                        )).ToList();

            ViewBag.PriceList = PriceList;

            return View();
        }
    }
}