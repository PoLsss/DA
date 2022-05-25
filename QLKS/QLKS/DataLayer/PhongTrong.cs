using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class PhongTrong
	{
		public PhongTrong() { }

		private string maphong;
		private string tenphong;
		private string maloaiphong;
		private string dondep;
		private string tinhtrang;
		private string tenloaiphong;





		public string Maphong { get => maphong; set => maphong = value; }
		public string Tenphong { get => tenphong; set => tenphong = value; }
		public string Maloaiphong { get => maloaiphong; set => maloaiphong = value; }
		public string Dondep { get => dondep; set => dondep = value; }
		public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
		public string Tenloaiphong { get => tenloaiphong; set => tenloaiphong = value; }





		public PhongTrong(DataRow row)
		{
			this.Maphong = row["MaPhong"].ToString();
			this.Maloaiphong = row["MaLoaiPhong"].ToString();
			this.Tenphong = row["TenPhong"].ToString();
			this.Dondep = row["DonDep"].ToString();
			this.Tinhtrang = row["TinhTrang"].ToString();
			this.Tenloaiphong = row["TenLoaiPhong"].ToString();

		}
	}
}
