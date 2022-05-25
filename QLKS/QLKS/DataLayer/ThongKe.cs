using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class ThongKe
	{
		public ThongKe() { }

		private string loaiphong;
		private int doanhthu;
		private int thang;
		private Int64 tyle;
		private int id ;
		
		public string Loaiphong { get => loaiphong; set => loaiphong = value; }
		public int Doanhthu { get => doanhthu; set => doanhthu = value; }
		public int Thang { get => thang; set => thang = value; }
		
		public int Id { get => id; set => id = value; }
		public long Tyle { get => tyle; set => tyle = value; }

		public ThongKe(DataRow row, int id) {
			this.Doanhthu = (int)row["DoanhThu"];
			this.Loaiphong = row["TenLoaiPhong"].ToString();
			this.Thang = (int)row["Thang"];
			this.Tyle = (Int64)row["TyLe"];
			this.Id = id;
			
		}
	}
}
