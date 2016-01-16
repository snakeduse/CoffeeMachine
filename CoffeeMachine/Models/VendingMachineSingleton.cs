using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    /// <summary>
    /// Модель, которая хранит данные аппарата по продаже кофе
    /// </summary>
    public class VendingMachineDataSingleton
    {
        protected VendingMachineDataSingleton()
        {
            // начальные данные
            UserPurse = new Purse(new List<Coin>
            {
                new Coin { Number = 1, Count =  10},
                new Coin { Number = 2, Count =  30},
                new Coin { Number = 5, Count =  20},
                new Coin { Number = 10, Count =  15}
            });

            Products = new List<Product>
            {
                new Product { Id = 1, Title = "Чай", Price = 13, Count = 10 },
                new Product { Id = 2, Title = "Кофе", Price = 18, Count = 20 },
                new Product { Id = 3, Title = "Кофе с молоком", Price = 21, Count = 20 },
                new Product { Id = 4, Title = "Сок", Price = 35, Count = 15 },
            };

            VendingMachinePurse = new Purse(new List<Coin>
            {
                new Coin {Number = 1, Count=100 },
                new Coin {Number = 2, Count=100 },
                new Coin {Number = 5, Count=100 },
                new Coin {Number = 10, Count=100 }
            });
        }

        private sealed class SingletonCreator
        {
            private static readonly VendingMachineDataSingleton instance = new VendingMachineDataSingleton();
            public static VendingMachineDataSingleton Instance => instance;
        }

        public static VendingMachineDataSingleton Instance => SingletonCreator.Instance;

        /// <summary>
        /// Кошелек пользователя
        /// </summary>
        public Purse UserPurse { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Кошелек кофемашины
        /// </summary>
        public Purse VendingMachinePurse { get; set; }

        /// <summary>
        /// Внесенная сумма в VM
        /// </summary>
        public int VendingMachineMoney { get; set; }
    }
}