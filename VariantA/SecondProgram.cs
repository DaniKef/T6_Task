using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantA
{
    class SecondProgram
    {
        public LinkedList<int> myList = new LinkedList<int>();
        public SecondProgram()
        {
            Inizialize();
        }
        private void Inizialize()
        {
            for (int i = 1; i <= 8; i++)
                myList.AddLast(i);
        }
        public void DeleteEverySecond()
        {
            int indexCount = 0;
            int index = 0;
            LinkedList<int> tempList = new LinkedList<int>();
            while (myList.Count != 1)
            {
                if (indexCount == 0)
                {
                    tempList.AddLast(myList.ElementAt(index));
                    indexCount = 2;
                }
                if (index == myList.Count - 1)
                {
                    myList.Clear();
                    for (int i = 0; i < tempList.Count; i++)
                        myList.AddLast(tempList.ElementAt(i));
                    tempList.Clear();
                    index = -1;
                }
                index++;
                indexCount--;
            }
        }

    }
}
