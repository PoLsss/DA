using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class ThongKeDAL
	{
		private static ThongKeDAL instance;

		public static ThongKeDAL Instance {
			get { if (instance == null) instance = new ThongKeDAL(); return ThongKeDAL.instance; }
			set { ThongKeDAL.instance = value; }
		}
		public ThongKeDAL() { }

		public int GetDoanhThuThang(int month, int year, string loaiphong) {
			string query = "USP_GetDoanhThuTheoLoaiPhong @TenLP , @Thang , @Nam";

			var check = DataProvider.Ins.ExecuteScalar(query, new object[] { loaiphong, month, year });
			if (check != null)
				return (int)check;
			else return -1;
		}
		public int GetSOluongPhongDat(int month, int year) {
			return (int)DataProvider.Ins.ExecuteScalar("USP_GetSLPhongDaDat @month , @year", new object[] { month, year });
		}
		public int GetDoanhThuLP_ALL(string tenlp){
			string query = "USP_GetDoanhThuTheoLPALL @TenLP";
			var checknull = DataProvider.Ins.ExecuteScalar(query, new object[] { tenlp });
			if (checknull != null)
				return (int)checknull;
			else return 0;
			
		}
		public int GetSoLuongPhongDat() {
			string query = "select count(MaPhieu) from NHATKI";
			return (int)DataProvider.Ins.ExecuteScalar(query);
		}

		public List<ThongKe> GetDanhSach(int month) {
			string query = " USP_GetDoanhThuLPtheoThang  @month";
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] { month});
			List<ThongKe> listtk = new List<ThongKe>();
			int id = 1;
			foreach (DataRow item in data.Rows)
			{
				ThongKe tk = new ThongKe(item, id);
				listtk.Add(tk);
				id++;
			}
			return listtk;
		}
	}
}
