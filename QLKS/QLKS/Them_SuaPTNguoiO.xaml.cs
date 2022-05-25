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

namespace QLKS
{
	/// <summary>
	/// Interaction logic for Them_SuaPTNguoiO.xaml
	/// </summary>
	public partial class Them_SuaPTNguoiO : Window
	{
        public delegate void truyenData(PhuThu pt);
        public delegate void suaData(PhuThu pt);


        public truyenData truyenPTNgO;
        public suaData sua;
        private string mapt;
        public Them_SuaPTNguoiO()
        {
            InitializeComponent();
        }

        public Them_SuaPTNguoiO(PhuThu pt) : this()
        {
            txtMaPT.IsReadOnly = true;
            txtMaPT.Text = pt.Maphuthu.ToString();
            txtSoNguoi.Text = pt.Sokh.ToString();
            txtTenPhuThu.Text = pt.Tenpt;
            txtTyLe.Text = pt.Tylept.ToString();
            txbTitle.Text = "Sửa thông tin phụ thu " + pt.Maphuthu.ToString();
        }

        #region Method
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtTenPhuThu.Text))
            {
                new DialogCustoms("Vui lòng nhập tên phụ thu", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTyLe.Text))
            {
                new DialogCustoms("Vui lòng nhập tỷ lệ phụ thu", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoNguoi.Text))
            {
                new DialogCustoms("Vui lòng nhập số người ở", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                double ss;
                if (int.TryParse(txtTenPhuThu.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên phụ thu", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (double.TryParse(txtTyLe.Text, out ss) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tỷ lệ phụ thu", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(txtSoNguoi.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng số người", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

        #region Event
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
                PhuThu pt = new PhuThu()
                {
                    Maphuthu = int.Parse(txtMaPT.Text),
                    Tenpt = txtTenPhuThu.Text,
                    Sokh = int.Parse(txtSoNguoi.Text),
                    Tylept = double.Parse(txtTyLe.Text)
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
                PhuThu pt = new PhuThu()
                {
                    Maphuthu = int.Parse(txtMaPT.Text),
                    Tenpt = txtTenPhuThu.Text,
                    Sokh = int.Parse(txtSoNguoi.Text),
                    Tylept = double.Parse(txtTyLe.Text)
                };
                if (truyenPTNgO != null)
                {
                    truyenPTNgO(pt);
                }
            }
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
        #endregion

    }
}
