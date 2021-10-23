using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariantC.TaskClasses;

namespace VariantB.Storage
{
    class OrderStorage : Storage
    {
        private Dictionary<string, Order> _storage = new Dictionary<string, Order>(); // ключ- номер телефона заказчика, value - заказ
        public OrderStorage()
        {
            storageName = "B-52";
            storagePlace = "Харьков";
        }
        public void AddOrder(long phone, Order newOrder) // Добавить заказ, телефон-заказ
        {
            _storage.Add(String.Format("{0:+(###)###-####}", phone), newOrder);
        }
        public void RemoveOrder(string phone) // Выполнить заказ. удалить
        {
            _storage.Remove(phone);
        }

        public override int Count // Свойство количества элементов в хранилище заказов
        {
            get { return _storage.Count; }
        }
        public Dictionary<string, Order> this[int index] // Индексатор словаря
        {
            get
            {
                return new Dictionary<string, Order>
                    { { _storage.ElementAt(index).Key , _storage.ElementAt(index).Value} };
            }
        }
        public IEnumerator GetEnumerator() // Итератор словаря
        {
            for (int i = 0; i < _storage.Count; i++)
            {
                yield return _storage.ElementAt(i);
            }
        }

    }
}
