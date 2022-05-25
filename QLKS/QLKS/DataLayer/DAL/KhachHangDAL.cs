using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class KhachHangDAL
	{
		private static KhachHangDAL instance;

		public static KhachHangDAL Instance {
			get { if (instance == null) instance = new KhachHangDAL(); return KhachHangDAL.instance; }
			set { KhachHangDAL.instance = value; }
		}

		public KhachHang kiemTraTonTaiKhachHang(string sdt) {
			string query = "USP_GetKHTheo_SDT @SDT";
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] {sdt });
			if (data.Rows.Count >0)
			{
				KhachHang kh = new KhachHang(data.Rows[0]);
				return kh;
			}
			return null;
		}
		public KhachHang addKhachHang( KhachHang kh)
		{
			string query = "USP_INSERT_KH @MaKH , @TenKH , @MaLKKH , @CMND , @SDT , @DiaChi , @QT , @GioiTinh";
			string loaikh = "LKH01";
			if (kh.Quoctich.ToString() != "Việt Nam")
				loaikh = "LKH02";
			KhachHang_LastRe getlast = new KhachHang_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRe");
			if (row.Rows.Count == 0)
				getlast.Makh = "KH000";
			else
				getlast = new KhachHang_LastRe(row.Rows[0]);
			string cat = getlast.Makh.Substring(2, 3);
			int conver1 = int.Parse(cat)+1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string makh;
			if (lens == 1)
				makh = "KH00" + convert2;
			else if (lens == 2)
				makh = "KH0" + convert2;
			else makh = "KH" + convert2;
			DataTable data =  DataProvider.Ins.ExecuteQuery(query, new object[] {(object)makh, kh.Tenkh, (object)loaikh, kh.Cmnd, kh.Sdt, kh.Diachi, kh.Quoctich, kh.Gioitinh }) ;
			kh = new KhachHang(data.Rows[0]);
			return kh;
			
		}
		public List<KhachHang> getDataKH() {
			List<KhachHang> listkh = new List<KhachHang>();
			DataTable data = DataProvider.Ins.ExecuteQuery("select * from KHACHHANG");
			foreach (DataRow item in data.Rows)
			{
				KhachHang kh = new KhachHang(item);
				listkh.Add(kh);
			}
			return listkh;
		}

		public bool capnhatKhachHang(KhachHang kh) {
			string query = "USP_UpdateKH @MaKH , @TenKH , @CMND , @SDT , @DiaChi , @QT , @GTinh ";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] {kh.Makh, kh.Tenkh, kh.Cmnd, kh.Sdt, kh.Diachi, kh.Quoctich, kh.Gioitinh }) > 0;
		}
		public bool xoaKhachHang(KhachHang kh) {
			string query = "SP_DelKH @MaKH";
			return DataProvider.Ins.ExecuteNoneQuery(query, new object[] { kh.Makh}) > 0;
		}
		public string layTenKhachHangTheoMaPT(string maphieu) {
			var name = DataProvider.Ins.ExecuteScalar("USP_GetNameKHTheoMaPhieu @MaPhieu", new object[] { (object)maphieu });
			return (string)name;
		}
	}
}
