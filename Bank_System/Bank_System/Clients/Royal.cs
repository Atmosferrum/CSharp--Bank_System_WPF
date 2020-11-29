using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Royal : Client
    {

        #region Constructor;

        public Royal(string Name,
                     string LastName,
                     int Deposit,
                     double Percent,
                     int Accumulation,
                     DateTime DateOfDeposit)
            : base(Name,
                   LastName,
                   Deposit,
                   Percent,
                   Accumulation,
                   DateOfDeposit)
        {

        }

        #endregion Constructor
    }
}
