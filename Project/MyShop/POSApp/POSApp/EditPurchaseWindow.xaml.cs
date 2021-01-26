using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditPurchaseWindow.xaml
    /// </summary>
    public partial class EditPurchaseWindow : Window
    {
        private dynamic _data;
        public EditPurchaseWindow(dynamic p)
        {
            InitializeComponent();
            _data = p;
        }

        enum PurchaseStatus
        {
            New = 1,
            Completed = 2,
            Cancelled = 3,
            Shipping = 4
        }

        BadHabitsStoreEntities db = new BadHabitsStoreEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var c = db.Customers.Find(_data.Tel);
            orderIdTextBlock.Text = $"Mã đơn hàng: #{_data.Purchase_ID}";
            customerNameTextBox.Text = c.Customer_Name;
            customerTelTextBox.Text = c.Tel;
            customerAddressTextBox.Text = c.Address;
            customerEmailTextBox.Text = c.Email;

            var allPurchaseStatus = db.PurchaseStatusEnums.Where(x => x.EnumKey != "All").ToList();
            purchaseStatusComboBox.ItemsSource = allPurchaseStatus;

            int t = _data.Status;
            var currentStatus = db.PurchaseStatusEnums.FirstOrDefault(x => x.Value == t);
            purchaseStatusComboBox.SelectedItem = currentStatus;

            productsListView.ItemsSource = _data.Details;

            totalTextBlock.Text = $"{_data.Total.ToString("N0").Replace(",", ".") + " VNĐ"}";
        }

        private void purchaseStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = db.Customers.Find(_data.Tel);
            customer.Customer_Name = customerNameTextBox.Text;
            customer.Email = customerEmailTextBox.Text;
            customer.Address = customerAddressTextBox.Text;
            db.SaveChanges();

            dynamic item = purchaseStatusComboBox.SelectedItem;
            var purchase = db.Purchases.Find(_data.Purchase_ID);
            purchase.Status = item.Value;
            db.SaveChanges();

            DialogResult = true;
        }

        private void textBoxPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerTelTextBox.Text = Regex.Replace(customerTelTextBox.Text, "[^0-9]+", "");
        }
    }
}
