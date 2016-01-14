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

        /// <summary>
        /// Обработка запроса добавления денег в VM
        /// </summary>
        /// <param name="money">Количество денег, для добавления в VM</param>
        [HttpGet]
        public ActionResult AddMoney(int money)
        {
            try
            {
                // изменяем внесенную сумму
                _vendingMachine.VendingMachineMoney += money;

                // вычитаем количество монет в кошельке пользователя
                var userMoney = _vendingMachine.UserCoins.First(x => x.Number == money);
                userMoney.Count = Math.Max(--userMoney.Count, 0);

                return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, CountMoney = userMoney.Count }, JsonRequestBehavior.AllowGet);
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { Error = $"Во время внесения денег произошла ошибка. {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
            catch (NullReferenceException ex)
            {
                return Json(new { Error = $"Во время внесения денег произошла ошибка. {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult X(int money)
        {
            // работаем с монетами, отсортированными в порядке убывания
            // для того, чтобы начинать с наибольшей по значению монеты
            var descCoins = _vendingMachine.UserCoins.OrderByDescending(x => x.Number);
            foreach (var userCoin in descCoins)
            {
                var currentCount = 0;
                while (money >= userCoin.Number)
                {
                    currentCount += 1;
                    money -= userCoin.Number;
                }

                userCoin.Count += currentCount;
            }

            _vendingMachine.VendingMachineMoney = 0;

            return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, UserCoins = _vendingMachine.UserCoins }, JsonRequestBehavior.AllowGet);
        }
    }
}