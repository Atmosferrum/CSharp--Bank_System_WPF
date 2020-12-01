using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Department<T> : ICollection<T>, IEnumerable<T>
    {
        public ObservableCollection<Department<Client>> Departments { get; set; }

        protected T[] items;
        protected int size;

        #region Constructor;

        public Department(string Name)
        {
            this.Name = Name;
            this.items = new T[0];
            this.size = 0;
            this.Departments = new ObservableCollection<Department<Client>>();
        }
        public T this[int index]
        {
            get
            {
                if (index > size)
                    throw new IndexOutOfRangeException("Index is out of range !");
                else
                    return this.items[index];
            }
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
            ResizeArray();
            this.items[size] = item;
            this.size++;
        }

        private void ResizeArray()
        {
            Array.Resize(ref this.items, this.size == 0 ? 4 : this.items.Length * 2);
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                this.items[i] = default(T);
            }

            this.size = 0;
            T[] temp = new T[size];

            this.items = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            int tempI = 0;

            for (int i = 0; i < size; i++)
            {
                if (items[i].Equals(item))
                {
                    items[i] = default(T);
                    tempI = i;
                    size--;
                }
            }

            for (int i = tempI; i > size; i++)
            {
                items[i] = items[i + 1];
            }

            items[size] = default(T);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }


        #endregion Constructor

        #region Properties;

        public string Name { get; }

        #endregion Properties
    }
}
