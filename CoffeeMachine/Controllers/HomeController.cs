using CoffeeMachine.Models;
using CoffeeMachine.Services;
using CoffeeMachine.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeMachine.Controllers
{
    public class HomeController : Controller
    {
        private VendingMachineDataSingleton _vendingMachine = VendingMachineDataSingleton.Instance;
        private readonly IVendingMachineService _vendingMachineService = 
            new VendingMachineService(VendingMachineDataSingleton.Instance);

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
            _vendingMachineService.AddMoney(money);
            var count = _vendingMachine.UserPurse.GetCount(money);

            return Json(
                new {
                    VendingMachineMoney = _vendingMachine.VendingMachineMoney,
                    CountMoney = count
                }, 
                JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Получить сдачу
        /// </summary>
        /// <param name="money">Количество денег в VM для получения сдачи</param>
        public ActionResult Residue(int money)
        {
            _vendingMachine.UserPurse.PutMoney(money);
            _vendingMachine.VendingMachineMoney = 0;

            return Json(new { VendingMachineMoney = _vendingMachine.VendingMachineMoney, UserCoins = _vendingMachine.UserPurse }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Купить товар
        /// </summary>
        /// <param name="productId">Идентификатор товара для покупки</param>
        public ActionResult Buy(int productId)
        {
            var product = _vendingMachine.Products.First(x => x.Id == productId);

            if (product.Price > _vendingMachine.VendingMachineMoney)
            {
                return Json(new { Error = "Недостаточно средств" }, JsonRequestBehavior.AllowGet);
            }

            // уменьшаем количество товара
            product.Count--;

            // вычитаем сумму товара из внесенной суммы
            _vendingMachine.VendingMachineMoney -= product.Price;

            // зачисляем деньги в кошелек VM
            _vendingMachine.VendingMachinePurse.PutMoney(product.Price);

            return Json(new { Product = product, VendingMachineMoney = _vendingMachine.VendingMachineMoney, VendingMachineCoins = _vendingMachine.VendingMachinePurse }, JsonRequestBehavior.AllowGet);
        }
    }
}