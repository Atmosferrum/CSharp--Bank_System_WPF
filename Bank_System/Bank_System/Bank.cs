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
            Bronze<Common> bronze = new Bronze<Common>("Common people solutions");
            Silver<Aristocrat> silver = new Silver<Aristocrat>("Aristocracy Solutions");
            Gold<Royal> gold = new Gold<Royal>("Royal Solutions");

            Common common1 = new Common("Common", "Man", 10, 1, 10, DateTime.Now);
            Aristocrat aristocrat1 = new Aristocrat("Common", "Man", 10, 1, 10, DateTime.Now);
            Royal royal1 = new Royal("Common", "Man", 10, 1, 10, DateTime.Now);

            departments.Add(bronze);
            departments.Add(silver);
            departments.Add(gold);

        }
    }
}
