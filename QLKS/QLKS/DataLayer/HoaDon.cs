using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class HoaDon
	{
		public HoaDon() { }
		private string mahoadon;
		private string tenNHanVienLap;
		private DateTime checkout;
		private int status;
		private string mactpt;
		private int tongtien;

		public string Mahoadon { get => mahoadon; set => mahoadon = value; }

		public DateTime Checkout { get => checkout; set => checkout = value; }
		public int Status { get => status; set => status = value; }
		public string Mactpt { get => mactpt; set => mactpt = value; }
		public int Tongtien { get => tongtien; set => tongtien = value; }

		public string TenNHanVienLap { get => tenNHanVienLap; set => tenNHanVienLap = value; }

		public HoaDon(DataRow row)
		{
			this.Mahoadon = row["MaHD"].ToString();
			this.Checkout = (DateTime)row["CheckOut"];
			this.status = (int)row["Status"];
			this.Mactpt = row["MaCTPT"].ToString();
			this.Tongtien = (int)row["TongTien"];
			this.TenNHanVienLap = "Nguyễn Thanh Thiện";

		}
	}
}
