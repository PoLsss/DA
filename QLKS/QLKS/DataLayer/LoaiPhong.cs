using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class LoaiPhong
	{
		private string maloaiphong;
		private string tenloaiphong;
		private int dongia;
		private int sokhmax;

		public string Maloaiphong { get => maloaiphong; set => maloaiphong = value; }
		public string Tenloaiphong { get => tenloaiphong; set => tenloaiphong = value; }
		public int Sokhmax { get => sokhmax; set => sokhmax = value; }
		public int Dongia { get => dongia; set => dongia = value; }

		public LoaiPhong() { }

		public LoaiPhong(DataRow row) {
			this.Maloaiphong = row["MaLoaiPhong"].ToString();
			this.Tenloaiphong = row["TenLoaiPhong"].ToString();
			this.Dongia = (int)row["DonGia"];
			this.Sokhmax = (int)row["SoKHMax"];
			

		}

	}
}
