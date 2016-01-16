using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Models
{
    /// <summary>
    /// Модель кошелька
    /// </summary>
    public class Purse
    {
        /// <summary>
        /// Монеты в кошельке
        /// </summary>
        public List<Coin> Coins{ get; private set; }

        /// <summary>
        /// Есть ли деньги указанного типа в кошельке
        /// </summary>
        /// <param name="money">Тип денег</param>
        public bool IsExistsMoney(int money) => GetCount(money) > 0;

        /// <summary>
        /// Получить количество монет в кошельке
        /// </summary>
        /// <param name="money">Монета, для которой нужно получить количество</param>
        public int GetCount(int money) =>
            Coins.First(x => x.Number == money).Count; 

        public Purse(List<Coin> coins)
        {
            Coins = coins;
        }

        /// <summary>
        /// Положить монеты в кошелек
        /// </summary>
        /// <param name="money">Количество монет</param>
        public void PutMoney(int money)
        {
            // работаем с монетами, отсортированными в порядке убывания
            // для того, чтобы начинать с наибольшей по значению монеты
            var descCoins = Coins.OrderByDescending(x => x.Number);
            foreach (var coin in descCoins)
            {
                var currentCount = 0;
                while (money >= coin.Number)
                {
                    currentCount++;
                    money -= coin.Number;
                }

                coin.Count += currentCount;
            }
        }

        /// <summary>
        /// Вычесть количество денег из кошелька
        /// </summary>
        /// <param name="money">Количество денег</param>
        public void PopMoney(int money)
        {
            var coin = Coins.First(x => x.Number == money);

            // вычитаем количество монет в кошельке пользователя
            coin.Count = Math.Max(--coin.Count, 0);
        }

    }
}