using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9A
{
    class DynamicStack<T> : DynamicArray<T> , IMyStack<T>
    {
        public DynamicStack(int maxSize)
        {
            sizeOfDynamicArr = 0;
            capacityOfDynamicArr = 0;
            MaxSize = maxSize;
        }

        protected override void Add(T newAdd)
        {
            if (sizeOfDynamicArr > 0 && sizeOfDynamicArr < capacityOfDynamicArr)
            {
                DynamicArr[sizeOfDynamicArr] = newAdd;
                sizeOfDynamicArr++;
            }
            else if (sizeOfDynamicArr > 0 && sizeOfDynamicArr >= capacityOfDynamicArr)
            {
                IncreaseSize();
                DynamicArr[sizeOfDynamicArr] = newAdd;
                sizeOfDynamicArr++;
            }
            else if(sizeOfDynamicArr == 0)
            {
                IncreaseSize();
                DynamicArr[sizeOfDynamicArr] = newAdd;
                sizeOfDynamicArr++;
            }
        }

        protected override void Insert(int inx, T newAdd)
        {
            if (sizeOfDynamicArr < capacityOfDynamicArr && inx < sizeOfDynamicArr && inx >= 0)
            {
                T[] DynamicArrLower = new T[inx];
                int j = 0;
                for (int i = 0; i < inx; i++)
                {
                    DynamicArrLower[j] = DynamicArr[i];
                    j++;
                }

                T[] DynamicArrUpper = new T[sizeOfDynamicArr - inx];
                int k = 0;
                for (int i = inx; i < sizeOfDynamicArr; i++)
                {
                    DynamicArrUpper[k] = DynamicArr[i];
                    k++;
                }
                int m = 0;
                int n = 0;
                for (int i = 0; i < j; i++)
                {
                    DynamicArr[i] = DynamicArrLower[m];
                    m++;
                }
                DynamicArr[m] = newAdd;
                for (int i = j + 1; i < k + j + 1; i++)
                {
                    DynamicArr[i] = DynamicArrUpper[n];
                    n++;
                }
                sizeOfDynamicArr++;
            }
            else
            {
                IncreaseSize();

                T[] DynamicArrLower = new T[inx];
                int j = 0;
                for (int i = 0; i < inx; i++)
                {
                    DynamicArrLower[j] = DynamicArr[i];
                    j++;
                }

                T[] DynamicArrUpper = new T[sizeOfDynamicArr - inx];
                int k = 0;
                for (int i = inx; i < sizeOfDynamicArr; i++)
                {
                    DynamicArrUpper[k] = DynamicArr[i];
                    k++;
                }
                int m = 0;
                int n = 0;
                for (int i = 0; i < j; i++)
                {
                    DynamicArr[i] = DynamicArrLower[m];
                    m++;
                }
                DynamicArr[m] = newAdd;
                for (int i = j + 1; i < k + j + 1; i++)
                {
                    DynamicArr[i] = DynamicArrUpper[n];
                    n++;
                }
                sizeOfDynamicArr++;
            } 
        }

        protected override T Get(int inx)
        {
            if (inx >= 0 && inx < sizeOfDynamicArr)
            {
                return DynamicArr[inx];
            }
            return TValue;
        }

        protected override T Remove(int inx)
        {
            if (sizeOfDynamicArr <= capacityOfDynamicArr / 2 && inx < sizeOfDynamicArr && inx >= 0)
            {
                DecreaseSize();

                T[] DynamicArrLower = new T[inx];
                int j = 0;
                for (int i = 0; i < inx; i++)
                {
                    DynamicArrLower[j] = DynamicArr[i];
                    j++;
                }
                TValue = DynamicArr[inx]; // value to remove

                T[] DynamicArrUpper = new T[sizeOfDynamicArr - inx - 1];
                int k = 0;
                for (int i = inx + 1; i < sizeOfDynamicArr; i++)
                {
                    DynamicArrUpper[k] = DynamicArr[i];
                    k++;
                }
                int m = 0;
                int n = 0;
                for (int i = 0; i < j - 1; i++)
                {
                    DynamicArr[i] = DynamicArrLower[m];
                    m++;
                }
                for (int i = j; i < j + k; i++)
                {
                    DynamicArr[i] = DynamicArrUpper[n];
                    n++;
                }
                sizeOfDynamicArr--;
                if(sizeOfDynamicArr == 0) {
                    DynamicArr = null;
                    capacityOfDynamicArr = 0;
                }
                return TValue;
            }
            else if(inx < sizeOfDynamicArr && inx >= 0)
            {
                T[] DynamicArrLower = new T[inx];
                int j = 0;
                for (int i = 0; i < inx; i++)
                {
                    DynamicArrLower[j] = DynamicArr[i];
                    j++;
                }
                TValue = DynamicArr[inx]; // value ot remove

                T[] DynamicArrUpper = new T[sizeOfDynamicArr - inx];
                int k = 0;
                for (int i = inx+1; i < sizeOfDynamicArr; i++)
                {
                    DynamicArrUpper[k] = DynamicArr[i];
                    k++;
                }
                int m = 0;
                int n = 0;
                for (int i = 0; i < j; i++)
                {
                    DynamicArr[i] = DynamicArrLower[m];
                    m++;
                }
                for (int i = j; i < j + k; i++)
                { 
                    DynamicArr[i] = DynamicArrUpper[n];
                    n++;
                }
                sizeOfDynamicArr--;
                if (sizeOfDynamicArr == 0)
                {
                    DynamicArr = null;
                    capacityOfDynamicArr = 0;
                }
                return TValue;
            }
            return TValue;
        }
        protected override void IncreaseSize()
        {
            if (sizeOfDynamicArr >= capacityOfDynamicArr && sizeOfDynamicArr > 0)
            {
                capacityOfDynamicArr = sizeOfDynamicArr + sizeOfDynamicArr;
                T[] TempDynamicArr = new T[capacityOfDynamicArr];

                for (int i = 0; i < sizeOfDynamicArr; i++)
                {
                    TempDynamicArr[i] = DynamicArr[i];
                }

                DynamicArr = new T[capacityOfDynamicArr];
                for (int i = 0; i < sizeOfDynamicArr; i++)
                {
                    DynamicArr[i] = TempDynamicArr[i];
                }
            }
            else if (sizeOfDynamicArr == 0)
            {
                capacityOfDynamicArr = 2;
                sizeOfDynamicArr = 0;
                DynamicArr = new T[capacityOfDynamicArr];
            }
        }
        protected override void DecreaseSize()
        {
            if (sizeOfDynamicArr <= capacityOfDynamicArr / 2 && sizeOfDynamicArr >= 0)
            {
                capacityOfDynamicArr = capacityOfDynamicArr / 2;
                T[] TempDynamicArr = new T[sizeOfDynamicArr];

                for (int i = 0; i < sizeOfDynamicArr; i++)
                {
                    TempDynamicArr[i] = DynamicArr[i];
                }

                DynamicArr = new T[capacityOfDynamicArr];
                for (int i = 0; i < sizeOfDynamicArr; i++)
                {
                    DynamicArr[i] = TempDynamicArr[i];
                }
                sizeOfDynamicArr = capacityOfDynamicArr;
            }
        }

        protected override int Size()
        {
            return sizeOfDynamicArr;
        }

        public override bool IsFull()
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

        public override bool IsEmpty()
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

        public override T  Peek()
        {
           return Get(sizeOfDynamicArr);
        }

        public override void Print()
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

        public void Push(T newTop)
        {
            if (!IsFull())
            {
                Add(newTop); // push one element
            }
        }

        public T Pop()
        {
            if (!IsEmpty())
            {
                return Remove(sizeOfDynamicArr - 1);  // save value from the top and pass it out from the method 
            }
            return TValue;
        }
    }
}
