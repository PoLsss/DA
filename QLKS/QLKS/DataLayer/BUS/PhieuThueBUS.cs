using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;

namespace QLKS.DataLayer.BUS
{
    public class PhieuThueBUS
    {

        private static PhieuThueBUS instance;

        private PhieuThueBUS()
        {

        }

		public static PhieuThueBUS Instance {
            get { if (instance == null) instance = new PhieuThueBUS(); return PhieuThueBUS.instance; }
            set { PhieuThueBUS.instance = value; }
        }


		public CTPT_DP addPhieuThue(CTPT_DP pt)
		{
			return PhieuThueDAL.Instance.addPhieuThue(pt);
		}

		public List<PhieuThue> getDataPhieuThue()
		{
			return PhieuThueDAL.Instance.getDataFromDB();
		}

		public bool xoaPhieuThueTheoMaPhieuThue(string maCTPhieuThue)
		{
			return PhieuThueDAL.Instance.xoaPhieuThueTheoMaPhieuThue(maCTPhieuThue);
		}
		public PhieuThue_LastRe getNewRecord() {
			return PhieuThueDAL.Instance.getNewRecord();
		}
	}
}
