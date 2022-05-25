using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class PhuThuKhachQT
	{
		private string maloaikh;
		private string tenlkh;
		private double heso;
		public PhuThuKhachQT() { }

		public PhuThuKhachQT(DataRow row)
		{
			this.Maloaikh = row["MaLoaiKH"].ToString();
			this.Tenlkh = row["TenLoaiKH"].ToString();
			this.Heso = (double)row["HeSoPhuThu"];
		}

		public string Maloaikh { get => maloaikh; set => maloaikh = value; }
		public string Tenlkh { get => tenlkh; set => tenlkh = value; }
		public double Heso { get => heso; set => heso = value; }
	}
}
