using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Bronze<T> : Department, ICollection<T>
        where T : Common
    {
        T[] items;
        int size;

        public Bronze(string Name)
               : base(Name)
        {
            items = new T[0];
            size = 0;
        }
        
        public T this[int index]
        {
            get
            {
                if (index > size)
                    throw new IndexOutOfRangeException("Index is out of range !");
                else
                    return this.items[index]; }
            set
            {
                if (index > size)
                    throw new IndexOutOfRangeException("Index is out of range !");
                else
                    this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            this.items[size] = item;
            this.size++;
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                this.items[i] = null;
            }

            this.size = 0;
            T[] temp = new T[size];

            this.items = temp;
        }

        public void Remove(T item)
        {
            int tempI = 0;

            for (int i = 0; i < size; i++)
            {
                if (items[i].Equals(item))
                {
                    items[i] = null;
                    tempI = i;
                    size--;
                }
            }

            for (int i = tempI; i > size; i++)
            {
                items[i] = items[i + 1];
            }

            items[size] = null;
        }
    }
}
