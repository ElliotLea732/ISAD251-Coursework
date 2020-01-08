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
        int OrderID = 5;
        int Quantity = 1;


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

            //OrderID = (_context.Database.ExecuteSqlRaw("SELECT MAX(OrderMainID) FROM Orders")) + 1; //creates an id for the new order which is one higher then the last order

            return View();
        }

        [HttpPost]
        public IActionResult AddItemToOrder(AddNewOrder addNewOrder) //adds the item to the order tables in the database
        {

           var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC AddNewOrder @OrderID, @ItemName, @ItemQuantity",
                new SqlParameter("@OrderID", addNewOrder.OrderID),
                new SqlParameter("@ItemName", addNewOrder.ItemName.ToString()),
                new SqlParameter("@ItemQuantity", addNewOrder.ItemQuantity)
                );

            ViewBag.Success = rowsaffected;

            return View("Index");
        }

    }
}