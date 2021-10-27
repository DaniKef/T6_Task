using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariantC.TaskClasses;

namespace VariantB.Storage
{
    class ProductStorage : Storage // Коллекция всех продуктов в заказах
    {
        List<ProductInOrder> _storage = new List<ProductInOrder>();
        public ProductStorage() // Конструктор без праметров
        {
            storageName = "СкладПродуктов";
            storagePlace = "Харьков";
        }
        public override int Count // Свойство количества элементов в хранилище заказов
        {
            get { return _storage.Count; }
        }
        public void AddProduct(ProductInOrder newProduct)// Добавить продукт
        {
            _storage.Add(newProduct);
        }
        public void RemoveAll() // Удалить все продукты
        {
            _storage.Clear();
        }
        public List<ProductInOrder> GetProdictsInOrder() // Вернуть список всех продуктов
        {
            return _storage;
        }
        public ProductInOrder this[int index] // Индексатор 
        {
            get
            {
                return _storage[index];
            }
            set
            {
                _storage[index] = value;
            }
        }
        public IEnumerator GetEnumerator() // Итератор
        {
            for (int i = 0; i < _storage.Count; i++)
            {
                yield return _storage[i];
            }
        }
    }
}
