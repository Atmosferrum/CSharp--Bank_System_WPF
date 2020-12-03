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
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        private MainWindow mainWindow;
        private Client client;
        private int clientClassIndex;

        private bool inputDataIsCorrect => TB_EditClientName.Text != ""  //Bool to CHECK if input Data is correct
                                        && TB_EditClientLastName.Text != ""
                                        && Int32.TryParse(TB_EditClientDeposit.Text, out deposit)
                                        && Double.TryParse(TB_EditClientPercent.Text, out percent)
                                        && DateTime.TryParse(DP_EditClientDateOfDeposit.Text, out dateOfDeposit);

        private int deposit; //Variable to get PARSED deposit
        private double percent; //Variable to get PARSED percent
        private DateTime dateOfDeposit; //Variable to get PARSED date of deposit


        public EditClientWindow(MainWindow mainWindow,
                                Client client,
                                int clientClassIndex)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.client = client;
            this.clientClassIndex = clientClassIndex;
        }

        private void BTN_Clients_EditClient(object sender, RoutedEventArgs e)
        {
            if (inputDataIsCorrect)
            {
                Bank.EditClient(client,
                                clientClassIndex,
                                TB_EditClientName.Text,
                                TB_EditClientLastName.Text,
                                Convert.ToString(deposit),
                                Convert.ToString(percent),
                                Convert.ToString(dateOfDeposit));

                CloseWindow();
            }
            else
                MessageBox.Show($"The DATA you are entering is wrong!",
                                $"{EditClientWindow.TitleProperty.Name}",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
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
