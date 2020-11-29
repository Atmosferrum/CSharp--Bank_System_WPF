using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Department
    {

        #region Constructor;

        public Department(string Name)
        {
            this.Name = Name;
        }

        #endregion Constructor

        #region Properties;

        public string Name { get; }

        #endregion Properties
    }
}
