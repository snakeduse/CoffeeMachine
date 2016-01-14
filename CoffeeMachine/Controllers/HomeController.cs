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

        /// <summary>
        /// Обработка запроса добавления денег в VM
        /// </summary>
        /// <param name="money">Количество денег, для добавления в VM</param>
        [HttpGet]
        public ActionResult AddMoney(int money)
        {
            try
            {
                var userCoins = _vendingMachine.UserCoins.First(x => x.Number == money);

                // если в кошельке есть монеты, то изменяем внесенную сумму
                if (userCoins.Count > 0)
                {
                    _vendingMachine.VendingMachineMoney += money;
                }

                // вычитаем количество монет в кошельке пользователя
                userCoins.Count = Math.Max(--userCoins.Count, 0);

                return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, CountMoney = userCoins.Count }, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// Получить сдачу
        /// </summary>
        /// <param name="money">Количество денег в VM для получения сдачи</param>
        public ActionResult Residue(int money)
        {
            // работаем с монетами, отсортированными в порядке убывания
            // для того, чтобы начинать с наибольшей по значению монеты
            var descCoins = _vendingMachine.UserCoins.OrderByDescending(x => x.Number);
            foreach (var userCoin in descCoins)
            {
                var currentCount = 0;
                while (money >= userCoin.Number)
                {
                    currentCount++;
                    money -= userCoin.Number;
                }

                userCoin.Count += currentCount;
            }

            _vendingMachine.VendingMachineMoney = 0;

            return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, UserCoins = _vendingMachine.UserCoins }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Купить товар
        /// </summary>
        /// <param name="productId">Идентификатор товара для покупки</param>
        public ActionResult Buy(int productId)
        {
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}