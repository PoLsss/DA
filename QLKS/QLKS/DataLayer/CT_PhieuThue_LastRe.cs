using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class CT_PhieuThue_LastRe
	{
		private string mact;
		public CT_PhieuThue_LastRe() { }
		public string Mact { get => mact; set => mact = value; }
		public CT_PhieuThue_LastRe(DataRow row) {
			this.Mact = row["MaCTPT"].ToString();
		}
	}
}
