using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Contracts
{
    /// <summary>
    /// Данные аппарата по продаже кофе
    /// </summary>
    public interface IVendingMachineData
    {
        /// <summary>
        /// Кошелек пользователя
        /// </summary>
        Purse UserPurse { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        List<Product> Products { get; set; }

        /// <summary>
        /// Кошелек кофемашины
        /// </summary>
        Purse VendingMachinePurse { get; set; }

        /// <summary>
        /// Внесенная сумма в VM
        /// </summary>
        int VendingMachineMoney { get; set; }
    }
}
