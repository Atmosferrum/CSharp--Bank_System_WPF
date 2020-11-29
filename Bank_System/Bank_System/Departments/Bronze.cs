using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Bronze<T> : Department
    {
        public Bronze(string Name)
               : base(Name)
        {

        }

        public Client SetValue { set => throw new NotImplementedException(); }

        public Client GetValue => throw new NotImplementedException();

        public Client GetValueMethod()
        {
            throw new NotImplementedException();
        }

        public void SetValueMethod(Client args)
        {
            throw new NotImplementedException();
        }
    }
}
