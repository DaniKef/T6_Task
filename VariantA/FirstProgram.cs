using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantA
{
    class FirstProgram // Для ArrayList
    {
        public ArrayList myList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        public void DeleteEverySecond() // Удаление каждого второго по кругу
        {
            int indexCount = 0; // через раз удаляет элемент
            int index = 0; // индекс с 0
            ArrayList tempList = new ArrayList(); //временный массив
            while (myList.Count != 1) // пока не останется 1 человек, по кругу
            {
                if(indexCount == 0) // если == 0 , надо поместить неизменяемые элементы в временный массив
                {
                    tempList.Add(myList[index]);
                    indexCount = 2;// для того, чтоб через 1
                }
                if(index == myList.Count-1) // если дошло до последнего элемента
                {
                    myList.Clear(); // очисттить массив
                    for (int i = 0; i < tempList.Count; i++) // заполнить его элементами
                        myList.Add(tempList[i]);// которые остались
                    tempList.Clear();// очистить временный массив
                    index = -1; // вернуть индкс в 0
                }
                index++; 
                indexCount--;
            }
        }
        public IEnumerable Count(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == myList.Count)
                {
                    yield break;
                }
                else
                {
                    yield return myList[i];
                }
            }
        }

    }
}
