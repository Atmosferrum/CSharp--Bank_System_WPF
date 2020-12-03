using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    static class Bank
    {
        public static ObservableCollection<Department<Client>> Departments = new ObservableCollection<Department<Client>>(); //Main Bank collection

        public const string bankName = "Vivaldi Bank"; //Bank name
        public static readonly string[] departmentsNames = { "Common People Solutions", //Departments' names
                                                             "Aristocracy Solutions",
                                                             "Royal Solutions" };

        private const int bankSize = 21; //Default Clients quantity
        private static Random clientRandom = new Random(); //Random for Clients' data

        private static DateTime startDate = new DateTime(1991, 1, 1); //Starting date for Depasits
        private static Random dateRandom = new Random(); //Random for Date
        private static int range = (DateTime.Today - startDate).Days; //Range for Date to choose

        /// <summary>
        /// /Creating deault Bank
        /// </summary>
        public static void CreateBank()
        {
            Department<Client> bank = new Department<Client>(bankName);
            Bronze<Common> bronze = new Bronze<Common>(departmentsNames[0]);
            Silver<Aristocrat> silver = new Silver<Aristocrat>(departmentsNames[1]);
            Gold<Royal> gold = new Gold<Royal>(departmentsNames[2]);

            Departments.Add(bank);

            Departments[0].Departments.Add(bronze);
            Departments[0].Departments.Add(silver);
            Departments[0].Departments.Add(gold);

            PopulateBank();
        }

        /// <summary>
        /// Adding random Clients to Bank
        /// </summary>
        private static void PopulateBank()
        {
            for (int i = 0; i < bankSize; i++)
            {
                int x = clientRandom.Next(3);
                AddNewClient(x);
            }
        }

        /// <summary>
        /// Date randomizer
        /// </summary>
        /// <returns></returns>
        private static DateTime DateRandomizer()
        {
            return startDate.AddDays(dateRandom.Next(range));
        }

        /// <summary>
        /// Method to add Client
        /// </summary>
        /// <param name="x">Index of Department</param>
        public static void AddNewClient(int x, params string[] args)
        {
            string name;
            string lastName;
            int deposit;
            double percent;
            DateTime dateTime;

            if (args.Length >= 5)
            {
                name = args[0] ?? $"Name {(char)clientRandom.Next(128)}";
                lastName = args[1] ?? $"Name {(char)clientRandom.Next(128)}";
                deposit = (int?)Convert.ToInt32(args[2]) ?? clientRandom.Next(1000000);
                percent = (double?)Convert.ToDouble(args[3]) ?? clientRandom.Next(10);
                dateTime = (DateTime?)Convert.ToDateTime(args[4]) ?? DateRandomizer();
            }
            else
            {
                name = $"Name {(char)clientRandom.Next(128)}";
                lastName = $"Name {(char)clientRandom.Next(128)}";
                deposit = clientRandom.Next(1000000);
                percent = clientRandom.Next(10);
                dateTime = DateRandomizer();
            }

            switch (x)
            {
                case 0:
                    Departments[0].Departments[x].Add(new Common(name,
                                                                 lastName,
                                                                 deposit,
                                                                 percent,
                                                                 dateTime));
                    break;
                case 1:
                    Departments[0].Departments[x].Add(new Aristocrat(name,
                                                                     lastName,
                                                                     deposit,
                                                                     percent,
                                                                     dateTime));
                    break;
                default:
                    Departments[0].Departments[x].Add(new Royal(name,
                                                                lastName,
                                                                deposit,
                                                                percent,
                                                                dateTime));
                    break;
            }
        }

        public static void EditClient(Client oldClient,
                                      int clientClassIndex,
                                      params string[] args)
        {
            Client newClient;

            string name;
            string lastName;
            int deposit;
            double percent;
            DateTime dateTime;

            if (args.Length >= 5)
            {
                name = args[0] ?? $"Name {(char)clientRandom.Next(128)}";
                lastName = args[1] ?? $"Name {(char)clientRandom.Next(128)}";
                deposit = (int?)Convert.ToInt32(args[2]) ?? clientRandom.Next(1000000);
                percent = (double?)Convert.ToDouble(args[3]) ?? clientRandom.Next(10);
                dateTime = (DateTime?)Convert.ToDateTime(args[4]) ?? DateRandomizer();
            }
            else
            {
                name = $"Name {(char)clientRandom.Next(128)}";
                lastName = $"Name {(char)clientRandom.Next(128)}";
                deposit = clientRandom.Next(1000000);
                percent = clientRandom.Next(10);
                dateTime = DateRandomizer();
            }

            switch (clientClassIndex)
            {
                case 0:
                    newClient = new Common(name,
                                         lastName,
                                         deposit,
                                         percent,
                                         dateTime);
                    break;
                case 1:
                    newClient = new Aristocrat(name,
                                            lastName,
                                            deposit,
                                            percent,
                                            dateTime);
                    break;
                default:
                    newClient = new Royal(name,
                                       lastName,
                                       deposit,
                                       percent,
                                       dateTime);
                    break;
            }

            Departments[0].Departments[clientClassIndex].Edit(oldClient, newClient);
        }

        /// <summary>
        /// Method ot REMOVE Client
        /// </summary>
        /// <param name="x"></param>
        /// <param name="client"></param>
        public static void RemoveClient(int x, Client client)
        {
            Departments[0].Departments[x].Remove(client);
        }
    }
}
