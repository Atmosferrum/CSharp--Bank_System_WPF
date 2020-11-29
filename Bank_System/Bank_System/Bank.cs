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
        public static ObservableCollection<Department> departments = new ObservableCollection<Department>();

        public const string bankName = "Vivaldi Bank";

        public static void CreateBank()
        {
            Bronze<Client> bronze = new Bronze<Client>("Common people solutions");
            Silver<Client> silver = new Silver<Client>("Aristocracy Solutions");
            Gold<Client> gold = new Gold<Client>("Royal Solutions");

            Common common1 = new Common("Common", "Man", 10, 1, 10, DateTime.Now);
            Aristocrat aristocrat1 = new Aristocrat("Common", "Man", 10, 1, 10, DateTime.Now);
            Royal royal1 = new Royal("Common", "Man", 10, 1, 10, DateTime.Now);


            departments.Add(bronze);
            departments.Add(silver);
            departments.Add(gold);

        }
    }
}
