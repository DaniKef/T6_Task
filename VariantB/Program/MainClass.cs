//Гуренко Даниил
// Вариант 5
//Создать консольное приложение, удовлетворяющее следующим требованиям:
//Использовать возможности ООП: классы, наследование, полиморфизм, инкапсуляция.
//Реализовать несколько уровней абстракции (интерфейсы, абстрактные классы).
//Каждый класс должен иметь отражающее смысл название и информативный состав.
//Для хранения коллекций объектов предметной области использовать обобщенные коллекции (для одной из сущностей использовать коллекцию типа СЛОВАРЬ).
//Коллекцию сущностей представить в виде класса (коллекция - поле класса). Реализовать индексаторы и итераторы по элементам коллекции.
//Наследование должно применяться только тогда, когда это имеет смысл.
//При кодировании должны быть использованы соглашения об оформлении кода: code convention.
//Использовать механизм обработки исключительных ситуаций.

////////////////////////////////////////////////////////////////////////////////////////////////
//Заказ.В сущностях(типах) хранится информация о заказах магазина и товарах в них.
//Для заказа необходимо хранить:
//— номер заказа;
//— товары в заказе;
//— дату поступления.
//Для товаров в заказе необходимо хранить:
//— товар;
//— количество.
//Для товара необходимо хранить:
//— название;
//— описание;
//— цену.
//Вывести полную информацию о заданном заказе.
//Вывести номера заказов, сумма которых не превосходит заданную и количество различных товаров равно заданному.
//Вывести номера заказов, содержащих заданный товар.
//Вывести номера заказов, не содержащих заданный товар и поступивших в течение текущего дня.
//Сформировать новый заказ, состоящий из товаров, заказанных в текущий день.
//Удалить все заказы, в которых присутствует заданное количество заданного товара.

using System;
using System.Collections.Generic;
using VariantC.TaskClasses;
using VariantC.Program;
using VariantB.Storage;

namespace VariantC
{
    class MainClass
    {
        static void Main(string[] args)
        {
            var AppleProduct = new Product();
            var TableProduct = new Product();
            var MouseProduct = new Product();
            var TShirtProduct = new Product("Футболка", "Синяя футболка, xl", 450);//создание продуктов-конструктор
            AppleProduct.CreateProduct("Яблоки", "Свежие яблоки \"Малинка\"", 15.60); //создание продуктов-методы
            TableProduct.CreateProduct("Стол", "Лучший в мире стол", 2100);
            MouseProduct.CreateProduct("Мышь", "Logitech. Хорошее качество.", 800); 

            ProductStorage productInOrderStorage = new ProductStorage(); // коллекция продуктов
            OrderStorage storageOrder = new OrderStorage(); // коллекция заказов

            productInOrderStorage.AddProduct(new ProductInOrder(TableProduct, 3)); // Продукты в коллекцию
            productInOrderStorage.AddProduct(new ProductInOrder(AppleProduct, 55));
            productInOrderStorage.AddProduct(new ProductInOrder(TShirtProduct, 5));
            productInOrderStorage.AddProduct(new ProductInOrder(MouseProduct, 7));
            productInOrderStorage.AddProduct(new ProductInOrder(TShirtProduct, 10));
            productInOrderStorage.AddProduct(new ProductInOrder(TableProduct, 1));
            productInOrderStorage.AddProduct(new ProductInOrder(AppleProduct, 20));
            productInOrderStorage.AddProduct(new ProductInOrder(TShirtProduct, 2));//

            storageOrder.AddOrder("0996154567", new Order(83444, 14, new List<ProductInOrder>() {
            productInOrderStorage[0], productInOrderStorage[1]}));// создать добавить заказ // 1 ЗАКАЗ//

            storageOrder.AddOrder("0994433565", new Order(80111, 15, new List<ProductInOrder>() {
            productInOrderStorage[2]}));// добавить заказ // 2 ЗАКАЗ//

            storageOrder.AddOrder("0568462346", new Order(90999, 15, new List<ProductInOrder>() {
            productInOrderStorage[3], productInOrderStorage[4], productInOrderStorage[5]}));// добавить заказ // 3 ЗАКАЗ//

            storageOrder.AddOrder("0564750381", new Order(10000, 16, new List<ProductInOrder>() {
            productInOrderStorage[6], productInOrderStorage[7]}));// добавить заказ // 4 ЗАКАЗ//

            for (int i = 0; i < storageOrder.Count; i++) // Вывести все заказы
            {
                Console.WriteLine(string.Join(Environment.NewLine, storageOrder[i]));
            }
            Console.WriteLine("-------------------------------------------------");

            Functions.SearchOrdersWithSumAndCOuntOfProducts(storageOrder, 10000, 2); //Вывести номера заказов, сумма которых не превосходит заданную и количество различных товаров равно заданному.
            Functions.SearchThisProduction(storageOrder, "Футболка"); // Вывести номера заказов, содержащих заданный товар.
            Functions.SearchNotContainsProductAndToday(storageOrder, "Яблоки", 15);//Вывести номера заказов, не содержащих заданный товар и поступивших в течение текущего дня.
            storageOrder.AddOrder("0556833325", Functions.CreateOrder(storageOrder, 15));//Сформировать новый заказ, состоящий из товаров, заказанных в текущий день. //5 ЗАКАЗ//

            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < storageOrder.Count; i++) // Вывести все заказы
            {
                Console.WriteLine(string.Join(Environment.NewLine, storageOrder[i]));
            }
            Console.WriteLine("-------------------------------------------------");

            Functions.RemoveOrdersThisProductThisAmount(ref storageOrder, "Футболка", 2);//Удалить все заказы, в которых присутствует заданное количество заданного товара.
            Console.WriteLine("---------------------------------------------");
            foreach (var item in storageOrder)
                Console.WriteLine(item);
            Console.WriteLine($"За все время было выполнено {Order.orderCount} заказов."); //Выводит количество всех заказов

            Console.ReadKey();
        }
    }
}
