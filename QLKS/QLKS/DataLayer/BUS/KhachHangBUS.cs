using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;

namespace QLKS.DataLayer.BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

		public static KhachHangBUS Instance {
            get { if (instance == null) instance = new KhachHangBUS(); return KhachHangBUS.instance; }
            set { KhachHangBUS.instance = value; }
        }

		private KhachHangBUS()
        {

        }



		public List<KhachHang> GetKhachHangs()
		{
			return KhachHangDAL.Instance.getDataKH();
		}

		public KhachHang addKhachHang(KhachHang kh)
		{
			return KhachHangDAL.Instance.addKhachHang( kh);
		}

		////kiểm tra khách hàng đã tồn tại chưa dựa vào SDT nếu rồi thì trả ra KhachHang nếu chưa thì trả ra null
		public string kiemTraTonTaiKhachHang(string sdt)
		{
			KhachHang kh = KhachHangDAL.Instance.kiemTraTonTaiKhachHang(sdt);
			if (kh != null)
			{
				return kh.Makh.ToString();
			}
			else
			{
				return "Khong_tim_thay";
			}
		}

		public bool capNhatDataKhachHang(KhachHang khachHang)
		{
			return KhachHangDAL.Instance.capnhatKhachHang(khachHang);
		}

		public bool xoaDataKhachHang(KhachHang khachHang)
		{
			return KhachHangDAL.Instance.xoaKhachHang(khachHang);
		}

		public string layTenKhachHangTheoMaPT(string maPhieuThue)
		{
			return KhachHangDAL.Instance.layTenKhachHangTheoMaPT(maPhieuThue);
		}
	}
}
