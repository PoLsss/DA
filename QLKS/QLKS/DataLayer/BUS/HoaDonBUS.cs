using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;

namespace QLKS.DataLayer.BUS
{
	class HoaDonBUS
	{
		private static HoaDonBUS instance;

		internal static HoaDonBUS Instance
		{
			get { if (instance == null) instance = new HoaDonBUS(); return HoaDonBUS.instance; }
			set { HoaDonBUS.instance = value; }
		}

		private HoaDonBUS() { }



		public List<HoaDon> GetHoaDons()
		{
			return HoaDonDAL.Instance.LayDuLieuHoaDon();
		}
		public HoaDon themHoaDon(HoaDon hd, string maphieu)
		{
			return HoaDonDAL.Instance.themHoaDon(hd, maphieu);
		}

		public HoaDonX layHoaDonTheoMaHoaDon(string mahd, DateTime checkout)
		{
			return HoaDonDAL.Instance.layHoaDonTheoMaHoaDon(mahd, checkout);
		}
		public Double GetTyLePhuThuNguuoiO(int songuoi) {
			return HoaDonDAL.Instance.GetTyLePhuThuNguuoiO(songuoi);
		}
	}
}
