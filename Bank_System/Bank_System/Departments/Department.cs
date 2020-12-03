using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Department<T> : ICollection<T>, IEnumerable<T>
    {
        public ObservableCollection<Department<Client>> Departments { get; set; } //Collection of inner Departments

        protected T[] items; //Array of Items in this.Collection.Generic
        protected int size; //Size of this.Colletion.Generic

        #region Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        public Department(string Name)
        {
            this.Name = Name;
            this.items = new T[0];
            this.size = 0;
            this.Departments = new ObservableCollection<Department<Client>>();
        }

        #endregion Constructor

        #region Properties;

        /// <summary>
        /// Property to GET Name
        /// </summary>
        public string Name { get; }

        #endregion Properties

        #region Indexers;

        /// <summary>
        /// Indexer by [i] = int
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        public Client this[string name, string lastName, int deposit, double percent, DateTime dateOfDeposit]
        {
            get
            {
                Client client = null;
                foreach (var item in this.items)
                {
                    if ((item as Client).Name == name
                     && (item as Client).LastName == lastName
                     && (item as Client).Deposit == deposit
                     && (item as Client).Percent == percent
                     && (item as Client).DateOfDeposit == dateOfDeposit)
                    { client = item as Client; break; }
                }
                return client;
            }
        }

        #endregion Indexers

        /// <summary>
        /// Method to ADD new Item in this.Collection.Generic
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if(size >= items.Length)
                ResizeArray();

            this.items[size] = item;
            this.size++;
        }

        /// <summary>
        /// Method to Resize this.Collection.Generic
        /// </summary>
        private void ResizeArray()
        {
            Array.Resize(ref this.items, size + 1);
        }

        /// <summary>
        /// Method to CLEAR this.Collection.Generic
        /// </summary>
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
        
        /// <summary>
        /// Method to REMOVE Item from this.Collection.Generic
        /// </summary>
        /// <param name="item"></param>
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

            for (int i = tempI; i < size; i++)
            {
                items[i] = items[i + 1];
            }

            items[size] = default(T);
        }

        public void Edit(T oldItem, T newItem)
        {
            for (int i = 0; i < size; i++)
            {
                if (items[i].Equals(oldItem))                
                    items[i] = newItem;                
            }
        }

        #region Interfaces;

        /// <summary>
        /// IEnumerator implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return items.Take(size).GetEnumerator();
        }

        /// <summary>
        /// IEnumerator implementation
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion Interfaces       
    }
}
