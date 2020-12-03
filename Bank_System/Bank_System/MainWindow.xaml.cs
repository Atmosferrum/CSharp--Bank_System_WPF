using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Bank.CreateBank();

            TV_Departments.ItemsSource = Bank.Departments;
        } 

        #endregion Constructor

        /// <summary>
        /// Method on TreeView Departments selection CHANGES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TV_Departments_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LoadClientsToLV();
        }


        #region Elements' Methods;

        /// <summary>
        /// Button Method to ADD new Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clients_AddClient(object sender, RoutedEventArgs e)
        {
            if (TV_Departments.SelectedItem != null)
            {
                if ((TV_Departments?.SelectedItem as Department<Client>).Name != Bank.bankName)
                {
                    AddClientWindow AddClientWindow = new AddClientWindow(this, 
                                                                          Bank.Departments[0].Departments.IndexOf(TV_Departments?.SelectedItem as Department<Client>));
                    AddClientWindow.Show();
                }
            }
        }

        /// <summary>
        /// Button Method to EDIT existing Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clients_EditClient(object sender, RoutedEventArgs e)
        {
            if (TV_Departments.SelectedItem != null & LV_Clients.SelectedItem != null)
            {
                if ((TV_Departments?.SelectedItem as Department<Client>).Name != Bank.bankName)
                {
                    EditClientWindow EditClientWindow = new EditClientWindow(this, 
                                                                             LV_Clients.SelectedItem as Client,
                                                                             Bank.Departments[0].Departments.IndexOf(TV_Departments?.SelectedItem as Department<Client>));
                    EditClientWindow.Show();
                }
            }
        }

        /// <summary>
        /// Button Method to REMOVE Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clients_RemoveClient(object sender, RoutedEventArgs e)
        {
            if (LV_Clients.SelectedItem != null)
                Bank.RemoveClient(Bank.Departments[0].Departments.IndexOf((TV_Departments.SelectedItem as Department<Client>)),
                                              LV_Clients.SelectedItem as Client);

            LoadClientsToLV();
        }

        #endregion Elements' Methods


        #region Additional Methods;

        /// <summary>
        /// Method to RELOAD ListView of Clietns
        /// </summary>
        public void LoadClientsToLV()
        {
            LV_Clients.ItemsSource = (TV_Departments.SelectedItem as Department<Client>).Where(x => x != null);
        } 

        #endregion Additional Methods
    }
}
