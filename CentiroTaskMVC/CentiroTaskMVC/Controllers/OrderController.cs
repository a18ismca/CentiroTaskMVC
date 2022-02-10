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
            ViewBag.AllOrderTable = dbConnection.GetAllOrders();

            return View();
        }

        public IActionResult OrderNumberSearch(string orderNumber)
        {
            var dbConnection = new Connect();
            ViewBag.SpecificOrderTable = dbConnection.GetSpecificOrderNumber(orderNumber);
            return View();
        }
    }
}