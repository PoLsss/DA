using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Interaction logic for UserControl_PhieuThue.xaml
	/// </summary>
	public partial class UserControl_PhieuThue : UserControl
	{
        ObservableCollection<PhieuThue> lsPhieuThue; //lsPhieuThueCusToms
        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }

        public UserControl_PhieuThue()
        {
            InitializeComponent();
            lsPhieuThue = new ObservableCollection<PhieuThue>(PhieuThueBUS.Instance.getDataPhieuThue());
            lvPhieuThue.ItemsSource = lsPhieuThue;
        }
		private void click_DatPhong(object sender, RoutedEventArgs e)
		{
			DatPhong dp = new DatPhong();
			dp.luuPhieuDatPhong = new DatPhong.dlg(nhanThongBaoLuuTuFormDatPhong);
			
			dp.ShowDialog();
		}
		void nhanThongBaoLuuTuFormDatPhong()
		{
			lsPhieuThue = new ObservableCollection<PhieuThue>(PhieuThueBUS.Instance.getDataPhieuThue());
			lvPhieuThue.ItemsSource = lsPhieuThue;
		}
		private void click_ChiTiet(object sender, RoutedEventArgs e)
		{
			PhieuThue ptct = (sender as Button).DataContext as PhieuThue;
			if (ptct != null)
			{
				ChiTietPhieuThue ctPT = new ChiTietPhieuThue(ptct);
				ctPT.ShowDialog();
			}
		}
		private bool filterTimKiem(object obj)
		{
			if (String.IsNullOrEmpty(txbTimKiem.Text))
				return true;
			else
			{
				string objTenKH = RemoveVietnameseTone((obj as PhieuThue).Tenkh);
				string timkiem = RemoveVietnameseTone(txbTimKiem.Text);
				return objTenKH.Contains(timkiem);
			}
		}
		private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
		{
			CollectionView viewPT = (CollectionView)CollectionViewSource.GetDefaultView(lvPhieuThue.ItemsSource);
			viewPT.Filter = filterTimKiem;
		}

		public string RemoveVietnameseTone(string text)
		{
			string result = text.ToLower();
			result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
			result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
			result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
			result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
			result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
			result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
			result = Regex.Replace(result, "đ", "d");
			return result;
		}

		private void Click_Xoa(object sender, RoutedEventArgs e)
		{
			PhieuThue phieuThue = (sender as Button).DataContext as PhieuThue;
			string error = string.Empty;
			DialogCustoms dlg = new DialogCustoms("Bạn có muốn xóa phiếu thuê " + phieuThue.Mactphieu, "Thông báo", DialogCustoms.YesNo);
			if (dlg.ShowDialog() == true)
			{
				if (PhieuThueBUS.Instance.xoaPhieuThueTheoMaPhieuThue(phieuThue.Mactphieu))
				{
					new DialogCustoms("Xóa phiếu thuê thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
					lsPhieuThue.Remove(phieuThue);
				}
				else
				{
					new DialogCustoms("Xóa phiếu thuê thất bại !\n Lỗi: " + error, "Thông báo", DialogCustoms.OK).ShowDialog();
				}
			}

		}
		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			txbTimKiem.Text = String.Empty;
		}
	}

}
