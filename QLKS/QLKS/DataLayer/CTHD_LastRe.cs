using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class CTHD_LastRe
	{
		private string cthd;

		public string Cthd { get => cthd; set => cthd = value; }
		public CTHD_LastRe() { }
		public CTHD_LastRe(DataRow row) {
			this.Cthd = row["MaCTHD"].ToString();
		}
	}
}
