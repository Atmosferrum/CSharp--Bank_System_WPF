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
        private int clientClassIndex; //Calss index for new Client
        private MainWindow mainWindow; //MainWindow reference

        private bool inputDataIsCorrect => TB_AddClientName.Text != ""  //Bool to CHECK if input Data is correct
                                        && TB_AddClientLastName.Text != ""                       
                                        && Int32.TryParse(TB_AddClientDeposit.Text, out deposit)
                                        && Double.TryParse(TB_AddClientPercent.Text, out percent);

        private int deposit; //Variable to get PARSED Deposit Data
        private double percent; //Variable to get PARSED Percent Data

        #region Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="clientClassIndex"></param>
        public AddClientWindow(MainWindow mainWindow,
                               int clientClassIndex)
        {
            InitializeComponent();

            this.clientClassIndex = clientClassIndex;
            this.mainWindow = mainWindow;
        }

        #endregion Constructor

        /// <summary>
        /// Method to ADD new Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clients_AddClient(object sender, RoutedEventArgs e)
        {
            if (inputDataIsCorrect)
            {
                Bank.AddNewClient(clientClassIndex,
                                   TB_AddClientName.Text,
                                   TB_AddClientLastName.Text,
                                   Convert.ToString(deposit),
                                   Convert.ToString(percent),
                                   Convert.ToString(DateTime.Now));
                CloseWindow();
            }
            else
                MessageBox.Show($"The DATA you are entering is wrong!",
                                $"{AddClientWindow.TitleProperty.Name}",
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
