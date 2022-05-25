using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
	public class PhieuThue_LastRe
	{
		public PhieuThue_LastRe() { }
		private string maph;

		public string Maph { get => maph; set => maph = value; }

		public PhieuThue_LastRe(DataRow row) {
			this.Maph = row["MaPhieu"].ToString();
		}
	}
}
