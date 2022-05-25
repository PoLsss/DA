using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;
using QLKS.Model;

namespace QLKS.DataLayer.BUS
{
	public class PhongBUS
	{
		private static PhongBUS instance;

		private PhongBUS() { }

		public static PhongBUS Instance
		{
			get { if (instance == null) instance = new PhongBUS(); return PhongBUS.instance; }
			set { PhongBUS.instance = value; }
		}




		public List<Phong> getDataPhongTheoNgay()
		{
			return PhongDAL.Instance.LoadPhongList();
		}

		public List<PhongTrong> getPhongTrong(DateTime? ngaybd, DateTime? ngaykt)
		{
			return PhongDAL.Instance.getPhongTrong(ngaybd, ngaykt);
		}
		public  Double tinhTienPhong(Phong phong)
		{
			Double tienPhong;
			tienPhong = PhongDAL.Instance.layGiaTienTheoMaPhong(phong);
			//if (tenloaikh == "Nước ngoài")
			//	return (phong.Songay * tienPhong * phuthuquoctich);
			//else {
			//	return (phong.Songay*tienPhong + phong.Songay*tienPhong*phuthunguoio);
			//}
			return (tienPhong * phong.Songay);
		}
		public Double tinhTongTien(Phong phong, Double ptquoctich, Double ptnguoio, Double tienphong  ) {
			if (phong.Tenloaikh == "Nước ngoài")
				return (tienphong * ptquoctich);
			else {
				return ( tienphong *(1+ ptnguoio));
			}
		}
		public Double layTienPhongTheoSoPhong(Phong phong)
		{
			return PhongDAL.Instance.layGiaTienTheoMaPhong(phong);
		}

		public bool suaTinhTrangDonDep(string maPhong, string text ,out string  error)
		{
			return PhongDAL.Instance.suaTinhTrangPhong(maPhong, text, out error);
		}

		public List<Phong> getDataPhong()
		{
			return PhongDAL.Instance.getPhong();
		}

		public bool addDataPhong(Phong phong)
		{
			return PhongDAL.Instance.addDataPhong(phong);
		}

		//public bool capNhatDataPhong(Phong phong)
		//{
		//	return PhongDAL.Instance.capNhatPhong(phong);
		//}

		public void xoaDataPhong(Phong phong)
		{
			PhongDAL.Instance.xoaThongTinPhong(phong);
		}

		public int layTienPhongTheoMaPhong(string maphong, int isday)
		{
			return PhongDAL.Instance.laygiatientheomaphong(maphong, isday);
		}

		public List<LoaiPhong> getDataLoaiPhong()
		{
			return PhongDAL.Instance.getDataLoaiPhong();
		}
	}
}

