using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    static class Bank
    {
        public static ObservableCollection<Department<Client>> Departments = new ObservableCollection<Department<Client>>();

        public const string bankName = "Vivaldi Bank";

        private const int bankSize = 21;
        private static Random clientRandom = new Random();

        private static DateTime startDate = new DateTime(1991,1,1);
        private static Random dateRandom = new Random();
        private static int range = (DateTime.Today - startDate).Days;

        public static void CreateBank()
        {
            Department<Client> bank = new Department<Client>(bankName);
            Bronze<Common> bronze = new Bronze<Common>("Common People Solutions");
            Silver<Aristocrat> silver = new Silver<Aristocrat>("Aristocracy Solutions");
            Gold<Royal> gold = new Gold<Royal>("Royal Solutions");

            Departments.Add(bank);

            Departments[0].Departments.Add(bronze);
            Departments[0].Departments.Add(silver);
            Departments[0].Departments.Add(gold);

            PopulateBank();
        }

        private static void PopulateBank()
        {           
            for (int i = 0; i < bankSize; i++)
            {
                int x = clientRandom.Next(3);



                switch (x)
                {
                    case 0: Departments[0].Departments[0].Add(new Common($"Name {i}",
                                                                         $"LastName {i}",
                                                                         clientRandom.Next(1000000),
                                                                         clientRandom.Next(10),
                                                                         DateRandomizer()));
                        break;
                    case 1:
                        Departments[0].Departments[1].Add(new Aristocrat($"Name {i}",
                                                                 $"LastName {i}",
                                                                 clientRandom.Next(1000000),
                                                                 clientRandom.Next(10),
                                                                 DateRandomizer()));
                        break;
                    default:
                        Departments[0].Departments[2].Add(new Royal($"Name {i}",
                                                                 $"LastName {i}",
                                                                 clientRandom.Next(1000000),
                                                                 clientRandom.Next(10),
                                                                 DateRandomizer()));
                        break;
                }
            }            
        }

        private static DateTime DateRandomizer()
        {            
            return startDate.AddDays(dateRandom.Next(range));
        }
    }
}
