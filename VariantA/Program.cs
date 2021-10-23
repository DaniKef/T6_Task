//Гуренко Даниил
//Вариант 1
//В кругу стоят N человек, пронумерованных от 1 до N. 
//При ведении счета по кругу вычеркивается каждый второй человек, 
//пока не останется один. Составить две программы, моделирующие процесс. 
//Одна из программ должна использовать класс ArrayList, а вторая — LinkedList. 
//Какая из двух программ работает быстрее? Почему?
using System;
using System.Collections;
using System.Diagnostics;
// Программа с LinkedList работает быстрее
// LinkedList универсальная коллекция, что повышает производительность
// Изменение двусвязного списка более легче, чем массива. Вставить удалить элемент
// Просто поменять указатели на след. и пред. . Массив надо заново  воссоздавать
// Однако, это доп. хранилище для ссылок
namespace VariantA
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////// ArrayList
            var first = new FirstProgram();
            foreach (var item in first.Count(first.myList.Count))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            first.DeleteEverySecond();
            foreach (var item in first.Count(first.myList.Count))
            {
                Console.WriteLine(item);
            }
            /////////////////////////////LinkedList
            var second = new SecondProgram();
            foreach(var item in second.myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            second.DeleteEverySecond();
            foreach (var item in second.myList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
