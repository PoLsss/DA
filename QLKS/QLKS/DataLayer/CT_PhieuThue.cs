using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class CT_PhieuThue
	{
		private string maphong;
		private string maphieu;
		private string tenkh;
		private DateTime ngaybd;
		private int songayo;
		private DateTime ngaykt;
		private int songuoi;
		private string makh;
		private string tinhtrang;
		private int isday;
		private DateTime ngaylap;

		public CT_PhieuThue() { }
		public string Maphieu { get => maphieu; set => maphieu = value; }
		public string Tenkh { get => tenkh; set => tenkh = value; }
		public DateTime Ngaybd { get => ngaybd; set => ngaybd = value; }
		public DateTime Ngaykt { get => ngaykt; set => ngaykt = value; }
		public int Songuoi { get => songuoi; set => songuoi = value; }
		public int Songayo { get => songayo; set => songayo = value; }
		public string Maphong { get => maphong; set => maphong = value; }
		public string Makh { get => makh; set => makh = value; }
		public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
		public int Isday { get => isday; set => isday = value; }
		public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }

		public CT_PhieuThue(DataRow row) {
			this.Ngaybd = (DateTime)row["NgayBD"];
			var checknkt = row["NgayKT"].ToString();
			if (checknkt != "")
				this.Ngaykt = (DateTime)row["NgayKT"];
			this.Maphieu = row["MaPhieu"].ToString();
			this.Tenkh = row["TenKH"].ToString();
			this.Isday = (int)row["IsDay"];
			this.Ngaylap = (DateTime)row["NgayLap"];
			this.Makh = row["MaKH"].ToString();
			this.Tinhtrang = row["TinhTrang"].ToString();
			this.Maphong = row["MaPhong"].ToString();
			this.Songayo = (Ngaykt - Ngaybd).Days + 1;
			this.Songuoi = (int)row["SoNguoiHT"];

		}
	}
}

