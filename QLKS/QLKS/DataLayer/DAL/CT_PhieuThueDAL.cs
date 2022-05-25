using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class CT_PhieuThueDAL
	{
		private static CT_PhieuThueDAL instance;
		
		public static CT_PhieuThueDAL Instance
		{
			get { if (instance == null) instance = new CT_PhieuThueDAL(); return CT_PhieuThueDAL.instance; }
			set { CT_PhieuThueDAL.instance = value; }
		}
		private CT_PhieuThueDAL() { }

		public List<CT_PhieuThue> getPhieuThueTheoMaPT(string mactpt) {
			List<CT_PhieuThue> list = new List<CT_PhieuThue>();
			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetCTPhieuTheoMaPhieu @MaCTPhieu ", new object[] { (object)mactpt });
			foreach (DataRow item in data.Rows) {
				CT_PhieuThue ct = new CT_PhieuThue(item);
				list.Add(ct);
			}
			return list;
		}
		public bool addCTPhieuThue(PhieuThue pt) {

			PhieuThue_LastRe last = new PhieuThue_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRecord");
			if (row.Rows.Count == 0)
				last.Maph = "PT000";
			else last = new PhieuThue_LastRe(row.Rows[0]);
			string cat = last.Maph.Substring(2, 3);
			int conver1 = int.Parse(cat) + 1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string maph;
			if (lens == 1)
				maph = "PT00" + convert2;
			else if (lens == 2)
				maph = "PT0" + convert2;
			else maph = "PT" + convert2;

			string query = "USP_INSERT_CTPT @TinhTrang , @SoNguoi , @MaPhong , @NgayBD , @NgayKT , @MaCTPT , @MaPhieu ";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] {pt.Tinhtrang, pt.Songuoi, pt.Maphong, pt.Ngaybd, pt.Ngaykt, pt.Mactphieu , (object)maph})>0;
		}
		public bool suaTinhTrangThuePhong(string maphong, string tinhtrang) {
			string query = "USP_UpdateTinhTrangPhong @MaPhong , @TinhTrang";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] {(object)maphong, (object)tinhtrang}) > 0;
		}
		public bool suaTinhTrangTraPhong(string maphong, string tinhtrang, string dondep) {
			string query = "USP_Update_TTP @MaP , @TT , @DonDep ";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { (object)maphong, (object)tinhtrang, (object)dondep }) > 0;
		}

	}
}
