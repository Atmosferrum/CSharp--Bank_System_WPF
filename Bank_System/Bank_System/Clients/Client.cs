using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class Client : IEquatable<Client>
    {
        #region Constructor;

        public Client(string Name,
                      string LastName,
                      int Deposit,
                      float Percent,
                      DateTime DateOfDeposit)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Deposit = Deposit;
            this.Percent = Percent;
            this.DateOfDeposit = DateOfDeposit;
            this.Status = this.GetType().Name;

            Total();
        }

        #endregion Constructor

        #region Properties;

        public string Status { get; private set; } //Property to GET or SET Status
        public string Name { get; set; } //Property to GET or SET Name
        public string LastName { get; set; } //Property to GET or SET LastName
        public int Deposit { get; set; } //Property to GET or SET Deposit
        public float Percent { get; set; } //Property to GET or SET Percent
        public float Accumulation { get; set; } //Property to GET or SET Accumulation
        public DateTime DateOfDeposit { get; set; }

        #endregion Properties

        #region Methods;

        /// <summary>
        /// Method to COUNT number of Months
        /// between DayOfDeposit and DateTime.Now
        /// </summary>
        /// <returns></returns>
        private int NumberOfMonths()
        {
            return Math.Abs(DateTime.Now.Month - this.DateOfDeposit.Month)
                           + 12 * (DateTime.Now.Year - this.DateOfDeposit.Year);
        }

        /// <summary>
        /// Methodto COUNT Acummulation
        /// </summary>
        private void Total()
        {
            if (this.Deposit >= 1_000)
            {
                
                float total = this.Deposit;

                for (int i = 0; i < NumberOfMonths(); i++)
                {
                    float midTotal = 0;

                    midTotal += (total / 100 * Percent);
                    total += midTotal;
                }

                this.Accumulation = (total - this.Deposit);
            }
            else
            {
                float total = 0;

                for (int i = 0; i < NumberOfMonths(); i++)
                {
                    total += ((float)this.Deposit / 100 * Percent);
                }

                this.Accumulation = total;
            }
        }

        #endregion Methods

        #region Interfaces;

        /// <summary>
        /// Method for IEquatable Interface
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Client other)
        {
            return this.Name == other.Name
                && this.LastName == other.LastName
                && this.Deposit == other.Deposit
                && this.Percent == other.Percent
                && this.Accumulation == other.Accumulation
                && this.DateOfDeposit == other.DateOfDeposit;
        }

        #endregion Interfaces

    }
}
