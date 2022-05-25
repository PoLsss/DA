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
using QLKS.DataLayer.DAL;

namespace QLKS.UserControls
{
	/// <summary>
	/// Interaction logic for UserControl_PhuThu.xaml
	/// </summary>
	public partial class UserControl_PhuThu : UserControl
	{
        ObservableCollection<PhuThu> listNguoiO;
		ObservableCollection<PhuThuKhachQT> listKhachQT;
		public UserControl_PhuThu()
        {
            InitializeComponent();
			TaiDanhSachPTKQT();
			TaiDanhSachPTNguoiO();
		}

		private void TaiDanhSachPTKQT()
		{
			listKhachQT = new ObservableCollection<PhuThuKhachQT>(PhuThuDAL.Instance.getdataKhachQT());
			lsvKhachQT.ItemsSource = listKhachQT;
		}
		private void TaiDanhSachPTNguoiO() {
			listNguoiO = new ObservableCollection<PhuThu>(PhuThuDAL.Instance.getdataNguoiO());
			lsvPTNguoiO.ItemsSource = listNguoiO;
		}
		private bool PTKQTFilter(object obj)
		{
			if (String.IsNullOrEmpty(txtFilter.Text))
				return true;
			else
				return (obj as PhuThuKhachQT).Tenlkh.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
		}
		private bool PTNgOFilter(object obj)
		{
			if (String.IsNullOrEmpty(txtFilterPT.Text))
				return true;
			else
				return (obj as PhuThu).Tenpt.IndexOf(txtFilterPT.Text, StringComparison.OrdinalIgnoreCase) >= 0;
		}
		void nhanDataPTKQT(PhuThuKhachQT pt)
		{
			if (PhuThuDAL.Instance.KiemTraTrungTenPTQT(pt))
			{
				if (PhuThuDAL.Instance.ThemPTQT(pt))
				{
					new DialogCustoms("Thêm thành công", "Thông báo", DialogCustoms.OK).Show();
					TaiDanhSachPTKQT();
				}
			}
			else
			{
				new DialogCustoms("Tên dịch vụ đã tồn tại", "Thông báo", DialogCustoms.OK).Show();
			}
		}
		void nhanDataPTNguoiO(PhuThu pt)
		{
			if (PhuThuDAL.Instance.KiemTraTrungTenPTNguoiO(pt))
			{
				if (PhuThuDAL.Instance.ThemPTNguoiO(pt))
				{
					new DialogCustoms("Thêm thành công", "Thông báo", DialogCustoms.OK).Show();
					TaiDanhSachPTNguoiO();
				}
			}
			else
			{
				new DialogCustoms("Tên dịch vụ đã tồn tại", "Thông báo", DialogCustoms.OK).Show();
			}
		}
		void capNhatDataPTKQT(PhuThuKhachQT pt)
		{
			if (PhuThuDAL.Instance.capNhatDataPTKQT(pt))
			{
				new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSachPTKQT();
			}
		}
		void capNhatDataPTNguoiO(PhuThu pt)
		{
			if (PhuThuDAL.Instance.capNhatDataPTNgO(pt))
			{
				new DialogCustoms("Cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
				TaiDanhSachPTNguoiO();
			}
		}
		private void txtFilterKQT_TextChanged(object sender, TextChangedEventArgs e)
		{

			//CollectionViewSource.GetDefaultView(lsvKhachQT.ItemsSource).Refresh();
			CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvKhachQT.ItemsSource);
			view.Filter = PTKQTFilter;
		}
		private void txtFilterNgO_TextChanged(object sender, TextChangedEventArgs e)
		{

			//CollectionViewSource.GetDefaultView(lsvPTNguoiO.ItemsSource).Refresh();
			CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvPTNguoiO.ItemsSource);
			view.Filter = PTNgOFilter;
		}

		private void btnXoaPTQT_Click(object sender, RoutedEventArgs e)
		{
			PhuThuKhachQT pt = (sender as Button).DataContext as PhuThuKhachQT;

			var thongbao = new DialogCustoms("Bạn có thật sự muốn xóa " + pt.Tenlkh, "Thông báo", DialogCustoms.YesNo);
			
			if (thongbao.ShowDialog() == true)
			{
				if (pt.Maloaikh=="LKH01" || pt.Maloaikh == "LKH02")
				{
					new DialogCustoms("Lỗi!\nKhông thể xóa loại khách hàng này", "Thông báo", DialogCustoms.OK).Show();
				}
				else
				{
					new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
					PhuThuDAL.Instance.DelPTKhachQT(pt);
					TaiDanhSachPTKQT();
				}
			}
		}
		private void btnThemPTQT_Click(object sender, RoutedEventArgs e)
		{
			Them_SuaPTKQT ThemDichVu = new Them_SuaPTKQT();
			ThemDichVu.truyen = new Them_SuaPTKQT.TryenDuLieu(nhanDataPTKQT);
			ThemDichVu.ShowDialog();
		}

		private void btnSuaKQT_Click(object sender, RoutedEventArgs e)
		{
			PhuThuKhachQT pt = (sender as Button).DataContext as PhuThuKhachQT;
			Them_SuaPTKQT CapNhatDichVu = new Them_SuaPTKQT(pt);
			CapNhatDichVu.sua = new Them_SuaPTKQT.SuaDuLieu(capNhatDataPTKQT);
			CapNhatDichVu.ShowDialog();
		}

		private void btnCapNhatSoK_Click(object sender, RoutedEventArgs e)
		{
			PhuThu pt = (sender as Button).DataContext as PhuThu;
			Them_SuaPTNguoiO CapNhatDichVu = new Them_SuaPTNguoiO(pt);
			CapNhatDichVu.sua = new Them_SuaPTNguoiO.suaData(capNhatDataPTNguoiO);
			CapNhatDichVu.ShowDialog();
		}

		private void btThemPTNgO_Click(object sender, RoutedEventArgs e)
		{
			Them_SuaPTNguoiO ThemDichVu = new Them_SuaPTNguoiO();
			ThemDichVu.truyenPTNgO = new Them_SuaPTNguoiO.truyenData(nhanDataPTNguoiO);
			ThemDichVu.ShowDialog();
		}

		private void btnXoaPTNguoiO_Click(object sender, RoutedEventArgs e)
		{
			PhuThu pt = (sender as Button).DataContext as PhuThu;

			var thongbao = new DialogCustoms("Bạn có thật sự muốn xóa " + pt.Tenpt, "Thông báo", DialogCustoms.YesNo);

			if (thongbao.ShowDialog() == true)
			{
				new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
				PhuThuDAL.Instance.DelPTNguoiO(pt);
				TaiDanhSachPTNguoiO();
			}
		}
	}
}
