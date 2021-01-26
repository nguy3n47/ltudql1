using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddPurchaseWindow.xaml
    /// </summary>
    public partial class AddPurchaseWindow : Window
    {
        public AddPurchaseWindow()
        {
            InitializeComponent();
        }

        private void addPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            var t = list.Sum((dynamic p) => Convert.ToInt32(p.SubTotal));
            var purchase = new Purchase()
            {
                CreatedAt = DateTime.Now,
                Total = Convert.ToDecimal(t),
                CustomerTel = customerTelTextBox.Text,
            };

            var customer = new Customer()
            {
                Tel = customerTelTextBox.Text,
                Fullname = customerNameTextBox.Text
            };

            foreach (dynamic item in list)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = item.Product_ID,
                    Price = item.Unit_Price,
                    Quantity = item.Quantity,
                    Total = item.SubTotal,
                    CreatedAt = DateTime.Now,
                };
                purchase.OrderDetails.Add(orderDetail);
                db.OrderDetails.Add(orderDetail);
            }
            db.Customers.Add(customer);
            db.Purchases.Add(purchase);
            db.SaveChanges();

            MessageBox.Show("Thêm đơn hàng mới thành công!");

            DialogResult = true;
        }

        MyStoreEntities db = new MyStoreEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = db.Products.ToList();
            productsListView.ItemsSource = query.ToList();
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }


        BindingList<object> list = new BindingList<object>();

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            var item = productsListView.SelectedItem as Product;

            // Kiểm tra sản phẩm đã có sẵn hay chưa
            var foundIndex = -1;
            for (int i = 0; i < list.Count; i++)
            {
                dynamic p = list[i];
                if (p.Product_ID == item.Id)
                {
                    var updatedProduct = new
                    {
                        Product_ID = item.Id,
                        Product_Name = item.Name,
                        SubTotal = (p.Quantity + 1) * p.Unit_Price,
                        Quantity = p.Quantity + 1,
                        Unit_Price = p.Unit_Price
                    };
                    list.RemoveAt(i);
                    list.Insert(i, updatedProduct);

                    foundIndex = i; // báo hiệu đã tìm thấy
                }
            }

            if (foundIndex == -1) // Chưa cập nhật
            {
                list.Add(new
                {
                    Product_ID = item.Id,
                    Product_Name = item.Name,
                    Quantity = 1,
                    Unit_Price = item.Price,
                    SubTotal = item.Price
                });
            }
            selectedProductsListView.ItemsSource = list;
            double newValue = double.Parse(list.Sum((dynamic p) => Convert.ToInt32(p.SubTotal)).ToString());
            totalTextBlock.Text = $"Tổng tiền: {newValue.ToString("N0").Replace(",", ".") + " VNĐ"}";
        }
    }
}
