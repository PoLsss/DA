using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class PTKHQT_LastRe
	{
		public PTKHQT_LastRe() { }
		private string ma;
		public PTKHQT_LastRe(DataRow row) {
			this.Ma = row["MaLoaiKH"].ToString();
		}
		public string Ma { get => ma; set => ma = value; }
	}
}
