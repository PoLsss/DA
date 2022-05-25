using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class PhieuThueDAL
	{
		public PhieuThueDAL() { }
		private static PhieuThueDAL instance;

		public static PhieuThueDAL Instance {
			get { if (instance == null) instance = new PhieuThueDAL(); return PhieuThueDAL.instance; }
			set { PhieuThueDAL.instance = value; }
		}
		public List<PhieuThue> getDataFromDB() {
			List<PhieuThue> listphieu = new List<PhieuThue>();
			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetPhieu");

			foreach (DataRow item in data.Rows)
			{
				PhieuThue phieu = new PhieuThue(item);
				listphieu.Add(phieu);
			}
			return listphieu;

		}
		public bool xoaPhieuThueTheoMaPhieuThue(string maCTphieu) {
		//	var mactpt = DataProvider.Ins.ExecuteScalar("USP_GetMaCTPTTheoMaPhieu @MaPhieu", new object[] { (object)maphieu});
		//	var mahd = DataProvider.Ins.ExecuteScalar("");
			return DataProvider.Ins.ExecuteNoneQuery("USP_Del_CTPT @MaCTPhieu ", new object[] { (object)maCTphieu })>0;
		}

		public CTPT_DP addPhieuThue(CTPT_DP pt) {
			CT_PhieuThue_LastRe last = new CT_PhieuThue_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_CTPT");
			if (row.Rows.Count == 0)
				last.Mact = "CT000";
			else 
				last = new CT_PhieuThue_LastRe(row.Rows[0]);
			string cat = last.Mact.Substring(2, 3);
			int conver1 = int.Parse(cat) + 1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string mactph;
			if (lens == 1)
				mactph = "CT00" + convert2;
			else if (lens == 2)
				mactph = "CT0" + convert2;
			else mactph = "CT" + convert2;
			DataTable data =  DataProvider.Ins.ExecuteQuery("USP_InsertCTPT_DP @MaCTPT , @MaKH , @NgayLap", new object[] { (Object)mactph, pt.Makh , pt.Ngaylap});
			pt = new CTPT_DP(data.Rows[0]);
			return pt;
		}
		public PhieuThue_LastRe getNewRecord() {;
			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetNewRecord");
			PhieuThue_LastRe pt = new PhieuThue_LastRe(data.Rows[0]);
			return pt; 
		}
	}
}
