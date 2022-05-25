using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class PhongDAL
	{
		private static PhongDAL instance;
		public static int weight = 230;
		public static int height = 80;
		public static PhongDAL Instance
		{
			get { if (instance == null) instance = new PhongDAL(); return PhongDAL.instance; }
			set { PhongDAL.instance = value; }
		}
		private PhongDAL() { 
		
		}
		public List<Phong> LoadPhongList() {
			List<Phong> listphong = new List<Phong>();
			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetTablePhong2");

			foreach (DataRow item in data.Rows)
			{
				Phong phong = new Phong(item);
				listphong.Add(phong);
			}

			return listphong;
		}
		public bool suaTinhTrangPhong(string maphong, string text, out string error) {
			string query = "USP_UPDATE_DONDEP @DonDep , @MaPhong";

			var check = DataProvider.Ins.ExecuteNoneQuery(query, new object[] { text, maphong });
			if (check > 0)
			{
				error = "Cập nhật thành công";
				
				return true;
			}
			else
			{
				error = "Không thể cập nhật";
				return false;
			}
		}
		public List<Phong> getPhong() {
			return LoadPhongList();
		}
		public void xoaThongTinPhong(Phong phong) {
			string query = " USP_DelPhong @MaPhong";
			DataProvider.Ins.ExecuteQuery(query, new object[] { phong.Maphong});
		}
		public List<LoaiPhong> getDataLoaiPhong()
		{
			List<LoaiPhong> listloaiphong = new List<LoaiPhong>();

			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetLoaiPhong");

			foreach (DataRow item in data.Rows)
			{
				LoaiPhong phong = new LoaiPhong(item);
				listloaiphong.Add(phong);
			}

			return listloaiphong;
		}

		public bool addDataPhong(Phong phong) {
			string maphong = phong.Maphong.ToString();
			string tenphong = maphong;
			string maloaiphong = phong.Tenloaiphong;
			string dondep = phong.Tinhtrang;
			string tinhtrang = "Phòng trống";
			string checkquery = "USP_CHECK_EXIST @MaPhong ";
			DataTable data = DataProvider.Ins.ExecuteQuery(checkquery, new object[] { maphong });
			if (data.Rows.Count>0)
				return false;
			string query = "USP_InsertPhong @MaPhong , @TenPhong , @MaLoaiP , @Dondep , @TinhTrang";
			return  DataProvider.Ins.ExecuteNoneQuery(query, new object[] {maphong, tenphong, maloaiphong, dondep, tinhtrang })>0;
			
		}
		public List<PhongTrong> getPhongTrong(DateTime? ngaybd, DateTime? ngaykt) {
			List<PhongTrong> list = new List<PhongTrong>();
			string query = "USP_GetPhongTheoNgay @NgayBD , @NgayKT ";
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] {ngaybd, ngaykt });
			foreach (DataRow item in data.Rows)
			{
				PhongTrong p = new PhongTrong(item);
				list.Add(p);
			}
			return list;
		}
		public Double layGiaTienTheoMaPhong(Phong phong) {
			string query = " USP_GetDonGiaPhong @MaP";
			var s= DataProvider.Ins.ExecuteScalar(query, new object[] { phong.Maphong});
			
			return Double.Parse(s.ToString());
		}

		public int laygiatientheomaphong(string maphong, int isDay) {
			var s = DataProvider.Ins.ExecuteScalar("USP_GetTienPhong @MaPhong", new object[] { (object)maphong });
			return (int)s;
		}
	}
}
