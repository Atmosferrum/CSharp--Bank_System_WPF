using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Client
    {
        #region Constructor;

        public Client(string Name,
                      string LastName,
                      int Deposit,
                      double Percent,
                      int Accumulation,
                      DateTime DateOfDeposit)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Deposit = Deposit;
            this.Percent = Percent;
            this.Accumulation = Accumulation;
            this.DateOfDeposit = DateOfDeposit;
        }

        #endregion Constructor

        #region Properties;

        public string Name { get; set; } //Property to GET or SET Name
        public string LastName { get; set; } //Property to GET or SET LastName
        public int Deposit { get; set; } //Property to GET or SET Deposit
        public double Percent { get; set; } //Property to GET or SET Percent
        public int Accumulation { get; set; } //Property to GET or SET Accumulation
        public DateTime DateOfDeposit {get;} // Property to GET DateOfDeposit

        #endregion Properties

    }
}
