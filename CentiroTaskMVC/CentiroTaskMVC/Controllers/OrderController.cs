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

        public IActionResult NewUserView()
        {
            return View();
        }

        // Inserts new order
        public IActionResult InsertNewOrder(string orderNumber, string orderLineNumber, string productNumber, string quantity,
         string name, string description, string price,
         string productGroup, string orderDate, string customerName, string customerNumber)
        {
            var dbConnection = new Connect();

            dbConnection.InsertNewOrder(orderNumber, orderLineNumber, productNumber, quantity,
            name, description, price,
            productGroup, orderDate, customerName, customerNumber);

            // Return to GetAll.cshtml
            return RedirectToAction("GetAll");
        }


        // The following method may not work properly
        public IActionResult DeleteOrder(string orderNumber, string productNumber)
        {


            var dbConnection = new Connect();

            dbConnection.DeleteOrder(orderNumber, productNumber);

            return RedirectToAction("GetAll");


        }
    }
}