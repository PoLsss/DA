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
	/// Interaction logic for XuatHoaDon.xaml
	/// </summary>
	public partial class XuatHoaDon : Window
	{
        private Phong phong;
        private List<DichVu_DaChon> ls;
		private PhuThu phuthu;
        public Phong Phong { get => phong; set => phong = value; }
		public PhuThu Phuthu { get => phuthu; set => phuthu = value; }

		public XuatHoaDon()
        {
            InitializeComponent();
        }
        public XuatHoaDon(Phong ph, ObservableCollection<DichVu_DaChon> lsDV) : this()
        {
            this.Phong = ph;
			ls = lsDV.ToList();
			try
			{
				

                txbSoPhong.Text = Phong.Maphong;
                if (Phong.Isday == 1)
                {
                    txbSoNgayOrGio.Text = "Số ngày: ";
                    txbSoNgay.Text = Phong.Songay.ToString();
                }

                txbTenKH.Text = Phong.Tenkh;
                txbSoNguoi.Text = Phong.Songuoiht.ToString();
                txbNgayLapHD.Text = DateTime.Now.ToString();
				txbQuocTich.Text = Phong.Tenloaikh;
				txbPTQoTich.Text = Phong.Str_hspt;
				Double phuthu = HoaDonBUS.Instance.GetTyLePhuThuNguuoiO(Phong.Songuoiht);
				txbPhuThu.Text = phuthu.ToString();
				Double tienPhong = PhongBUS.Instance.tinhTienPhong(Phong);
				Double TinhTongTien = PhongBUS.Instance.tinhTongTien(Phong, Double.Parse(Phong.Str_hspt), phuthu, tienPhong);
				txbTongTien.Text = string.Format("{0:0,0 VND}", TinhTongTien);

                //Thêm hóa đơn vào DB
                HoaDon hd = new HoaDon()
                {
                    Mactpt = Phong.Mactpt,
                    Checkout = DateTime.Now,
                    Tongtien = int.Parse((TinhTongTien).ToString())
                };
                string error = string.Empty;
                hd = HoaDonBUS.Instance.themHoaDon(hd, Phong.Maphieu);
                if (hd == null)
                {
                    new DialogCustoms("Thêm hóa đơn thất bại!\nLỗi:" + error, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
                txbSoHoaDon.Text = hd.Mahoadon;
                //Sửa trạng thái của ctpt
                string errorSuaCTPT = string.Empty;
                if (!CT_PhieuThueBUS.Instance.suaTinhTrangTraPhong(Phong.Maphong , "Phòng trống", "Chưa dọn dẹp"))
                {
                    new DialogCustoms("Lỗi sửa CTPT\nLỗi: "+ errorSuaCTPT, "Thông báo", DialogCustoms.OK).ShowDialog();
                }


                DichVu_DaChon dv = new DichVu_DaChon()
                {
                    SoLuong =  Phong.Songay,
                    TenDV = "Thuê phòng",
                    Gia = PhongBUS.Instance.layTienPhongTheoSoPhong(Phong),
                    ThanhTien = tienPhong
                };
				ls.Add(dv);
				Double pthoadon, thanhtien;
				if (Phong.Tenloaikh == "Nước ngoài")
				{
					pthoadon = Double.Parse((Double.Parse(Phong.Str_hspt)-1).ToString());
					thanhtien = tienPhong * (Double.Parse(Phong.Str_hspt) -1);
				}
				else
				{
					pthoadon = phuthu;
					thanhtien = tienPhong * phuthu;
				}

				DichVu_DaChon dvpt = new DichVu_DaChon()
				{
					SoLuong = 1,
					TenDV = "Phụ thu",
					Gia = pthoadon,
					ThanhTien = thanhtien
				};
				ls.Add(dvpt);
				lvDichVuDaSD.ItemsSource = ls;
			}
            catch (Exception)
            {
                 new DialogCustoms("Lỗi load thông tin!", "Thông báo", DialogCustoms.OK).ShowDialog();
			}
		}

		public XuatHoaDon(string mahd, DateTime checkout) : this()
		{
			try
			{
				
				HoaDonX hd = HoaDonBUS.Instance.layHoaDonTheoMaHoaDon(mahd, checkout);
				if (hd == null)
				{
					new DialogCustoms("Hóa đơn không tồn tại!", "Thông báo", DialogCustoms.OK).ShowDialog();
					return;
				}
				txbNhanVien.Text = "Nguyễn Thanh Thiện";
				txbSoPhong.Text = hd.Maphong;
				DateTime ngayBD = hd.Ngaybd;
				DateTime ngayKT = hd.Ngaykt;
				TimeSpan Time = ngayKT - ngayBD;
				int songay = (int)Time.TotalDays + 1;
				txbSoNgayOrGio.Text = "Số ngày: ";
				txbSoNgay.Text = songay.ToString();


				txbSoHoaDon.Text = mahd.ToString();
				txbTenKH.Text = KhachHangBUS.Instance.layTenKhachHangTheoMaPT(hd.Maphieu);
				txbSoNguoi.Text = hd.Songuoi.ToString();
				txbNgayLapHD.Text = hd.Checkout.ToString();
				txbTongTien.Text = string.Format("{0:0,0 VND}", hd.Tongtien);
				
				Double phuthunguoio = HoaDonBUS.Instance.GetTyLePhuThuNguuoiO(hd.Songuoi);
				txbPhuThu.Text = phuthunguoio.ToString();
				txbPTQoTich.Text = hd.Hesoptqt;
				txbQuocTich.Text = hd.Tenlkh ;
				Double tienphong = songay * PhongBUS.Instance.layTienPhongTheoMaPhong(hd.Maphong, 1);
				List<DichVu_DaChon> ls;
				ls = new List<DichVu_DaChon>();
				DichVu_DaChon dv = new DichVu_DaChon()
				{
					SoLuong = songay,
					TenDV = "Thuê phòng",
					Gia = PhongBUS.Instance.layTienPhongTheoMaPhong(hd.Maphong, 1),
					ThanhTien = tienphong
				};

				ls.Add(dv);
				Double pthoadon, thanhtien;
				if (hd.Tenlkh == "Nước ngoài")
				{
					pthoadon = Double.Parse(hd.Hesoptqt)-1;
					thanhtien = tienphong * (Double.Parse(hd.Hesoptqt) - 1);
				}
				else
				{
					pthoadon = phuthunguoio;
					thanhtien = tienphong * phuthunguoio;
				}
				DichVu_DaChon dvpt = new DichVu_DaChon()
				{
					SoLuong = 1,
					TenDV = "Phụ thu",
					Gia = pthoadon,
					ThanhTien = thanhtien
				};
				ls.Add(dvpt);
				lvDichVuDaSD.ItemsSource = ls;

			}
			catch (Exception ex)
			{
				new DialogCustoms("Lỗi: " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
			}

		}

		private void click_InHoaDon(object sender, RoutedEventArgs e)
		{
			try
			{
				btnInHoaDon.Visibility = Visibility.Hidden;
				PrintDialog printDialog = new PrintDialog();
				if (printDialog.ShowDialog() == true)
				{
					printDialog.PrintVisual(print, "In Hóa đơn");
					new DialogCustoms("In hóa đơn thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
				}
			}
			catch (Exception ex)
			{
				new DialogCustoms("In hóa đơn thất bại! \n Lỗi: " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
			}
			finally
			{
				btnInHoaDon.Visibility = Visibility.Visible;
			}
		}


	}
}
