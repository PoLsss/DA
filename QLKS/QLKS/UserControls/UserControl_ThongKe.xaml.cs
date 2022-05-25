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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using QLKS.DataLayer;
using QLKS.DataLayer.DAL;

namespace QLKS.UserControls
{
	/// <summary>
	/// Interaction logic for UserControl_ThongKe.xaml
	/// </summary>
	public partial class UserControl_ThongKe : UserControl
	{
        public SeriesCollection SeriesCollection { get; set; }
		public SeriesCollection SeriesCollection1 { get; set; }
		public string[] Labels { get; set; }
		public Func<ChartPoint, string> PointLabel { get; set; }
		public Func<double, string> YFormatter { get; set; }

		ObservableCollection<ThongKe> listTK;


		List<int> listmonth;
		int month = 5;
		static int year = 2022;
		int phonga = ThongKeDAL.Instance.GetDoanhThuLP_ALL("Phòng A");
		int phongb = ThongKeDAL.Instance.GetDoanhThuLP_ALL("Phòng B");
		int phongc = ThongKeDAL.Instance.GetDoanhThuLP_ALL("Phòng C");

		private void TaiDanhSach(int month)
		{
			listTK = new ObservableCollection<ThongKe>(ThongKeDAL.Instance.GetDanhSach(month));
			lsvThongKe.ItemsSource = listTK;
		}
		public UserControl_ThongKe()
        {
            InitializeComponent();
			piechart();
			cartesian();

		}

		private void piechart() {
			txtSoLuong.Text = ThongKeDAL.Instance.GetSoLuongPhongDat().ToString();
			

			SeriesCollection = new SeriesCollection
			{
				new PieSeries
				{
					Title = "Phòng A",
					Values = new ChartValues<ObservableValue> {new ObservableValue(phonga) },
					DataLabels=true
				},
				new PieSeries
				{
					Title = "Phòng B",
					Values = new ChartValues<ObservableValue> {new ObservableValue(phongb) },
					DataLabels=true
				},
				new PieSeries
				{
					Title = "Phòng C",
					Values = new ChartValues<ObservableValue> {new ObservableValue(phongc) },
					DataLabels=true
				}
			};



			System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

			txtDoanhThu.Text = String.Format(culture, "{0:N0}", phonga + phongb + phongc);

			txtTitle.Text = "Biểu đồ doanh thu ";
			DataContext = this;
		}
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			listmonth = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
			cbChonThang.ItemsSource = listmonth;
			
		}

		private void cbChonThang_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
			var comboBox = sender as ComboBox;
			if (comboBox != null)
			{
				var comboBoxItem = comboBox.SelectedItem as ComboBoxItem;
				month = (int)comboBox.SelectedValue;
				int checkmonth = ThongKeDAL.Instance.GetDoanhThuThang(month, year, "Phòng A");
				if (checkmonth !=-1)
				{
					TaiDanhSach(month);
					txtSoLuong.Text = ThongKeDAL.Instance.GetSOluongPhongDat(month, year).ToString();
					int phonga = ThongKeDAL.Instance.GetDoanhThuThang(month, year, "Phòng A");
					int phongb = ThongKeDAL.Instance.GetDoanhThuThang(month, year, "Phòng B");
					int phongc = ThongKeDAL.Instance.GetDoanhThuThang(month, year, "Phòng C");
					
					SeriesCollection = new SeriesCollection
					{
						new PieSeries
						{
							Title = "Phòng A",
							Values = new ChartValues<ObservableValue> {new ObservableValue(phonga) },
							DataLabels=true
						},
						new PieSeries
						{
							Title = "Phòng B",
							Values = new ChartValues<ObservableValue> {new ObservableValue(phongb) },
							DataLabels=true
						},
						new PieSeries
						{
							Title = "Phòng C",
							Values = new ChartValues<ObservableValue> {new ObservableValue(phongc) },
							DataLabels=true
						}
					};

					

					System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

					txtDoanhThu.Text = String.Format(culture, "{0:N0}", phonga + phongb + phongc);

					//txtDoanhThu.Text = (phonga + phongb + phongc).ToString();

					txtTitle.Text = "Biểu đồ doanh thu tháng " + month.ToString() + ", " + year.ToString();
					DataContext = this;
				}
				else {
					new DialogCustoms("Thống kê thất bại!\nLỗi: Không có dữ liệu" , "Thông báo", DialogCustoms.OK).ShowDialog();
					txtDoanhThu.Text = "0";
					txtSoLuong.Text = "0";
					SeriesCollection = new SeriesCollection
					{
						new PieSeries
						{
							Title = "Phòng A",
							Values = new ChartValues<ObservableValue> {new ObservableValue(0) },
							DataLabels=true
						},
						new PieSeries
						{
							Title = "Phòng B",
							Values = new ChartValues<ObservableValue> {new ObservableValue(0) },
							DataLabels=true
						},
						new PieSeries
						{
							Title = "Phòng C",
							Values = new ChartValues<ObservableValue> {new ObservableValue(0) },
							DataLabels=true
						}
					};
					DataContext = this;

				}
			}
		}


		public void cartesian()
		{

			SeriesCollection1 = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Phòng A",
					Values = new ChartValues<double> { 0, 0,0,0, phonga}
},
				new LineSeries
				{
					Title = "Phòng B",
					Values = new ChartValues<double> { 0,0,0,0, phongb}
				},
				new LineSeries
				{
					Title = "Phòng C",
					Values = new ChartValues<double> {0,0,0,0,phongc }
				}
			};

			Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
			YFormatter = value => value.ToString("N");
			DataContext = this;
		}

		private void Click_SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (!long.TryParse(txbChonNam.Text, out long temp))
			{
				txbChonNam.Focus();
				new DialogCustoms("Hãy nhập đúng định dạng năm !", "Thông báo", DialogCustoms.OK).ShowDialog();
			}
			else
				year = int.Parse(txbChonNam.Text);

		}
	}
}
