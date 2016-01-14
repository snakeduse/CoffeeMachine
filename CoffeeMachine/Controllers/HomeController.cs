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

        [HttpGet]
        public ActionResult Increment(int money)
        {
            _vendingMachine.VendingMachineMoney += money;

            var userMoney = _vendingMachine.UserCoins.First(x => x.Number == money);
            userMoney.Count = Math.Max(--userMoney.Count, 0);

            return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, CountMoney = userMoney.Count }, JsonRequestBehavior.AllowGet);
        }
    }
}