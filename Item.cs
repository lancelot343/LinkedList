using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class Item<T>
    {
        /// <summary>
        /// Дані, які зберігаємо
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Наступний елемент списку
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Створюємо новий інстанс класу Item
        /// </summary>
        /// <param name="data"> Дані, які зберігаємо </param>
        public Item(T data)
        {
            // Перевіряємо вхідні дані 
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
        }

        /// <summary>
        /// Приводимо обєкт до стрічки
        /// </summary>
        /// <returns> Дані, які зберігаємо </returns>
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
