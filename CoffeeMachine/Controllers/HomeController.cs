using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeMachine.Controllers
{
    public class HomeController : Controller
    {
        private static VendingMachine _vendingMachine = new VendingMachine();

        public ActionResult Index()
        {
            return View(_vendingMachine);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}