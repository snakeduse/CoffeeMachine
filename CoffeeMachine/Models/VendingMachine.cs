using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    /// <summary>
    /// Модель аппарата по продаже кофе
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// Монеты пользователя
        /// </summary>
        public List<Сoin> UserCoins { get; set; }

        public List<Product> Products { get; set; }

        public VendingMachine()
        {
            // начальные данные
            UserCoins = new List<Сoin>
            {
                new Сoin { Number = 1, Count =  10},
                new Сoin { Number = 2, Count =  30},
                new Сoin { Number = 5, Count =  20},
                new Сoin { Number = 10, Count =  15}
            };

            Products = new List<Product>
            {
                new Product { Title = "Чай", Price = 13, Count = 10 },
                new Product { Title = "Кофе", Price = 18, Count = 20 },
                new Product { Title = "Кофе с молоком", Price = 21, Count = 20 },
                new Product { Title = "Сок", Price = 35, Count = 15 },
            };
        }
    }
}