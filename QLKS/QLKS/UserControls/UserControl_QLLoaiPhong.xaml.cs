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
	/// Interaction logic for UserControl_QLLoaiPhong.xaml
	/// </summary>
	public partial class UserControl_QLLoaiPhong : UserControl
	{
        ObservableCollection<LoaiPhong> listLP;

        public UserControl_QLLoaiPhong()
        {
            InitializeComponent();
            TaiDanhSach();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvLoaiPhong.ItemsSource);
            view.Filter = LoaiPhongFilter;
        }

        #region Method
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lsvLoaiPhong.ItemsSource).Refresh();
        }

        private void TaiDanhSach()
        {
            listLP = new ObservableCollection<LoaiPhong>(LoaiPhongBUS.Instance.getDataLoaiPhong());
            lsvLoaiPhong.ItemsSource = listLP;
        }

        private bool LoaiPhongFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (obj as LoaiPhong).Tenloaiphong.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }
		void nhanData(LoaiPhong loaiPhong)
		{
			if (LoaiPhongBUS.Instance.KiemTraTrungTen(loaiPhong))
			{
				if (LoaiPhongBUS.Instance.addLoaiPhong(loaiPhong))
				{
					new DialogCustoms("Thêm thành công", "Thông báo", DialogCustoms.OK).Show();
					TaiDanhSach();
				}
			}
			else
			{
				new DialogCustoms("Tên loại phòng đã tồn tại", "Thông báo", DialogCustoms.OK).Show();
			}
		}
		void capNhatData(LoaiPhong loaiPhong)
		{
			if (LoaiPhongBUS.Instance.capNhatDataLoaiPhong(loaiPhong))
			{
				new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSach();
			}
			else
			{
				new DialogCustoms("Tên loại phòng đã tồn tại", "Thông báo", DialogCustoms.OK).Show();
			}
		}
		#endregion

		#region Event
		private void btnThemLoaiPhong_Click(object sender, RoutedEventArgs e)
		{
			Them_SuaLoaiPhong ThemLoaiPhong = new Them_SuaLoaiPhong();
			ThemLoaiPhong.truyenLoaiPhong = new Them_SuaLoaiPhong.truyenData(nhanData);
			ThemLoaiPhong.ShowDialog();
		}

		private void btnXoaLoaiPhong_Click(object sender, RoutedEventArgs e)
		{
			LoaiPhong phong = (sender as Button).DataContext as LoaiPhong;

			var thongbao = new DialogCustoms("Bạn có thật sự muốn loai phòng " + phong.Tenloaiphong, "Thông báo", DialogCustoms.YesNo);

			if (thongbao.ShowDialog() == true)
			{
				LoaiPhongBUS.Instance.xoaLoaiPhong(phong);
				new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSach();
			}
		}

		private void btnSuaLoaiPhong_Click(object sender, RoutedEventArgs e)
		{
			LoaiPhong phong = (sender as Button).DataContext as LoaiPhong;

			Them_SuaLoaiPhong CapNhatLoaiPhong = new Them_SuaLoaiPhong(phong);
			CapNhatLoaiPhong.suaLoaiPhong = new Them_SuaLoaiPhong.suaData(capNhatData);
			CapNhatLoaiPhong.ShowDialog();
		}
		#endregion
	}
}
