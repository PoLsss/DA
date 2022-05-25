using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
	public class Phong_CustomDAL
	{
		private static Phong_CustomDAL instance;

		public static Phong_CustomDAL Instance {
			get { if (instance == null) instance = new Phong_CustomDAL(); return Phong_CustomDAL.instance; }
			set { Phong_CustomDAL.instance = value; }
		}
		private Phong_CustomDAL() { }


	//	public List<Phong_Custom> LoadPhongList()
	//	{
	//		List< Phong_Custom > phonglist = new List<Phong_Custom>();
	//		DataTable data = DataProvider.Ins.ExecuteQuery("USP_GetTablePhong");
	//		foreach (DataRow item in data.Rows) {
	//			Phong_Custom phong = new Phong_Custom(item);
	//			phonglist.Add(phong);
	//		}
	//		return phonglist;
	//	}
	}
		
	
}
