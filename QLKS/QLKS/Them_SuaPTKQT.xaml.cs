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
using QLKS.DataLayer.DAL;

namespace QLKS
{
	/// <summary>
	/// Interaction logic for Them_SuaPTKQT.xaml
	/// </summary>
	public partial class Them_SuaPTKQT : Window
	{
        public delegate void TryenDuLieu(PhuThuKhachQT dv);
        public delegate void SuaDuLieu(PhuThuKhachQT dv);

        public TryenDuLieu truyen;
        public SuaDuLieu sua;

        private string maLKH;
        public Them_SuaPTKQT()
        {
            InitializeComponent();
           
        }
		public Them_SuaPTKQT(PhuThuKhachQT pt) : this()
		{
            txtMaLKH.IsReadOnly = true;
            


            txtTenLK.Text = pt.Tenlkh ;
            txtMaLKH.Text = pt.Maloaikh ;
            txtHSPT.Text = pt.Heso.ToString();
			txbTitle.Text = "Sửa thông tin phụ thu " + pt.Maloaikh ;
			maLKH = pt.Maloaikh .ToString();
		}

		private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                PhuThuKhachQT pt = new PhuThuKhachQT()
                {
                    Tenlkh = txtTenLK.Text,
                    Heso = double.Parse(txtHSPT.Text),
                    Maloaikh = txtMaLKH.Text
                };
                if (sua != null)
                {
                    sua(pt);
                }
            }
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }

		private void btnThem_Click(object sender, RoutedEventArgs e)
		{

			if (!KiemTra())
			{
				return;
			}
			else
			{
                PhuThuKhachQT dichVu = new PhuThuKhachQT()
				{
					Tenlkh = txtTenLK.Text,
					Heso = double.Parse(txtHSPT.Text),
					Maloaikh = txtMaLKH.Text
                };
				if (truyen != null)
				{
					truyen(dichVu);
				}
			}
			Window wd = Window.GetWindow(sender as Button);
			wd.Close();
		}

		private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtTenLK.Text))
            {
                new DialogCustoms("Vui lòng nhập tên loại khách", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHSPT.Text))
            {
                new DialogCustoms("Vui lòng nhập hệ số phụ thu", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                double so;
               
                if (double.TryParse(txtHSPT.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định đạng hệ số phụ thu", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

