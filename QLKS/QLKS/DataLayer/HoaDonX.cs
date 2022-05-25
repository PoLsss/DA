using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class HoaDonX
	{
		public HoaDonX() { }
		private string mahoadon;
		private string tenNHanVienLap;
		private DateTime checkout;
		private int status;
		private string mactpt;
		private int tongtien;
		private string tenlkh;
		private string hesoptqt;
		private string maphong;
		private DateTime ngaybd;
		private DateTime ngaykt;
		private int songuoi;
		private string maphieu;
		private CT_PhieuThueX ctpt;
		
		public string Mahoadon { get => mahoadon; set => mahoadon = value; }
		public DateTime Checkout { get => checkout; set => checkout = value; }
		public int Status { get => status; set => status = value; }
		public string Mactpt { get => mactpt; set => mactpt = value; }
		public int Tongtien { get => tongtien; set => tongtien = value; }
		public string TenNHanVienLap { get => tenNHanVienLap; set => tenNHanVienLap = value; }
		public CT_PhieuThueX Ctpt { get => ctpt; set => ctpt = value; }
		public string Tenlkh { get => tenlkh; set => tenlkh = value; }
		public string Hesoptqt { get => hesoptqt; set => hesoptqt = value; }
		public string Maphong { get => maphong; set => maphong = value; }
		public DateTime Ngaybd { get => ngaybd; set => ngaybd = value; }
		public DateTime Ngaykt { get => ngaykt; set => ngaykt = value; }
		public int Songuoi { get => songuoi; set => songuoi = value; }
		public string Maphieu { get => maphieu; set => maphieu = value; }

		public HoaDonX(DataRow row)
		{
			this.Mahoadon = row["MaHD"].ToString();
			this.Checkout = (DateTime)row["CheckOut"];
			this.status = (int)row["Status"];
			this.Mactpt = row["MaCTPT"].ToString();
			this.Tongtien = (int)row["TongTien"];
			this.TenNHanVienLap = "Nguyễn Thanh Thiện";
			this.Maphong = row["MaPhong"].ToString();
			this.Ngaybd = (DateTime)row["NgayBD"];
			this.Ngaykt = (DateTime)row["NgayKT"];
			this.Songuoi = (int)row["SoNguoiHT"];
			this.Hesoptqt = row["HeSoPhuThu"].ToString();
			this.Tenlkh = row["TenLoaiKH"].ToString();
			this.maphieu = row["MaPhieu"].ToString();
		}
	}
}
