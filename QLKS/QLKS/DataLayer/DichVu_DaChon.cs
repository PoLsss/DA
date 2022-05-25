using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class DichVu_DaChon
	{
		private int soLuong;
		private string tenDV;
		private Double gia;
		private Double thanhTien;
		public DichVu_DaChon() { }

		public int SoLuong { get => soLuong; set => soLuong = value; }
		public string TenDV { get => tenDV; set => tenDV = value; }
		public Double ThanhTien { get => thanhTien; set => thanhTien = value; }
		public double Gia { get => gia; set => gia = value; }
	}
}
