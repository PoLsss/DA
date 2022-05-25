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
	/// Interaction logic for UserContro_QLKhachHang.xaml
	/// </summary>
	public partial class UserContro_QLKhachHang : UserControl
	{
        ObservableCollection<KhachHang> list;

        public UserContro_QLKhachHang()
        {
            InitializeComponent();
            TaiDanhSach();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvKhachHang.ItemsSource);
            view.Filter = KhachHangFilter;
        }

        private void TaiDanhSach()
        {
            list = new ObservableCollection<KhachHang>(KhachHangBUS.Instance.GetKhachHangs());
            lsvKhachHang.ItemsSource = list;
        }

        private bool KhachHangFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (obj as KhachHang).Tenkh.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

		private void btnThemKhachHang_Click(object sender, RoutedEventArgs e)
		{
			Them_SuaKhachHang nhapThongTinKhach = new Them_SuaKhachHang();
			nhapThongTinKhach.truyenKhachHang = new Them_SuaKhachHang.truyenData(nhanData);
			nhapThongTinKhach.ShowDialog();
		}
		void nhanData(KhachHang khachHang)
		{
			if (KhachHangBUS.Instance.kiemTraTonTaiKhachHang(khachHang.Cmnd.ToString()) == "Khong_tim_thay")
			{
				if (KhachHangBUS.Instance.addKhachHang(khachHang)!=null)
				{
					new DialogCustoms("Thêm thành công", "Thông báo", DialogCustoms.OK).Show();
					TaiDanhSach();
				}
			}
			else
			{
				new DialogCustoms("Khách hàng đã có", "Thông báo", DialogCustoms.OK).Show();
				return;
			}
		}
		private void btnCapNhat_Click(object sender, RoutedEventArgs e)
		{
			KhachHang khachHang = (sender as Button).DataContext as KhachHang;
			Them_SuaKhachHang CapNhatThongTinKhach = new Them_SuaKhachHang(khachHang);
			CapNhatThongTinKhach.suaKhachHang = new Them_SuaKhachHang.suaData(capNhatData);
			CapNhatThongTinKhach.ShowDialog();
		}
		void capNhatData(KhachHang khachHang)
		{
			if (KhachHangBUS.Instance.capNhatDataKhachHang(khachHang))
			{
				new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSach();
			}
		}

		private void btnXoa_Click(object sender, RoutedEventArgs e)
		{
			KhachHang khachHang = (sender as Button).DataContext as KhachHang;
			var ThongBao = new DialogCustoms("Bạn có thật sự muỗn xóa " + khachHang.Tenkh, "Thông báo", DialogCustoms.YesNo);

			if (ThongBao.ShowDialog() == true)
			{
				if (KhachHangBUS.Instance.xoaDataKhachHang(khachHang))
				{
					new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
					TaiDanhSach();
				}
			}
		}

		private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lsvKhachHang.ItemsSource).Refresh();
        }
    }
}
