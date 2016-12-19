using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9A
{
    class DynamicQueue<T> : DynamicArray<T>, IMyQueue<T>
    {
        public DynamicQueue(int maxSize)
        {
            sizeOfDynamicArr = 0;
            capacityOfDynamicArr = 0;
            MaxSize = maxSize;
        }

        public bool IsFull()
        {
            if (sizeOfDynamicArr >= MaxSize) //if stack is full
            {
                Console.WriteLine("The stack is full");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()
        {
            if (sizeOfDynamicArr == 0) // check if stack is not empty already
            {
                Console.WriteLine("The stack is empty");
                return true;
            }
            else
            {
                return false;
            }
        }

        public  T Peek()
        {
            return Get(sizeOfDynamicArr);
        }

        public  void Print()
        {
            int i = 0;
            int count_print = sizeOfDynamicArr;
            if (count_print == 0)
            {
                Console.WriteLine("[ ]"); // beginning of the stack which is the same as 1st element in the array
                return;
            }

            Console.Write("[ ");
            while (count_print > 0)
            {
                Console.Write(DynamicArr[i].ToString());
                if (count_print > 1)
                {
                    Console.Write(", ");
                }
                i++;
                count_print--; // reduce the size of the printed elements
                if (count_print == 0)
                {
                    Console.WriteLine(" ]");
                }
            }
        }

        public void Enqueue(T newTop)
        {
            if (sizeOfDynamicArr < MaxSize)  // check if head index is less than the array size
            {
                Insert(sizeOfDynamicArr, newTop); // adding new element
            }
        }

        public T Dequeue()
        {
            if (sizeOfDynamicArr > 0) // if the tail is less than the size of array
            {
                TValue = Remove(0);
            }
            return TValue;
        }
    }
}

