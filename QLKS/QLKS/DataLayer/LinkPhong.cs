using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class LinkPhong
	{
		private string maphong;
		private string tenphong;
		private string malp;
		private string tinhtrang;
		private string dondep;
		private int songuoi;
		private string tenlk;

		public string Maphong { get => maphong; set => maphong = value; }
		public string Tenphong { get => tenphong; set => tenphong = value; }
		public string Malp { get => malp; set => malp = value; }
		public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
		public string Dondep { get => dondep; set => dondep = value; }
		public int Songuoi { get => songuoi; set => songuoi = value; }
		public string Tenlk { get => tenlk; set => tenlk = value; }

		public LinkPhong() { }
		public LinkPhong(DataRow row) {
			this.Maphong = row["MaPhong"].ToString();
			this.Tenphong = row["TenPhong"].ToString();
			this.Malp = row["MaLoaiPhong"].ToString();
			this.Tinhtrang = row["TinhTrang"].ToString();
			this.Dondep = row["DonDep"].ToString();
			this.Songuoi = (int)row["SoNguoiHT"];
			this.Tenlk = row["TenLoaiPhong"].ToString();
		}
	}
}
