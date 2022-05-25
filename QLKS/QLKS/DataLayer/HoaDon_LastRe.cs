using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class HoaDon_LastRe
	{
		private string mahd;

		public string Mahd { get => mahd; set => mahd = value; }
		public HoaDon_LastRe(DataRow row) {
			this.Mahd = row["MaHD"].ToString();
		}
		public HoaDon_LastRe() { }
	}
}
