using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Services.Contracts
{
    /// <summary>
    /// Сервис аппарата по продаже кофе 
    /// </summary>
    public interface IVendingMachineService
    {
        /// <summary>
        /// Добавить деньги в аппарат
        /// </summary>
        void AddMoney(int money);

        /// <summary>
        /// Выдать сдачу
        /// </summary>
        /// <param name="money">Количество денег для получения сдачи</param>
        void Residue(int money);

        /// <summary>
        /// Купить товар
        /// </summary>
        /// <param name="productId">Идентификатор товара для покупки</param>
        void Buy(int productId);
    }
}
