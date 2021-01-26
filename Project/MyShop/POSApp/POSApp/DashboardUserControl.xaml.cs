using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POSApp
{
    /// <summary>
    /// Interaction logic for DashboardUserControl.xaml
    /// </summary>
    public partial class DashboardUserControl : UserControl
    {
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        BadHabitsStoreEntities db = new BadHabitsStoreEntities();
        private SeriesCollection _series;
        public SeriesCollection SeriesCollection
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SeriesCollection"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public void UserControl_Initialized(object sender, EventArgs e)
        {
            var valueSum = db.Purchases.Where(s => s.Status != 3).Sum(x => x.Total);
            double newValue = double.Parse(valueSum.ToString());
            totalProductText.Text = db.Products.Count().ToString();
            totalOrderText.Text = db.Purchases.Count().ToString();
            totalSaleText.Text = newValue.ToString("N0").Replace(",", ".") + " VNĐ";
            totalCustomerText.Text = db.Customers.Count().ToString();


            var topCustomer = (from customers in db.Customers
                               select customers).Take(10).ToList();
            customerListView.ItemsSource = topCustomer;

            var topPurchases = db.Purchases.GroupJoin(db.Customers,
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
             })
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
             }).ToList();
            purchaseDataGrid.ItemsSource = topPurchases.Where(x => x.Status == 1).OrderByDescending(p => p.Created_At).Take(10);

            var soldoutProduct = (from product in db.Products
                                  where product.Quantity < 10 && product.Quantity > 0
                                  select new
                                  {
                                      Id = product.Product_ID,
                                      Name = product.Product_Name,
                                      Price = product.Price,
                                      Quantity = "Còn " + product.Quantity + " sản phẩm",
                                      Thumbnail = product.Photos
                                          .FirstOrDefault().Data
                                  }).ToList();

            soldoutProductListView.ItemsSource = soldoutProduct;

            var sellingProduct = (db.Products.GroupJoin(db.PurchaseDetails,
                                    p => p.Product_ID,
                                    d => d.Product_ID,
                                    (p, group) => new
                                    {
                                        Name = p.Product_Name,
                                        Thumbnail = p.Photos
                                             .FirstOrDefault().Data,
                                        Count = "Đã bán " + group.Count() + " sản phẩm"
                                    })).OrderByDescending(x => x.Count).ToList().Take(10);

            sellingProductListView.ItemsSource = sellingProduct;


            // Line Chart
            SeriesCollection = new SeriesCollection() { };

            var data = (from purchase in db.Purchases
                        where purchase.Status != 3
                        select purchase).OrderBy(p => p.Created_At).ToList();

            var DateList = data.GroupBy(i => i.Created_At.HasValue ? i.Created_At.Value.ToString("yyyy/MM/dd") : "<not available>")
             .Select(i => new
             {
                 Day = i.Key,
                 Sum = i.Sum(x => x.Total)
             });

            Labels = new List<string>();

            LineSeries line = new LineSeries()
            {
                Title = "Doanh thu",
                Values = new ChartValues<int> { }
            };

            foreach (var s in DateList)
            {
                Labels.Add((DateTime.Parse(s.Day)).ToString("dd/MM/yyyy"));
                line.Values.Add(s.Sum);
            }

            SeriesCollection.Add(line);
            YFormatter = value => value.ToString("N0").Replace(",", ".") + " VNĐ";
            linechartRevenue.Series = SeriesCollection;
            axisLabels.Labels = Labels;
            DataContext = this;
        }
    }
}
