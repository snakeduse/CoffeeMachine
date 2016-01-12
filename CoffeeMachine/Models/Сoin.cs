using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    /// <summary>
    /// Модель монеты
    /// </summary>
    public class Сoin
    {
        /// <summary>
        /// Номер монеты
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Количество монет
        /// </summary>
        public int Count { get; set; }
    }
}