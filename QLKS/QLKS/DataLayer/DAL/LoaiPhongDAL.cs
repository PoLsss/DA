using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class LoaiPhongDAL
	{
		private static LoaiPhongDAL instance;

		public static LoaiPhongDAL Instance {
			get { if (instance == null) instance = new LoaiPhongDAL(); return LoaiPhongDAL.instance; }
			set { LoaiPhongDAL.instance = value; }
		}
		public LoaiPhongDAL() { }

		public List<LoaiPhong> getDataLoaiPhong() {
			DataTable data = DataProvider.Ins.ExecuteQuery("select * from LOAIPHONG");
			List<LoaiPhong> listlp = new List<LoaiPhong>();
			foreach (DataRow item in data.Rows) {
				LoaiPhong lp = new LoaiPhong(item);
				listlp.Add(lp);
			}
			return listlp;
		}
		public bool KiemTraTenLoaiPhong(LoaiPhong lp) {
			DataTable data =  DataProvider.Ins.ExecuteQuery("USP_CheckTenLP @TenLP", new object[] { lp.Tenloaiphong});
			if (data.Rows.Count == 0)
				return true;
			return false;
		}
		public bool addLoaiPhong(LoaiPhong lp) {
			LoaiPhong_LastRe last = new LoaiPhong_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_LP");
			if (row.Rows.Count == 0)
				last.Malp = "P00";
			else
				last = new LoaiPhong_LastRe(row.Rows[0]);
			string cat = last.Malp.Substring(1, 2);
			int conver1 = int.Parse(cat) + 1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string malp;
			if (lens == 1)
				malp = "P0" + convert2;
			else
				malp = "P" + convert2;


			string query = "USP_AddLoaiPhong @MaLP , @TenLP , @Max , @DG ";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[]{(object)malp, lp.Tenloaiphong, lp.Sokhmax, lp.Dongia}) > 0;
		}
		public bool capnhatLoaiPhong(LoaiPhong lp) {
			string query = "USP_UpdateLP @MaLP , @TenLP , @SN , @DG";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] {lp.Maloaiphong, lp.Tenloaiphong, lp.Sokhmax, lp.Dongia }) > 0;
		}
		public bool xoaLoaiPhong(LoaiPhong lp) {
			string query = " USP_DelLP @MaLP";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { lp.Maloaiphong} ) > 0;
		}
	}
}
