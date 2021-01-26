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

namespace DashboardAdmin
{
    /// <summary>
    /// Interaction logic for EditPurchaseWindow.xaml
    /// </summary>
    public partial class EditPurchaseWindow : Window
    {
        private Purchase _data;
        public EditPurchaseWindow(Purchase p)
        {
            InitializeComponent();
            _data = p;
        }
        enum PurchaseStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
            Shipping = 4
        }

        MyStoreEntities db = new MyStoreEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var c = db.Customers.Find(_data.CustomerTel);
            orderIdTextBlock.Text = "DH" + _data.Id.ToString();
            customerNameTextBox.Text = c.Fullname;
            var purchaseStateOptions = new List<object>() {
                new { Key="Mới tạo", Value=PurchaseStatus.New},
                new { Key="Đã hủy", Value=PurchaseStatus.Cancelled},
                new { Key="Hoàn thành", Value=PurchaseStatus.Completed},
                new { Key="Đang giao", Value=PurchaseStatus.Shipping},
            };
            purchaseStatesComboBox.ItemsSource = purchaseStateOptions;
            purchaseStatesComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var c = db.Customers.Find(_data.CustomerTel);
            c.Fullname = customerNameTextBox.Text;
            db.SaveChanges();
            DialogResult = true;
        }
    }
}
