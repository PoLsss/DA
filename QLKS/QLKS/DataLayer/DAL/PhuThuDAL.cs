using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class PhuThuDAL
	{
		private static PhuThuDAL instance;

		public static PhuThuDAL Instance {
			get { if (instance == null) instance = new PhuThuDAL(); return PhuThuDAL.instance; }
			set { PhuThuDAL.instance = value; }
		}
		public List<PhuThu> getdataNguoiO() {
			List<PhuThu> listkh = new List<PhuThu>();
			DataTable data = DataProvider.Ins.ExecuteQuery("select * from PHUTHU");
			foreach (DataRow item in data.Rows)
			{
				PhuThu kh = new PhuThu(item);
				listkh.Add(kh);
			}
			return listkh;

		}
		public List<PhuThuKhachQT> getdataKhachQT() {
			List<PhuThuKhachQT> listkh = new List<PhuThuKhachQT>();
			DataTable data = DataProvider.Ins.ExecuteQuery("select * from LOAIKH");
			foreach (DataRow item in data.Rows)
			{
				PhuThuKhachQT kh = new PhuThuKhachQT(item);
				listkh.Add(kh);
			}
			return listkh;
		}
		public bool capNhatDataPTKQT(PhuThuKhachQT pt) {
			string query = "USP_UpdatePTQT @Ma , @TenLKH , @Heso";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { pt.Maloaikh, pt.Tenlkh, pt.Heso }) > 0;
		}
		public bool capNhatDataPTNgO(PhuThu pt)
		{
			string query = "USP_UpdatePTNguoiO @TenPT , @SK , @TyLe , @MaPT";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { pt.Tenpt, pt.Sokh, pt.Tylept, pt.Maphuthu }) > 0;
		}

		public bool KiemTraTrungTenPTQT(PhuThuKhachQT pt) {
			string query = "USP_CheckTrungTenLKH @TenLKH";
			var check = DataProvider.Ins.ExecuteScalar(query, new object[] { pt.Tenlkh });
			if (check == null)
				return true;
			return false;
		}
		public bool ThemPTQT(PhuThuKhachQT pt) {
			PTKHQT_LastRe last = new PTKHQT_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("SELECT TOP 1 * FROM LOAIKH ORDER BY MaLoaiKH DESC");
			if (row.Rows.Count == 0)
				last.Ma = "LKH01";
			else
				last = new PTKHQT_LastRe(row.Rows[0]);
			string cat = last.Ma.Substring(3, 2);
			int conver1 = int.Parse(cat) + 1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string mactph;
			if (lens == 1)
				mactph = "LKH0" + convert2;
			else mactph = "LKH" + convert2;

			string query = "USP_InsertKHQT @TenLKH , @Heso , @Ma";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { pt.Tenlkh, pt.Heso, mactph }) > 0;
		}
		public void DelPTKhachQT(PhuThuKhachQT pt) {
			string query = " USP_DelPTKhachQT @MaLKH";
			DataProvider.Ins.ExecuteNoneQuery(query, new object[] { pt.Maloaikh });
		}
		public bool KiemTraTrungTenPTNguoiO(PhuThu pt) {
			string query = "USP_CheckTrungTenPTNgO @TenPT";
			var check = DataProvider.Ins.ExecuteScalar(query, new object[] { pt.Tenpt });
			if (check == null)
				return true;
			return false;
		}
		public bool ThemPTNguoiO(PhuThu pt) {
			string query = "USP_InsertPTNgO @Tenpt , @SK , @TyLe";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { pt.Tenpt, pt.Sokh, pt.Tylept }) > 0;
		}
		public void DelPTNguoiO(PhuThu pt) {
			string query = "USP_DelPHUTHU @MaPT";
			DataProvider.Ins.ExecuteNoneQuery(query, new object[] {pt.Maphuthu });
		}
	}
}
