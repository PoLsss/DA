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
	/// Interaction logic for UserControl_QLPhong.xaml
	/// </summary>
	public partial class UserControl_QLPhong : UserControl
	{
        ObservableCollection<Phong> list;


        public UserControl_QLPhong()
        {
            InitializeComponent();

            TaiDanhSach();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvPhong.ItemsSource);
            view.Filter = PhongFilter;
        }

        private bool PhongFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (obj as Phong).Maphong.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void TaiDanhSach()
        {
            list = new ObservableCollection<Phong>(PhongBUS.Instance.getDataPhong());
            lsvPhong.ItemsSource = list;
        }

		void nhanData(Phong p)
		{

			if (PhongBUS.Instance.addDataPhong(p))
			{
				new DialogCustoms("Thêm thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSach();
			}
			else
			{
				new DialogCustoms("Số phòng đã tồn tại", "Thông báo", DialogCustoms.OK).Show();
			}
		}

		//void capNhatData(Phong p)
		//{

		//	if (PhongBUS.Instance.capNhatDataPhong(p))
		//	{
		//		new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
		//		TaiDanhSach();
		//	}

		//}

		private void btnThemPhong_Click(object sender, RoutedEventArgs e)
		{
			Them_SuaPhong NhapThemPhong = new Them_SuaPhong();
			NhapThemPhong.truyen = new Them_SuaPhong.TryenDuLieu(nhanData);
			NhapThemPhong.ShowDialog();
		}
		
		//private void btnCapNhat_Click(object sender, RoutedEventArgs e)
		//{
		//	Phong phong = (sender as Button).DataContext as Phong;

		//	Them_SuaPhong nhapThemPhong = new Them_SuaPhong(phong);

		//	nhapThemPhong.sua = new Them_SuaPhong.SuaDuLieu(capNhatData);
		//	nhapThemPhong.ShowDialog();
		//}
		private void btnXoaPhong_Click(object sender, RoutedEventArgs e)
		{
			Phong phong = (sender as Button).DataContext as Phong;
			var thongbao = new DialogCustoms("Bạn có thật sự muốn xóa phòng " + phong.Maphong, "Thông báo", DialogCustoms.YesNo);

			if (thongbao.ShowDialog() == true)
			{
				if (phong.Songuoiht != 0 )
				{
					var thongbao2 = new DialogCustoms( phong.Maphong +" Hiện đang có người ở. Không thể xóa ", "Thông báo", DialogCustoms.OK);
					thongbao2.ShowDialog();
					return;
				}
				new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
				PhongBUS.Instance.xoaDataPhong(phong);
				TaiDanhSach();
			}
		}

		private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lsvPhong.ItemsSource).Refresh();
        }

		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			txtFilter.Text = String.Empty;
		}


	}
}
