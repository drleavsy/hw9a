using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9A
{
    abstract class DynamicArrayAbstract<T> 
    {
        protected int sizeOfDynamicArr;
        protected int capacityOfDynamicArr;
        protected T [] DynamicArr;
        protected int MaxSize;
        protected T TValue; //
        protected int count; // 

        abstract protected void Add(T newAdd);
        abstract protected void IncreaseSize();
        abstract protected void DecreaseSize();
        abstract protected void Insert(int inx,T newAdd);
        abstract protected T Get(int inx);
        abstract protected T Remove(int inx);
/*
        public abstract bool IsFull();
        public abstract bool IsEmpty();
        public abstract T Peek();
        public abstract void Print();*/
    }
}
