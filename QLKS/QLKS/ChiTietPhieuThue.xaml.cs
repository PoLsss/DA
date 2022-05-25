using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QLKS.DataLayer;
using QLKS.DataLayer.BUS;

namespace QLKS
{
	/// <summary>
	/// Interaction logic for ChiTietPhieuThue.xaml
	/// </summary>
	public partial class ChiTietPhieuThue : Window
    {
        List<CT_PhieuThue> lsCTPT;
        public ChiTietPhieuThue()
        {
            InitializeComponent();
        }
        public ChiTietPhieuThue(PhieuThue ptct) : this()
        {
            txblTenKH.Text = ptct.Tenkh;
            txblNgayLapHD.Text = ptct.Ngaylap.ToString();
            txblTenNV.Text = ptct.Tennv;
            txblTieuDe.Text += ptct.Mactphieu.ToString();
            lsCTPT = new List<CT_PhieuThue>();
            lsCTPT = CT_PhieuThueBUS.Instance.getCTPhieuThueTheoMaPT(ptct.Mactphieu);
            lvCTPT.ItemsSource = lsCTPT;
        }

        private void click_Thoat(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}