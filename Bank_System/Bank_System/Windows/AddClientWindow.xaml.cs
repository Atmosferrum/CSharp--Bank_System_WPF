using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Bank_System.Windows
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private int clientClassIndex;
        private MainWindow mainWindow;

        public AddClientWindow(MainWindow mainWindow,
                               int clientClassIndex)
        {
            InitializeComponent();

            this.clientClassIndex = clientClassIndex;
            this.mainWindow = mainWindow;
        }

        private void BTN_Clients_AddClient(object sender, RoutedEventArgs e)
        {
            Bank.AddNewClient(clientClassIndex);
            CloseWindow();
        }

        /// <summary>
        /// Method to CLOSE this Window
        /// </summary>
        private void CloseWindow()
        {
            mainWindow.LoadClientsToLV();
            this.Close();
        }
    }
}
