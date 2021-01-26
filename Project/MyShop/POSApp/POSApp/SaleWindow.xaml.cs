using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POSApp
{
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public SaleWindow()
        {
            InitializeComponent();
        }
        MasterDataUserControl master = new MasterDataUserControl();
        TransactionUserControl transaction = new TransactionUserControl();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabsContent.ItemsSource = new ObservableCollection<TabItem>()
            {
                new TabItem() { Content = master, Visibility = Visibility.Collapsed,},
                new TabItem() { Content = transaction, Visibility = Visibility.Collapsed}
            };

            tabsContent.SelectedIndex = 0;
            master.UserControl_Initialized(sender, e);
        }

        private void masterData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabsContent.SelectedIndex = 0;
            masterDataBorder.BorderThickness = new Thickness(1, 1, 1, 1);
            transactionBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            master.UserControl_Initialized(sender, e);
        }

        private void logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void transactionData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabsContent.SelectedIndex = 1;
            masterDataBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            transactionBorder.BorderThickness = new Thickness(1, 1, 1, 1);
            transaction.UserControl_Initialized(sender, e);
        }
    }
}
