﻿using System;
using System.Collections.ObjectModel;

namespace Bank_System
{
    static class Bank
    {
        public static ObservableCollection<Department<Client>> Departments = new ObservableCollection<Department<Client>>(); //Main Bank collection

        private static Client defaultClient; //Default Client to Add/Edit

        public const float minPercent = 0.1f;
        public const float maxPercent = 9.9f;

        public const int minDeposit = 1;
        public const int maxDeposit = 1_000_000;

        public const string bankName = "Vivaldi Bank"; //Bank name
        public static readonly string[] departmentsNames = { "Common People Solutions", //Departments' names
                                                             "Aristocracy Solutions",
                                                             "Royal Solutions" };

        private const int bankSize = 21; //Default Clients quantity
        private static Random clientRandom = new Random(); //Random for Clients' data

        private static DateTime startDate = new DateTime(2020, 1, 1); //Starting date for Depasits
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
        /// Method to ADD Client
        /// </summary>
        /// <param name="clientClassIndex">Index of Department</param>
        public static void AddNewClient(int clientClassIndex, params string[] args)
        {
            if (args.Length >= 5)
                Departments[0].Departments[clientClassIndex].Add(ManageClient(clientClassIndex,
                                                                              args[0],
                                                                              args[1],
                                                                              args[2],
                                                                              args[3],
                                                                              args[4]));
            else
                Departments[0].Departments[clientClassIndex].Add(ManageClient(clientClassIndex,
                                                                              $"Name {(char)clientRandom.Next(128)}",
                                                                               $"Name {(char)clientRandom.Next(128)}",
                                                                               Convert.ToString(clientRandom.Next(2_000)),
                                                                               Convert.ToString(clientRandom.Next(1,6)),
                                                                               Convert.ToString(DateRandomizer())));
        }
        
        /// <summary>
        /// Method to EDIT Client
        /// </summary>
        /// <param name="oldClient">Client to EDIT</param>
        /// <param name="clientClassIndex">Client class Index</param>
        /// <param name="args">New Client Data</param>
        public static void EditClient(Client oldClient,
                                      int clientClassIndex,
                                      params string[] args)
        {
            Departments[0].Departments[clientClassIndex].Edit(oldClient,
                                                              ManageClient(clientClassIndex,
                                                                           args[0],
                                                                           args[1],
                                                                           args[2],
                                                                           args[3],
                                                                           args[4]));
        }

        /// <summary>
        /// Method to CREATE new Clinet
        /// </summary>
        /// <param name="clientIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static Client ManageClient(int clientIndex, params string[] args)
        {
            string name;
            string lastName;
            int deposit;
            float percent;
            DateTime dateTime;

            name = args[0] ?? $"Name {(char)clientRandom.Next(128)}";
            lastName = args[1] ?? $"Name {(char)clientRandom.Next(128)}";
            deposit = (int?)Convert.ToInt32(args[2]) ?? clientRandom.Next(2_000);
            percent = (float?)Convert.ToDouble(args[3]) ?? clientRandom.Next(10);
            dateTime = (DateTime?)Convert.ToDateTime(args[4]) ?? DateRandomizer();

            switch (clientIndex)
            {
                case 0:
                    defaultClient = new Common(name,
                                         lastName,
                                         deposit,
                                         percent,
                                         dateTime);
                    break;
                case 1:
                    defaultClient = new Aristocrat(name,
                                            lastName,
                                            deposit,
                                            percent,
                                            dateTime);
                    break;
                default:
                    defaultClient = new Royal(name,
                                       lastName,
                                       deposit,
                                       percent,
                                       dateTime);
                    break;
            }

            return defaultClient;
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
