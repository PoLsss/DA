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
using QLKS.DataLayer;
using QLKS.DataLayer.BUS;

namespace QLKS.UserControls
{
	/// <summary>
	/// Interaction logic for UserControl_HoaDon.xaml
	/// </summary>
	public partial class UserControl_HoaDon : UserControl
	{
        string TenNHanVienLap = "Nguyễn Thanh Thiện";
        ObservableCollection<HoaDon> list;
        public UserControl_HoaDon()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiDanhSach();
            Console.WriteLine("Load Hoa Don");
        }
        private void TaiDanhSach()
        {
            list = new ObservableCollection<HoaDon>(HoaDonBUS.Instance.GetHoaDons());
            lsvHoaDon.ItemsSource = list;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource);
            view.Filter = HoaDonFilter;
            CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource).Refresh();
        }
        private bool HoaDonFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
                return (obj as HoaDon).Mahoadon == txtFilter.Text;
        }
        private bool HoaDonFilterTheoNgay(object obj)
        {
            if (String.IsNullOrEmpty(dtpChonNgay.Text))
                return true;
            else
                return (obj as HoaDon).Checkout.ToShortDateString().Equals(dtpChonNgay.Text);
        }

        private void dtpChonNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource);
            view.Filter = HoaDonFilterTheoNgay;
            CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource).Refresh();
        }

		private void chiTiet_Click(object sender, RoutedEventArgs e)
		{

			HoaDon hd = (sender as Button).DataContext as HoaDon;
			new XuatHoaDon(hd.Mahoadon, hd.Checkout).ShowDialog();
		}
	}
}
