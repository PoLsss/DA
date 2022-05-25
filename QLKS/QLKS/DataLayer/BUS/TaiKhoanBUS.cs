using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DataLayer.DAL;

namespace QLKS.DataLayer.BUS
{

	public class TaiKhoanBUS
    {
        private static TaiKhoanBUS Instance;

        private TaiKhoanBUS()
        {

        }

        public static TaiKhoanBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TaiKhoanBUS();
            }
            return Instance;
        }
		public TaiKhoan kiemTraTKTonTaiKhong(string username, string pass)
		{
			//TaiKhoanDAL.Instance.GetType();
			return TaiKhoanDAL.Instance.layTaiKhoanTuDataBase(username, pass);

		}
		//public bool capNhatAvatar(string username,string avatar, out string error)
		//{
		//    return TaiKhoanDAL.GetInstance().capNhatAvatar( username , avatar, out error);
		//}
	}
}

