using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace POSApp
{
    /// <summary>
    /// Interaction logic for TransactionUserControl.xaml
    /// </summary>
    public partial class TransactionUserControl : UserControl
    {
        public TransactionUserControl()
        {
            InitializeComponent();
        }

        enum PurchaseStatus
        {
            All = -1,
            New = 1,
            Cancelled = 2,
            Completed = 3,
            Shipping = 4
        }
        BadHabitsStoreEntities db = new BadHabitsStoreEntities();
        IQueryable<Purchase> dateFilter;
        void loadAllPurchases()
        {
            if (fromDatePicker.SelectedDate != null && toDatePicker.SelectedDate != null)
            {
                var from = (DateTime)fromDatePicker.SelectedDate;
                var to = (DateTime)toDatePicker.SelectedDate;
                to = to.AddDays(1);
                dateFilter = db.Purchases.Where(p => (from <= p.Created_At) && (p.Created_At <= to));
            }
            else
            {
                dateFilter = db.Purchases;
            }

            int status = (purchaseStatesComboBox.SelectedItem as PurchaseStatusEnum).Value;
            var keyword = keywordTextBox.Text;
            var query = dateFilter.GroupJoin(db.Customers,
            p => p.Customer_Tel,
            c => c.Tel,
            (x, y) => new { Purchases = x, Customers = y }
            )
            .SelectMany(
                 x => x.Customers.DefaultIfEmpty(),
                 (x, y) => new { Purchase = x.Purchases, Customer = y }
             )
             .Select(item => new {
                 item.Purchase.Status,
                 item.Purchase.Purchase_ID,
                 item.Purchase.Total,
                 item.Purchase.Created_At,
                 item.Customer.Customer_Name,
                 item.Customer.Tel,
                 item.Customer.Address,
                 Details = item.Purchase.PurchaseDetails.Select(i => new
                 {
                     Product_Name = i.Product.Product_Name,
                     Pirce = i.Price,
                     Quantity = i.Quantity,
                     Total = i.Total,
                     Photo = i.Product.Photos.FirstOrDefault().Data
                 })
             }).Where(x => x.Purchase_ID.ToString().Insert(0, "#").Contains(keyword) || x.Customer_Name.ToLower().Contains(keyword.ToLower()) || x.Tel.ToLower().Contains(keyword.ToLower()))
             .Join(db.PurchaseStatusEnums, 
             item => item.Status, 
             s => s.Value,
             (item, s) => new
             {
                 item.Status,
                 item.Purchase_ID,
                 item.Total,
                 item.Created_At,
                 item.Customer_Name,
                 item.Address,
                 item.Tel,
                 OrderID = "#" + item.Purchase_ID.ToString(),
                 s.Display_Text,
                 item.Details,
             }).OrderByDescending(p => p.Created_At);
            // Tính toán các thông tin phân trang
            var _totalProducts = db.Purchases.Count(); // Tổng số sản phẩm
            var _totalPages = _totalProducts / _rowsPerPage; // Tổng số trang, chia lấy phần nguyên
            if (_totalProducts % _rowsPerPage != 0) // Nếu còn dư thì thêm một trang
            {
                _totalPages++;
            }
            _currentPage = 1;
            pagingInfo = new PagingInfo(_totalPages);
            pagesComboBox.ItemsSource = pagingInfo.Items;
            pagesComboBox.SelectedIndex = 0;
            totalOrder.Text = $"Tổng số đơn hàng: {db.Purchases.ToList().Count()}";

            if (status != -1)
            {
                var subquery = query.Where(p => p.Status == status);
                purchaseDataGrid.ItemsSource = subquery.ToList().Take(_rowsPerPage);
            }
            else
            {
                purchaseDataGrid.ItemsSource = query.ToList().Take(_rowsPerPage);
            }
        }

        public void UserControl_Initialized(object sender, EventArgs e)
        {
            var allPurchaseStatus = db.PurchaseStatusEnums.ToList();
            purchaseStatesComboBox.ItemsSource = allPurchaseStatus;
            purchaseStatesComboBox.SelectedIndex = 0;
            fromDatePicker.SelectedDate = null;
            toDatePicker.SelectedDate = null;
            loadAllPurchases();
        }

        class PagingRow
        {
            public int Page { get; set; }
            public int TotalPages { get; set; }
        }

        class PagingInfo
        {
            public List<PagingRow> Items { get; set; }
            public PagingInfo(int totalPages)
            {
                Items = new List<PagingRow>();

                for (int i = 1; i <= totalPages; i++)
                {
                    Items.Add(new PagingRow()
                    {
                        Page = i,
                        TotalPages = totalPages
                    });
                }
            }
        }


        int _rowsPerPage = 15; // Số đơn hàng trên 1 trang
        int _currentPage;
        PagingInfo pagingInfo;

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var keyword = keywordTextBox.Text;
            var query = dateFilter.GroupJoin(db.Customers,
            p => p.Customer_Tel,
            c => c.Tel,
            (x, y) => new { Purchases = x, Customers = y }
            )
            .SelectMany(
                 x => x.Customers.DefaultIfEmpty(),
                 (x, y) => new { Purchase = x.Purchases, Customer = y }
             )
             .Select(item => new {
                 item.Purchase.Status,
                 item.Purchase.Purchase_ID,
                 item.Purchase.Total,
                 item.Purchase.Created_At,
                 item.Customer.Customer_Name,
                 item.Customer.Tel,
                 item.Customer.Address,
                 Details = item.Purchase.PurchaseDetails.Select(i => new
                 {
                     Product_Name = i.Product.Product_Name,
                     Pirce = i.Price,
                     Quantity = i.Quantity,
                     Total = i.Total,
                     Photo = i.Product.Photos.FirstOrDefault().Data
                 })
             }).Where(x => x.Purchase_ID.ToString().Contains(keyword) || x.Customer_Name.ToLower().Contains(keyword.ToLower()) || x.Tel.ToLower().Contains(keyword.ToLower()))
             .Join(db.PurchaseStatusEnums,
             item => item.Status,
             s => s.Value,
             (item, s) => new
             {
                 item.Status,
                 item.Purchase_ID,
                 item.Total,
                 item.Created_At,
                 item.Customer_Name,
                 item.Address,
                 item.Tel,
                 OrderID = "#" + item.Purchase_ID.ToString(),
                 s.Display_Text,
                 item.Details,
             }).OrderByDescending(p => p.Created_At);

            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;
                var skip = (_currentPage - 1) * _rowsPerPage;
                var take = _rowsPerPage;
                purchaseDataGrid.ItemsSource = query.ToList().Skip(skip).Take(take);
            }
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex <= pagesComboBox.Items.Count - 1 && currentIndex > 0)
            {
                pagesComboBox.SelectedIndex = currentIndex - 1;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex < pagesComboBox.Items.Count - 1)
            {
                pagesComboBox.SelectedIndex = currentIndex + 1;
            }
        }

        private void addPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddPurchaseWindow();
            if (screen.ShowDialog() == true)
            {
                loadAllPurchases();
            }
        }

        private void editPurchase_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = purchaseDataGrid.SelectedItem;
            //var purchase = db.Purchases.Find(item.Purchase_ID);
            var screen = new EditPurchaseWindow(item);
            if (screen.ShowDialog() == true)
            {
                loadAllPurchases();
            }
        }

        private void deletePurchase_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = purchaseDataGrid.SelectedItem;
            var oderDetail = db.PurchaseDetails.ToList().FindAll(i => i.Purchase_ID == item.Purchase_ID);
            var purchase = db.Purchases.Find(item.Purchase_ID);
            var customer = db.Customers.Find(item.Tel);
            foreach (var o in oderDetail)
            {
                db.PurchaseDetails.Remove(o);
                db.SaveChanges();
            }
            db.Purchases.Remove(purchase);
            db.Customers.Remove(customer);
            db.SaveChanges();

            // Reload giao dien
            loadAllPurchases();

            // Thong bao phan hoi
            MessageBox.Show("Đơn hàng đã được xóa thành công!");
            purchaseStackPanel.Visibility = Visibility.Collapsed;
        }

        ObservableCollection<object> o = new ObservableCollection<object>();
        private void purchaseDataGrid_SelectedCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            purchaseStackPanel.Visibility = Visibility.Visible;
            dynamic item = purchaseDataGrid.SelectedItem;
            if(item != null)
            {
                purchaseDetail.ItemsSource = item.Details;

                double newValue = double.Parse(item.Total.ToString());
                _orderId.Text = $"Mã đơn hàng: #{item.Purchase_ID}";
                _orderName.Text = $"○ Tên khách hàng: {item.Customer_Name}";
                _orderDate.Text = $"○ Ngày tạo: {item.Created_At}";
                _orderPhone.Text = $"○ Số điện thoại: {item.Tel}";
                _orderAddress.Text = $"○ Địa chỉ giao hàng: {item.Address}";
                _orderTotal.Text = $"○ Tổng cộng: {newValue.ToString("N0").Replace(",", ".") + " VNĐ"}";
            }
            //purchaseStackPanel.DataContext = item;
        }

        private void keywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadAllPurchases();
        }

        private void purchaseStatesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            purchaseDataGrid.UnselectAll();
            loadAllPurchases();
            purchaseStackPanel.Visibility = Visibility.Collapsed;
        }

        private void fromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void toDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(fromDatePicker.SelectedDate != null)
            {
                var from = (DateTime)fromDatePicker.SelectedDate;
                var to = (DateTime)toDatePicker.SelectedDate;

                if(DateTime.Compare(from, to) < 0)
                {
                    loadAllPurchases();
                }
                else
                {
                    MessageBox.Show("Ngay ket thuc phai lon hon ngay bat dau","Loi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                
            }
        }

        private void closePurchaseStackPanel(object sender, RoutedEventArgs e)
        {
            purchaseDataGrid.UnselectAll();
            purchaseStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
