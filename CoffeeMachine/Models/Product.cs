using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Count { get; set; }
    }
}