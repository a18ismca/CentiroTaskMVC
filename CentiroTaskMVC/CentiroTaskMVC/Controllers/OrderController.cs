using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CentiroTaskMVC.Models;

namespace CentiroTaskMVC.Controllers
{
    public class OrderController : Controller
    {

        // GET: /Order/GetAll
        public IActionResult GetAll()
        {
            var dbConnection = new Connect();
            ViewBag.AllOrdersTable = dbConnection.GetAllOrders();
            return View();
        }

        public IActionResult SearchView()
        {
            var dbConnection = new Connect();
            ViewBag.AllDistinctOrderNumbers = dbConnection.GetAllDistinctOrderNumbers();
            return View();
        }

        public IActionResult GetOrderNumber(string orderNumber)
        {
            var dbConnection = new Connect();
            ViewBag.SearchResults = dbConnection.GetOrderNumber(orderNumber);
            return View();
        }
    }
}