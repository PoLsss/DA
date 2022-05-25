using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;

namespace QLKS.DataLayer.BUS
{
	public class CT_PhieuThueBUS
	{
        private static CT_PhieuThueBUS instance;

		public static CT_PhieuThueBUS Instance {
            get { if (instance == null) instance = new CT_PhieuThueBUS(); return CT_PhieuThueBUS.instance; }
            set { CT_PhieuThueBUS.instance = value; }
        }

        private CT_PhieuThueBUS() { }




		public bool addCTPhieuThue(PhieuThue ctpt)
		{
			return CT_PhieuThueDAL.Instance.addCTPhieuThue(ctpt);
		}
		public List<CT_PhieuThue> getCTPhieuThueTheoMaPT(string maCTPT)
        {
            return CT_PhieuThueDAL.Instance.getPhieuThueTheoMaPT(maCTPT);
        }

		public bool suaTinhTrangThuePhong(string  maphong ,string tinhtrangthuephong)
		{
			return CT_PhieuThueDAL.Instance.suaTinhTrangThuePhong(maphong, tinhtrangthuephong);
		}

		public bool suaTinhTrangTraPhong(string maphong, string tinhtrang, string dondep) {
			return CT_PhieuThueDAL.Instance.suaTinhTrangTraPhong(maphong, tinhtrang, dondep);
		}

	}
}
