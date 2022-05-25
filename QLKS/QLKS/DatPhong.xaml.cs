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
using QLKS.Model;

namespace QLKS
{
	/// <summary>
	/// Interaction logic for DatPhong.xaml
	/// </summary>
	public partial class DatPhong : Window
	{
        public delegate void dlg();

        public dlg luuPhieuDatPhong;
        ObservableCollection<PhongTrong> lsPhongTrongs;
        ObservableCollection<PhieuThue> lsPDaChons;
        List<PhongTrong> lsPhongCaches;
        private int maNV;

        public DatPhong()
        {
            InitializeComponent();
        }


        #region method
        private void getPhongTrongTheoNgayGio()
        {
            DateTime ngayBD = DateTime.Parse(dtpNgayBD.Text);
            DateTime ngayKT = DateTime.Parse(dtpNgayKT.Text);
            List<PhongTrong> lsTemp = PhongBUS.Instance.getPhongTrong(ngayBD, ngayKT);
            var ls = (from l in lsTemp
                      where !(from pdc in lsPDaChons select pdc.Maphong).Contains(l.Maphong)
                      select l).ToList();
            lsPhongTrongs = new ObservableCollection<PhongTrong>(ls);
            lvPhongTrong.ItemsSource = lsPhongTrongs;
             
        }

        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txbHoTen.Text))
            {
                txbHoTen.Focus();
                new DialogCustoms("Nhập đầy đủ họ tên !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            //Kiểm tra textbox CCCD rỗng hoặc nhập kí tự chữ không
            else
            {
                if (!long.TryParse(txbCCCD.Text, out long temp))
                {
                    txbCCCD.Focus();
                    new DialogCustoms("Nhập căn cước công dân đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
                if (txbCCCD.Text.Length > 12)
                {
                    txbCCCD.Focus();
                    new DialogCustoms("Nhập căn cước công dân không quá 12 ký tự !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
            }
            //Kiểm tra textbox SDT rỗng hoặc có nhập chữ không
            if (string.IsNullOrWhiteSpace(txbSDT.Text))
            {
                txbSDT.Focus();
                new DialogCustoms("Nhập đầy đủ số điện thoại !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!long.TryParse(txbSDT.Text, out long temp))
                {
                    txbSDT.Focus();
                    new DialogCustoms("Nhập số điện thoại đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
                if (txbSDT.Text.Length > 10)
                {
                    txbSDT.Focus();
                    new DialogCustoms("Nhập số điện thoại không quá 10 ký tự !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
            }
            //Kiểm tra ô nhập địa chỉ
            if (string.IsNullOrWhiteSpace(txbDiaChi.Text))
            {
                txbDiaChi.Focus();
                new DialogCustoms("Nhập đầy đủ địa chỉ !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            //kiểm tra ô quốc tịch
            if (string.IsNullOrWhiteSpace(txbQuocTich.Text))
            {
                txbQuocTich.Focus();
                new DialogCustoms("Nhập đầy đủ quốc tịch !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            //Kiểm tra ô giới tính
            if (string.IsNullOrWhiteSpace(cbGioiTinh.Text))
            {
                new DialogCustoms("Nhập đầy đủ giới tính !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            //Kiểm tra xem đã có phòng nào được chọn chưa
            if (lsPDaChons.Count == 0)
            {
                new DialogCustoms("Vui lòng chọn phòng trước khi lưu !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            return true;
        }
        #endregion

        #region event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Khởi tạo giá trị cho ngày, giờ Bắt đầu và Kết thúc là ngày giờ hiện tại
            var dt = DateTime.Now;
            dtpNgayBD.Text = dt.ToShortDateString();
            dtpNgayKT.Text = dt.ToShortDateString();



            //Khởi tạo sự kiện thay đổi ngày hoặc giờ
            dtpNgayBD.SelectedDateChanged += DT_SelectedDateChanged;
            dtpNgayKT.SelectedDateChanged += DT_SelectedDateChanged;


            //Lấy danh sách phòng trống có thể dặt từ DB lên dựa vào ngày giờ Bắt đầu, Kết thúc
            lsPDaChons = new ObservableCollection<PhieuThue>();
            lsPhongCaches = new List<PhongTrong>();
            lvPhongDaChon.ItemsSource = lsPDaChons;
            getPhongTrongTheoNgayGio();

        }

        private void tpGio_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            DateTime dtNBD;
            DateTime dtNKT;


            if (!DateTime.TryParse(dtpNgayBD.Text, out dtNBD))
            {
                new DialogCustoms("Nhập đúng định dạng ngày bắt đầu !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
            if (!DateTime.TryParse(dtpNgayKT.Text, out dtNKT))
            {
                new DialogCustoms("Nhập đúng định dạng ngày kết thúc !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
           

            getPhongTrongTheoNgayGio();
        }

        private void DT_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string ngayBD = dtpNgayBD.Text;
            string ngayKT = dtpNgayKT.Text;
            DateTime dtNBD;
            DateTime dtNKT;
            if (!DateTime.TryParse(ngayBD, out dtNBD))
            {
                new DialogCustoms("Nhập đúng định dạng ngày bắt đầu !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }

            if (!DateTime.TryParse(ngayKT, out dtNKT))
            {
                new DialogCustoms("Nhập đúng định dạng ngày kết thúc !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
            //nếu ngày bắt đầu lớn hơn ngày kết thúc thì phải báo lỗi ngay
            if (dtNBD > dtNKT)
            {
                new DialogCustoms("Ngày bắt đầu không thể lớn hơn ngày kết thúc !", "Thông báo", DialogCustoms.OK).ShowDialog();
                dtpNgayBD.Text = ngayKT;
                dtpNgayKT.Text = ngayKT;
                return;
            }
            getPhongTrongTheoNgayGio();
        }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Button huy = sender as Button;
            this.Close();
        }

		private void Click_Luu(object sender, RoutedEventArgs e)
		{
            string maKhachHangThemMoi;
			int dem = 0;
			bool checkThemKHThanhCong = false;
			bool themKhachHangMoi = false;

			if (kiemTraDayDuThongTin())
			{
                KhachHang kh = new KhachHang()
				{
					Cmnd = txbCCCD.Text,
					Tenkh = txbHoTen.Text,
					Diachi = txbDiaChi.Text,
					Gioitinh = cbGioiTinh.Text,
					Quoctich = txbQuocTich.Text,
					Sdt = txbSDT.Text
				};
			// THêm khách hàng kiểm tra xem khách hàng đã tồn tại trong CSDL chưa dựa vào SDT nếu có rồi thì không thêm nữa, còn chưa có thì thêm vào CSDL

				maKhachHangThemMoi = KhachHangBUS.Instance.kiemTraTonTaiKhachHang(kh.Sdt);
				if (maKhachHangThemMoi == "Khong_tim_thay")
				{
                    kh =  KhachHangBUS.Instance.addKhachHang(kh);
                    //checkThemKHThanhCong = KhachHangBUS.Instance.addKhachHang(kh, out errorKhachHang);
                    if (kh != null) 
                        checkThemKHThanhCong = true;
                    if (!checkThemKHThanhCong)
					{
						new DialogCustoms("Lỗi: Thêm Khách Hàng Thất Bại", "Thông báo", DialogCustoms.OK).ShowDialog();
						return;
					}
					maKhachHangThemMoi = kh.Makh;
					themKhachHangMoi = true;
				}
				else
				{
					checkThemKHThanhCong = true;
				}
			//Thêm phiếu thuê nếu thêm khách hàng thành công hoặc lấy ra được mã khách hàng đã tồn tại

				if (checkThemKHThanhCong)
				{
					CTPT_DP pt = new CTPT_DP(){ 
                        Ngaylap = DateTime.Now,
                        Makh = maKhachHangThemMoi
                    };
                    pt = PhieuThueBUS.Instance.addPhieuThue(pt);

                    if (pt!=null)
                    {
					    // Thêm CT phiếu thuê
                        

						foreach (PhieuThue item in lsPDaChons)
						{
                            
							item.Mactphieu = pt.Mactpt ;
							item.Tinhtrang = "Phòng đã đặt";
							if (CT_PhieuThueBUS.Instance.addCTPhieuThue(item))
							{
								dem++;
							}
							else
							{
								new DialogCustoms("Lỗi: Thêm CTPT Không Thành Công ", "Thông báo", DialogCustoms.OK).ShowDialog();
								break;
							}
						}
					}
					else
					{
						new DialogCustoms("Lỗi: Thêm Phiếu Thuê Không Thành Công" , "Thông báo", DialogCustoms.OK).ShowDialog();
					}

				}



				if (dem == lsPDaChons.Count && dem != 0)
				{
					if (themKhachHangMoi)
					{
						new DialogCustoms("Thêm khách hàng mới và đặt phòng thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
					}
					else
					{
						new DialogCustoms("Khách hàng đã tồn tại và đặt phòng thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
					}

					if (luuPhieuDatPhong != null)
					{
						luuPhieuDatPhong();
					}
					this.Close();
				}
				else
				{
					new DialogCustoms("Đặt phòng thất bại  !", "Thông báo", DialogCustoms.OK).ShowDialog();
				}
			}

		}

		private void Click_ThemPhong(object sender, RoutedEventArgs e)
		{
			PhongTrong ephongTrong = (sender as Button).DataContext as PhongTrong;
			lsPhongCaches.Add(ephongTrong);
			lsPhongTrongs.Remove(ephongTrong);
			PhieuThue phongDaChon = new PhieuThue()
			{
				Maphong = ephongTrong.Maphong,
				Songuoi = 1,
				Ngaybd = DateTime.Parse(dtpNgayBD.Text),
				Ngaykt = DateTime.Parse(dtpNgayKT.Text)
			};
			lsPDaChons.Add(phongDaChon);
		}


		private void click_Delete(object sender, RoutedEventArgs e)
		{
			PhieuThue phongDaChon = (sender as Button).DataContext as PhieuThue;
			foreach (PhongTrong pt in lsPhongCaches)
			{
				if (pt.Maphong.Equals(phongDaChon.Maphong))
				{
					lsPhongTrongs.Add(pt);
					lsPhongCaches.Remove(pt);
					break;
				}
			}
			lsPDaChons.Remove(phongDaChon);
		}
		private void txbSoLuong_LostFocus(object sender, RoutedEventArgs e)
		{
			TextBox txb = sender as TextBox;
			PhieuThue ctpt = (sender as TextBox).DataContext as PhieuThue;
			int soNguoi = 1;
			if (!int.TryParse(txb.Text, out soNguoi))
			{
				new DialogCustoms("Lỗi: Nhập số người kiểu số nguyên !", "Thông báo", DialogCustoms.OK).ShowDialog();
				return;
			}
            int kh_max = GetSoKHMax(ctpt.Maphong);
            if (soNguoi > kh_max)
            {
                new DialogCustoms("Lỗi:Số khách tối đa của phòng là " + kh_max.ToString() + " khách\n" +
                        " Không thể vượt số khách hàng tối đa của loại phòng !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
            else
                ctpt.Songuoi = soNguoi;
		}


		#endregion

		private void txbSoLuong_KeyUp(object sender, KeyEventArgs e)
	{
			if (e.Key == Key.Enter)
			{
				TextBox txb = sender as TextBox;
				PhieuThue ctpt = (sender as TextBox).DataContext as PhieuThue;
				int soNguoi = 1;
				if (!int.TryParse(txb.Text, out soNguoi))
				{
					new DialogCustoms("Lỗi: Nhập số người kiểu số nguyên !", "Thông báo", DialogCustoms.OK).ShowDialog();
					return;
				}
                int kh_max = GetSoKHMax(ctpt.Maphong);
                if (soNguoi > kh_max) {
                    new DialogCustoms("Lỗi:Số khách tối đa của phòng là "+ kh_max.ToString()+ " khách\n"+
                        " Không thể vượt số khách hàng tối đa của loại phòng !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return;
                }
                else
                    ctpt.Songuoi = soNguoi;
			}
		}
        public int GetSoKHMax(string maphong) {
            string query = "USP_GetSoKHMax @MaPhong";
            return (int)DataProvider.Ins.ExecuteScalar(query, new object[] { maphong});
        }
	}
}
