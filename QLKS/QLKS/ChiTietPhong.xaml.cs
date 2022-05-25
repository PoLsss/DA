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
using System.Windows.Shapes;
using QLKS.DataLayer;
using QLKS.DataLayer.BUS;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for ChiTietPhong.xaml
    /// </summary>
    public partial class ChiTietPhong : Window
    {

        public delegate void truyenDataPhong(Phong phong);
        public truyenDataPhong truyenData;

		ObservableCollection<DichVu_DaChon> obDichVu;
        private Phong phong_CTPhong;

        private bool kiemTraSuaDoiTinhTrangDonDep;
        private bool kiemTraNhanPhong;
		private bool kiemtraphongtong ;
       
        //public int MaNV { get => maNV; set => maNV = value; }

        public ChiTietPhong()
        {
            InitializeComponent();
            truyenData = new truyenDataPhong(setDataPhong);
            kiemTraSuaDoiTinhTrangDonDep = false;
            kiemTraNhanPhong = false;
			kiemtraphongtong = false;

		}


		#region method
		void setDataPhong(Phong phong)
		{
			//Nhận dữ liệu từ form cha và gán giá trị lên form con
			phong_CTPhong = phong;
			txblTieuDe.Text = phong.Maphong;
			txblTenKH.Text = phong.Tenkh;
			icDay.Kind = MaterialDesignThemes.Wpf.PackIconKind.CalendarToday;
			txblSoNgay.Text = phong.Songay.ToString() + " ngày";
			if(kiemtraphongtong)
				txblSoNguoi.Text = "0";
			else
				txblSoNguoi.Text = phong.Songuoiht.ToString();
			txblNgayDen.Text =phong.Ngaybatdau.ToString();
			cbTinhTrang.Text = phong.Tinhtrang;
			cbDonDep.Text = phong.Dondep;
			kiemTraSuaDoiTinhTrangDonDep = false;

			obDichVu = new ObservableCollection<DichVu_DaChon>();	
		}

		#endregion

		#region event
		private void click_Thoat(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


		private void click_ThanhToan(object sender, RoutedEventArgs e)
		{
			kiemtraphongtong = true;
			this.DialogResult = true;
			this.Visibility = Visibility.Hidden;
			XuatHoaDon hoaDon = new XuatHoaDon( phong_CTPhong, obDichVu);
			hoaDon.ShowDialog();
			this.Close();
		}

		private void cbDonDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			kiemTraSuaDoiTinhTrangDonDep = true;
		}

		private void click_NhanPhong(object sender, RoutedEventArgs e)
		{
			kiemTraNhanPhong = true;
			kiemtraphongtong = false;
			cbTinhTrang.Text = "Phòng đang thuê";
		}
		private void click_Luu(object sender, RoutedEventArgs e)
		{
			if (kiemTraSuaDoiTinhTrangDonDep)
			{

				string error = string.Empty;
				if (!PhongBUS.Instance.suaTinhTrangDonDep(phong_CTPhong.Maphong , cbDonDep.Text, out error))
				{
					new DialogCustoms("Lưu thất bại !\n Lỗi:" + error, "Thông báo", DialogCustoms.OK).ShowDialog();
					return;
				}
				else
				{
					this.DialogResult = true;
				}
				
				this.Close();
				
			}


			if (kiemTraNhanPhong)
			{
				string error = string.Empty;
				if (!CT_PhieuThueBUS.Instance.suaTinhTrangThuePhong(phong_CTPhong.Maphong , "Phòng đang thuê"))
				{
					new DialogCustoms("Lưu thất bại !\n Lỗi:" + error, "Thông báo", DialogCustoms.OK).ShowDialog();
					return;
				}
				else
				{
					this.DialogResult = true;
				}
				this.Close();
			}
			if (!kiemTraSuaDoiTinhTrangDonDep && !kiemTraNhanPhong)
			{
				this.Close();
			}

		}



		#endregion


	}
}
