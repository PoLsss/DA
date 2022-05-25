using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class CTPT_DP
	{
		private string mactpt;
		private string makh;
		private DateTime ngaylap;

		public string Mactpt { get => mactpt; set => mactpt = value; }
		public string Makh { get => makh; set => makh = value; }
		public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }

		public CTPT_DP() { }
		public CTPT_DP(DataRow row) {
			this.Mactpt = row["MaCTPT"].ToString();
			this.Makh = row["MaKH"].ToString();
			this.Ngaylap = (DateTime)row["NgayLap"];
		}
	}
}
