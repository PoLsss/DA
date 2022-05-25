using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class Phong
	{
		private string maphong;
		private string tenphong;
		private string dondep;
		private string tinhtrang;
		private string tenloaiphong;
		private string tenkh;
		private int songay;
		private int isday;
		private string ngaybatdau;
		private int songuoiht;
		private string ngaykt;
		private string mactpt;
		private string maphieu;
		private string tenloaikh;
		private double hesophuthu;
		private string str_hspt;
		public string Maphong { get => maphong; set => maphong = value; }
		public string Tenphong { get => tenphong; set => tenphong = value; }
		public string Dondep { get => dondep; set => dondep = value; }
		public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
		public string Tenloaiphong { get => tenloaiphong; set => tenloaiphong = value; }
		public string Tenkh { get => tenkh; set => tenkh = value; }
		public int Songay { get => songay; set => songay = value; }
		public int Isday { get => isday; set => isday = value; }
		public string Ngaybatdau { get => ngaybatdau; set => ngaybatdau = value; }
		public int Songuoiht { get => songuoiht; set => songuoiht = value; }
		public string Ngaykt { get => ngaykt; set => ngaykt = value; }
		public string Mactpt { get => mactpt; set => mactpt = value; }
		public string Maphieu { get => maphieu; set => maphieu = value; }
		public string Tenloaikh { get => tenloaikh; set => tenloaikh = value; }

		public string Str_hspt { get => str_hspt; set => str_hspt = value; }

		public Phong() { }
		public Phong(DataRow row)
		{
			this.Maphong = row["MaPhong"].ToString();
			this.Tenphong = row["TenPhong"].ToString();
			this.Dondep = row["DonDep"].ToString();
			this.Tinhtrang = row["TinhTrang"].ToString();
			this.Tenloaiphong = row["TenLoaiPhong"].ToString();
			this.Tenkh = row["TenKH"].ToString();
			var checknullday = row["IsDay"].ToString();
			if(checknullday != "")
				this.Isday = (int) row["IsDay"];
			var checknbd = row["NgayBD"].ToString();
			if (checknbd != "")
				this.Ngaybatdau = row["NgayBD"].ToString();
			else this.Ngaybatdau = "";
			var checknkt = row["NgayKT"].ToString();
			if (checknkt != "")
				this.Ngaykt = row["NgayKT"].ToString();
			var checksong = row["SoNguoiHT"].ToString();
			if (checksong != "")
				this.Songuoiht = (int)row["SoNguoiHT"];
			else songuoiht = 0;
			if (checknbd != "" && checknkt != "")
				this.Songay = (DateTime.Parse(Ngaykt) - DateTime.Parse(Ngaybatdau)).Days+1;
			else if (checknbd != "" && checknkt == "")
				this.Songay = (DateTime.Now - DateTime.Parse(Ngaybatdau)).Days +1;
			var checkmact = row["MaCTPT"].ToString();
			if(checkmact != "")
				this.Mactpt = row["MaCTPT"].ToString();
			this.Maphieu = row["MaPhieu"].ToString();
			this.Tenloaikh = row["TenLoaiKH"].ToString();
			this.Str_hspt = row["HeSoPhuThu"].ToString();

		}


	}
}
