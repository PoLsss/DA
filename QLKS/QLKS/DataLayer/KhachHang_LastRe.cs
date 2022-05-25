using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class KhachHang_LastRe
	{
		private string makh;

		public string Makh { get => makh; set => makh = value; }

		public KhachHang_LastRe() { }
		public KhachHang_LastRe(DataRow row) {
			this.Makh = row["MaKH"].ToString();
		}
	}
}
