using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class KhachHang
	{
		private string makh;
		private string tenkh;
		private string sdt;
		private string diachi;
		private string quoctich;
		private string cmnd;
		private string maloaikh;
		private string gioitinh;

		public string Makh { get => makh; set => makh = value; }
		public string Tenkh { get => tenkh; set => tenkh = value; }
		public string Sdt { get => sdt; set => sdt = value; }
		public string Diachi { get => diachi; set => diachi = value; }
		public string Quoctich { get => quoctich; set => quoctich = value; }
		public string Cmnd { get => cmnd; set => cmnd = value; }
		public string Maloaikh { get => maloaikh; set => maloaikh = value; }
		public string Gioitinh { get => gioitinh; set => gioitinh = value; }

		public KhachHang() { }

		public KhachHang(DataRow row) {
			this.Makh = row["MaKH"].ToString();
			this.Tenkh = row["TenKH"].ToString();
			this.Quoctich = row["QuocTich"].ToString();
			this.Sdt = row["SDT"].ToString();
			this.Maloaikh = row["MaLoaiKH"].ToString();
			this.Diachi = row["DiaChi"].ToString();
			this.Cmnd = row["CMND"].ToString();
			this.Gioitinh = row["GioiTinh"].ToString();
		}

	}
}
