using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class HoaDonDAL
	{
		private static HoaDonDAL instance;

		public static HoaDonDAL Instance {
			get { if (instance == null) instance = new HoaDonDAL(); return HoaDonDAL.instance; }
			set { HoaDonDAL.instance = value; }
		}
		public HoaDonX layHoaDonTheoMaHoaDon(string mahd, DateTime checkout) {
			string query = " USP_GetHDTheoMaHD @MaHD , @CheckOut";
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] {(object)mahd , (object)checkout});
			HoaDonX hd = new HoaDonX(data.Rows[0]);
			return hd;
		}
		//public HoaDon themHoaDon(HoaDon hd)
		//{
		//	HoaDon_LastRe last = new HoaDon_LastRe();
		//	DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_MaHD");
		//	if (row.Rows.Count == 0)
		//		last.Mahd = "HD000";
		//	else
		//		last = new HoaDon_LastRe(row.Rows[0]);
		//	string cat = last.Mahd.Substring(2, 3);
		//	int conver1 = int.Parse(cat) + 1;
		//	string convert2 = conver1.ToString();
		//	int lens = convert2.Length;
		//	string mahd;
		//	if (lens == 1)
		//		mahd = "HD00" + convert2;
		//	else if (lens == 2)
		//		mahd = "HD0" + convert2;
		//	else mahd = "HD" + convert2;

		//	CTHD_LastRe lastct = new CTHD_LastRe();
		//	DataTable row_ = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_MaCTHD");
		//	if (row_.Rows.Count == 0)
		//		lastct.Cthd = "HD000";
		//	else
		//		lastct = new CTHD_LastRe(row_.Rows[0]);
		//	string cat_ = lastct.Cthd.Substring(2, 3);
		//	int conver1_ = int.Parse(cat) + 1;
		//	string convert2_ = conver1_.ToString();
		//	int lens_ = convert2_.Length;
		//	string macthd;
		//	if (lens_ == 1)
		//		macthd = "CT00" + convert2_;
		//	else if (lens_ == 2)
		//		macthd = "CT0" + convert2_;
		//	else macthd = "CT" + convert2_;

		//	string query = "USP_AddHoaDon @MaHD , @CheckOut , @ST , @TongTien , @MaCTHD , @MaCTPT , @Count";
		//	DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] { (object)mahd, hd.Checkout, 1, hd.Tongtien, (object)macthd, hd.Mactpt, 1  });
		//	hd = new HoaDon(data.Rows[0]);
		//	return hd;
		//}
		public HoaDon themHoaDon(HoaDon hd, string maphieu)
		{
			HoaDon_LastRe last = new HoaDon_LastRe();
			DataTable row = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_MaHD");
			if (row.Rows.Count == 0)
				last.Mahd = "HD000";
			else
				last = new HoaDon_LastRe(row.Rows[0]);
			string cat = last.Mahd.Substring(2, 3);
			int conver1 = int.Parse(cat) + 1;
			string convert2 = conver1.ToString();
			int lens = convert2.Length;
			string mahd;
			if (lens == 1)
				mahd = "HD00" + convert2;
			else if (lens == 2)
				mahd = "HD0" + convert2;
			else mahd = "HD" + convert2;

			CTHD_LastRe lastct = new CTHD_LastRe();
			DataTable row_ = DataProvider.Ins.ExecuteQuery("USP_GetNewRe_MaCTHD");
			if (row_.Rows.Count == 0)
				lastct.Cthd = "HD000";
			else
				lastct = new CTHD_LastRe(row_.Rows[0]);
			string cat_ = lastct.Cthd.Substring(2, 3);
			int conver1_ = int.Parse(cat) + 1;
			string convert2_ = conver1_.ToString();
			int lens_ = convert2_.Length;
			string macthd;
			if (lens_ == 1)
				macthd = "CT00" + convert2_;
			else if (lens_ == 2)
				macthd = "CT0" + convert2_;
			else macthd = "CT" + convert2_;

			string query = "USP_AddHoaDonUP @MaHD , @CheckOut , @ST , @TongTien , @MaCTHD , @MaCTPT , @Count , @MaPhieu";
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] { (object)mahd, hd.Checkout, 1, hd.Tongtien, (object)macthd, hd.Mactpt, 1, (object)maphieu });
			hd = new HoaDon(data.Rows[0]);
			return hd;
		}
		public List<HoaDon> LayDuLieuHoaDon() {
			List<HoaDon> listhd = new List<HoaDon>();
			DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetHD");
			foreach (DataRow item in data.Rows)
			{
				HoaDon hd = new HoaDon(item);
				listhd.Add(hd);
			}
			return listhd;
		}
		public Double GetTyLePhuThuNguuoiO(int songuoi) {
			string query = "USP_GetTyLePhuThuKhach @SoKhach";
			return (Double)DataProvider.Ins.ExecuteScalar(query, new object[] { (object)songuoi});
		}
	}
}

