using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Item<T> _head = null;

        /// <summary>
        /// Крайній елемент списка
        /// </summary>
        private Item<T> _tail = null;

        /// <summary>
        /// Кількість елементів у списку
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Геттер для Count
        /// </summary>
        public int Count
        {
            get => _count;
        }

        /// <summary>
        /// Додамо дані в список
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // Перевіряємо вхідні дані
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Створюємо новий елемент списка
            var item = new Item<T>(data);

            // Якщо список порожній, то кладемо його на початок
            // якщо ні, додаємо цей елемент як наступний за останнім елементом
            if (_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }

            // Встановлюємо цей елемент останнім
            _tail = item;

            // Ітерація змінної, яка містить кількість елементів у списку
            _count++;
        }

        /// <summary>
        /// Видалити дані із списку
        /// Виконується видалення першого входження даних
        /// </summary>
        /// <param name="data">Дані, які будуть видалені </param>
        public void Delete(T data)
        {
            // Перевіряємо вхідні дані
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Теперішній елемент
            var current = _head;

            // Попередній елемент
            Item<T> previous = null;

            // Проходимося по всіх елементах списка до його завершення,
            // або поки не буде знайдено елемент, який потрібно видалити
            while (current != null)
            {
                // Якщо дані теперішнього елемента співпадають з даними, які потрібно видалити
                // то видаляємо теперішній елемент, враховуючи його розташування в ланцюку.
                if (current.Data.Equals(data))
                {
                    // Якщо елемент знаходиться в середині або кінці списка,
                    // викидаємо теперішній елемент зі списка
                    // якщо це перший елемент списка, то викидаємо його
                    if (previous != null)
                    {
                        // Встановлюємо у попереднього елемента вказівник на наступний елемент від теперішнього.
                        previous.Next = current.Next;

                        // Якщо це був останній елемент списка,
                        // то змінюємо вказівник на крайній елемент списка
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // встановлюємо "головний" елемент наступним.
                        _head = _head.Next;

                        // Якщо список порожній,
                        // то обнуляємо і крайній елемент.
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    // Елемент видалений
                    // Зменшуємо кількість елементів на одиницю і виходимо з циклу.
                    // Для того, щоб видалити всі входження даних із списка,
                    // потрібно не виходити із циклу, а дати йому дійти до кінця..
                    _count--;
                    break;
                }

                // Переходимо до наступного елемента
                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Очистимо список 
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Повернути ітератор,який перебирає всі елементи в списку.
        /// </summary>
        /// <returns> Ітератор, який можна використати для ітерації по колекції. </returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Перебираємо всі елементи списка, для представлення у виді колекції елементів.
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Повернути ітератор, який виконує ітераційний перехід по списку
        /// </summary>
        /// <returns> Об'єкт IEnumerator, який використовується для проходження по колекції. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Повертаємо ітератор, який визначений вище.
            // Для реалізації інтерфейсу IEnumerable
            // для того , щоб можна було використовувати foreach
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
