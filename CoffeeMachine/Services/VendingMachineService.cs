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
                throw new VendingMachineServiceException($"Во время внесения денег произошла ошибка. {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                throw new VendingMachineServiceException($"Во время внесения денег произошла ошибка. {ex.Message}");
            }
        }

        public void Buy(int productId)
        {
            throw new NotImplementedException();
        }

        public void Residue(int money)
        {
            throw new NotImplementedException();
        }
    }
}