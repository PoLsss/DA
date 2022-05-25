using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class LoaiPhong_LastRe
	{
		public LoaiPhong_LastRe() { }
		private string malp;

		public string Malp { get => malp; set => malp = value; }
		public LoaiPhong_LastRe(DataRow row) {
			this.Malp = row["MaLoaiPhong"].ToString();
		}
	}
}
