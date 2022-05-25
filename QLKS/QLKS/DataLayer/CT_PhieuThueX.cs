using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class CT_PhieuThueX
	{
		public CT_PhieuThueX() { }
		private string maphong;
		private DateTime ngaybd;
		private DateTime ngaykt;
		private int songuoi;
		private string maphieu;

		public string Maphong { get => maphong; set => maphong = value; }
		public DateTime Ngaybd { get => ngaybd; set => ngaybd = value; }
		public DateTime Ngaykt { get => ngaykt; set => ngaykt = value; }
		public int Songuoi { get => songuoi; set => songuoi = value; }
		public string Maphieu { get => maphieu; set => maphieu = value; }

		public CT_PhieuThueX(DataRow row) {
			this.Maphong = row["MaPhong"].ToString();
			this.Ngaybd = (DateTime)row["NgayBD"];
			var checknkt = row["NgayKT"].ToString();
			if (checknkt != "")
				this.Ngaykt = (DateTime)row["NgayKT"];
			this.Songuoi = (int)row["SoNguoiHT"];
			this.Maphieu = row["MaPhieu"].ToString();
		}
	}
}
