using CoffeeMachine.Data.Contracts;
using CoffeeMachine.Models;
using CoffeeMachine.Services.Contracts;
using CoffeeMachine.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Services
{
    /// <summary>
    /// Сервис аппарата по продаже кофе 
    /// </summary>
    public class VendingMachineService : IVendingMachineService
    {
        private IVendingMachineData _vendingMachineData;

        public VendingMachineService(IVendingMachineData vendingMachineData)
        {
            _vendingMachineData = vendingMachineData;
        }

        /// <summary>
        /// Добавить деньги в аппарат
        /// </summary>
        /// <param name="money">Количество денег для добавления</param>
        public void AddMoney(int money)
        {
            try
            {
                // если в кошельке есть монеты, то изменяем внесенную сумму
                if (_vendingMachineData.UserPurse.IsExistsMoney(money))
                {
                    _vendingMachineData.VendingMachineMoney += money;
                }

                // вычитаем количество монет в кошельке пользователя
                _vendingMachineData.UserPurse.PopMoney(money);
                
            }
            catch (InvalidOperationException ex)
            {
                throw new VendingMachineServiceException("Во время внесения денег произошла ошибка. "+ ex.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new VendingMachineServiceException("Во время внесения денег произошла ошибка. "+ ex.Message);
            }
        }

        /// <summary>
        /// Выдать сдачу
        /// </summary>
        /// <param name="money">Количество денег для получения сдачи</param>
        public void Buy(int productId)
        {
            try
            {
                var product = _vendingMachineData.Products.First(x => x.Id == productId);

                if (product.Price > _vendingMachineData.VendingMachineMoney)
                {
                    throw new VendingMachineServiceException("Недостаточно средств");
                }

                // уменьшаем количество товара
                product.Count--;

                // вычитаем сумму товара из внесенной суммы
                _vendingMachineData.VendingMachineMoney -= product.Price;

                // зачисляем деньги в кошелек VM
                _vendingMachineData.VendingMachinePurse.PutMoney(product.Price);
            }
            catch(NullReferenceException ex)
            {
                throw new VendingMachineServiceException("Во время покупки товара произошла ошибка. "+ ex.Message);
            }
        }

        /// <summary>
        /// Купить товар
        /// </summary>
        /// <param name="productId">Идентификатор товара для покупки</param>
        public void Residue(int money)
        {
            try
            {
                _vendingMachineData.UserPurse.PutMoney(money);
                _vendingMachineData.VendingMachineMoney = 0;
            }
            catch(NullReferenceException ex)
            {
                throw new VendingMachineServiceException("Во время начисления сдачи. "+ ex.Message);
            }
        }
    }
}