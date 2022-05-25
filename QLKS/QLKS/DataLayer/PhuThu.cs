using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class PhuThu
	{
		private int maphuthu;
		private int sokh;
		private string tenpt;
		private double tylept;
		public PhuThu() { }

		public int Maphuthu { get => maphuthu; set => maphuthu = value; }
		public int Sokh { get => sokh; set => sokh = value; }
		public string Tenpt { get => tenpt; set => tenpt = value; }
		public double Tylept { get => tylept; set => tylept = value; }

		public PhuThu(DataRow row)
		{
			this.Maphuthu = (int)row["MaPhuThu"];
			this.Sokh = (int)row["STT_KH"];
			this.Tenpt = row["TenPhuThu"].ToString();
			this.Tylept = (double)row["TyLePhuThu"];
		}
	}
}
