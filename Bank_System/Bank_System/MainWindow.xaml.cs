using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Bank_System.Windows;

namespace Bank_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bank.CreateBank();

            TV_Departments.ItemsSource = Bank.Departments;            
        }

        private void TV_Departments_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //LV_Clients.ItemsSource = TV_Departments.SelectedItem as Department<Client>;
            LoadClientsToLV();
        }

        private void BTN_Clients_AddClient(object sender, RoutedEventArgs e)
        {
                AddClientWindow AddClientWindow = new AddClientWindow(this, Bank.Departments[0].Departments.IndexOf(TV_Departments?.SelectedItem as Department<Client>));
                AddClientWindow.Show();
        }

        private void BTN_Clients_EditClient(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Clients_RemoveClient(object sender, RoutedEventArgs e)
        {

        }

        public void LoadClientsToLV()
        {
            LV_Clients.ItemsSource = (TV_Departments.SelectedItem as Department<Client>).Where(x => x != null);
        }
    }
}
