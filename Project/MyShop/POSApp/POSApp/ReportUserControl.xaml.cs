using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace POSApp
{
    /// <summary>
    /// Interaction logic for ReportUserControl.xaml
    /// </summary>
    public partial class ReportUserControl : UserControl
    {
        public ReportUserControl()
        {
            InitializeComponent();
            dateOptions.ItemsSource = new string[] {
                "Tất cả", "Hôm nay", "Tháng này", "Ngày hôm qua", "7 ngày trước", "Tháng trước", "Năm"
            };
        }
        public SeriesCollection purchaseData { get; set; }
        public SeriesCollection category_prodcutData { get; set; }
        public SeriesCollection revenueCategory { get; set; }
        public SeriesCollection revenueData { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public ObservableCollection<string> LabelsData { get; set; }

        BadHabitsStoreEntities db = new BadHabitsStoreEntities();
        public void UserControl_Initialized(object sender, EventArgs e)
        {
            dateOptions.SelectedIndex = 0;
            fromDatePicker.SelectedDate = null;
            toDatePicker.SelectedDate = null;
            // Pie Chart
            purchaseData = new SeriesCollection() { };
            category_prodcutData = new SeriesCollection() { };

            var purchase = (db.Purchases.GroupJoin(db.PurchaseStatusEnums,
                                    p => p.Status,
                                    s => s.Value,
                                    (p, group) => new
                                    {
                                        Name = p.PurchaseStatusEnum.Display_Text,
                                    })).ToList();
            foreach (var item in purchase.GroupBy(x => x.Name).Select(g => new { g.Key, Count = g.Count() }))
            {
                PieSeries Pie = new PieSeries()
                {
                    Values = new ChartValues<float> { item.Count },
                    Title = $"{item.Key}",
                    DataLabels = true,
                };
                purchaseData.Add(Pie);
            }

            var category_product = (db.Products.GroupJoin(db.Categories,
                                    p => p.Catgory_ID,
                                    c => c.Category_ID,
                                    (p, group) => new
                                    {
                                        Name = p.Category.Category_Name,
                                    })).ToList();
            foreach (var item in category_product.GroupBy(x => x.Name).Select(g => new { g.Key, Count = g.Count() }))
            {
                PieSeries Pie = new PieSeries()
                {
                    Values = new ChartValues<float> { item.Count },
                    Title = $"{item.Key}",
                    DataLabels = true,
                };
                category_prodcutData.Add(Pie);
            }

            category_product_piechart.Series = category_prodcutData;
            purchase_pie_chart.Series = purchaseData;

            // Row Chart
            // Xét từng loại sản phẩm
            var PurchaseDetails = new ObservableCollection<PurchaseDetail>(db.PurchaseDetails);
            var Products = new ObservableCollection<Product>(db.Products);
            var Categories = new ObservableCollection<Category>(db.Categories);

            revenueCategory = new SeriesCollection() { };
            Labels = new ObservableCollection<string>();
            RowSeries row = new RowSeries()
            {
                Title = "Tổng",
                Values = new ChartValues<int> { },
                DataLabels = true
            };
            for (int i = 0; i < Categories.Count; i++)
            {
                try
                {
                    // Liệt kê tất cả sản phẩm thuộc loại đang xét (chỉ trích lấy mã)
                    var CategoryId = Categories[i].Category_ID;
                    var ProductIds = Products.Where(x => x.Catgory_ID == CategoryId);
                    // Xét tất cả hóa đơn có mã SP thuộc danh sách trên
                    var neededBills = PurchaseDetails.Where(x => ProductIds.Any(p => p.Product_ID == x.Product_ID));
                    // Tính tổng sản phẩm & tổng số tiền trong các hóa đơn trên
                    var sumMoneySold = neededBills.Sum(x => x.Total);

                    Labels.Add(Categories[i].Category_Name);

                    row.Values.Add(sumMoneySold);

                }
                catch (Exception) { }
            }
            revenueCategory.Add(row);
            Formatter = value => value.ToString("N0").Replace(",", ".") + " VNĐ";
            rowchartRevenueCategory.Series = revenueCategory;


            //Bar chart
            var data = (from pur in db.Purchases
                        where pur.Status != 3
                        select pur).ToList();

            var DateList = data.GroupBy(i => i.Created_At.HasValue ? i.Created_At.Value.ToString("yyyy/MM/dd") : "<not available>")
             .Select(i => new
             {
                 Day = i.Key,
                 Sum = i.Sum(x => x.Total)
             });
            revenueData = new SeriesCollection();
            ColumnSeries col = new ColumnSeries()
            {
                Title = "Tổng: ",
                Values = new ChartValues<int> { },
                DataLabels = true
            };

            LabelsData = new ObservableCollection<string>();
            foreach (var s in DateList)
            {
                LabelsData.Add((DateTime.Parse(s.Day)).ToString("dd/MM/yyyy"));
                col.Values.Add(s.Sum);
            }
            revenueData.Add(col);
            revenueStatistics.Series = revenueData;
            DataContext = this;
        }

        private void dateOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Purchase> purdata = new List<Purchase>();
            string valueFormat = "yyyy/MM/dd";
            switch (dateOptions.SelectedIndex)
            {
                case 1:
                    DateTime startDateTime = DateTime.Today; //Today at 00:00:00
                    DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59
                    var data1 = (from pur in db.Purchases
                                where pur.Status != 3 && (pur.Created_At >= startDateTime && pur.Created_At <= endDateTime)
                                select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data1;
                    break;
                case 2:
                    DateTime now = DateTime.Now;
                    var data2 = (from pur in db.Purchases
                                 where pur.Status != 3 && (pur.Created_At.Value.Year == now.Year && pur.Created_At.Value.Month == now.Month)
                                 select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data2;
                    valueFormat = "yyyy/MM";
                    break;
                case 3:
                    DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                    DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                    var data3 = (from pur in db.Purchases
                                 where pur.Status != 3 && (pur.Created_At >= yesterday && pur.Created_At <= yesterdayEnd)
                                 select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data3;
                    break;
                case 4:
                    var last7Days = DateTime.Now.AddDays(-7);
                    var data4 = (from pur in db.Purchases
                                 where pur.Status != 3 && (pur.Created_At > last7Days)
                                 select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data4;
                    break;
                case 5:
                    var lastMonth = DateTime.Now.AddMonths(-1);
                    var data5 = (from pur in db.Purchases
                                 where pur.Status != 3 && (pur.Created_At > lastMonth)
                                 select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data5;
                    valueFormat = "yyyy/MM";
                    break;
                case 6:
                    var data6 = (from pur in db.Purchases
                                 where pur.Status != 3
                                 select pur).OrderBy(p => p.Created_At).ToList();
                    purdata = data6;
                    valueFormat = "yyyy";
                    break;
                default:
                    var dataf = (from pur in db.Purchases
                                where pur.Status != 3
                                select pur).OrderBy(p=>p.Created_At).ToList();
                    purdata = dataf;
                    break;
            }

            var DateList = purdata.GroupBy(i => i.Created_At.Value.ToString(valueFormat))
                                     .Select(i => new
                                     {
                                         Day = i.Key,
                                         Sum = i.Sum(x => x.Total)
                                     });

            revenueData = new SeriesCollection();
            ColumnSeries col = new ColumnSeries()
            {
                Title = "Tổng: ",
                Values = new ChartValues<int> { },
                DataLabels = true
            };

            LabelsData = new ObservableCollection<string>();
            foreach (var s in DateList)
            {
                if (valueFormat == "yyyy")
                {
                    LabelsData.Add(s.Day);

                }
                else
                {
                    LabelsData.Add((DateTime.Parse(s.Day)).ToString(valueFormat));
                }
                col.Values.Add(s.Sum);
            }
            revenueData.Add(col);
            Formatter = value => value.ToString("N0").Replace(",", ".") + " VNĐ";
            revenueStatistics.Series = revenueData;
            axisLabels.Labels = LabelsData;
            DataContext = this;

        }

        private void fromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void toDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fromDatePicker.SelectedDate != null && toDatePicker.SelectedDate != null)
            {
                var from = (DateTime)fromDatePicker.SelectedDate;
                var to = (DateTime)toDatePicker.SelectedDate;
                to = to.AddDays(1);

                if (DateTime.Compare(from, to) < 0)
                {
                    var dateFilter = db.Purchases.Where(p => (from <= p.Created_At) && (p.Created_At <= to)).ToList().OrderBy(p => p.Created_At);
                    var DateList = dateFilter.GroupBy(i => i.Created_At.Value.ToString("yyyy/MM/dd"))
                                     .Select(i => new
                                     {
                                         Day = i.Key,
                                         Sum = i.Sum(x => x.Total)
                                     });
                    revenueData = new SeriesCollection();
                    ColumnSeries col = new ColumnSeries()
                    {
                        Title = "Tổng: ",
                        Values = new ChartValues<int> { },
                        DataLabels = true
                    };

                    LabelsData = new ObservableCollection<string>();
                    foreach (var s in DateList)
                    {
                        LabelsData.Add((DateTime.Parse(s.Day)).ToString("yyyy/MM/dd"));
                        col.Values.Add(s.Sum);
                    }
                    revenueData.Add(col);
                    Formatter = value => value.ToString("N0").Replace(",", ".") + " VNĐ";
                    revenueStatistics.Series = revenueData;
                    axisLabels.Labels = LabelsData;
                    DataContext = this;
                }
                else
                {
                    
                }
            }
            else
            {

            }
        }
    }
}
