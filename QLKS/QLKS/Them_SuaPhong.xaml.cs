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
	/// Interaction logic for Them_SuaPhong.xaml
	/// </summary>
	public partial class Them_SuaPhong : Window
	{
        public delegate void TryenDuLieu(Phong p);
        public delegate void SuaDuLieu(Phong p);

        public TryenDuLieu truyen;
        public SuaDuLieu sua;
        List<LoaiPhong> LP;
        private string Maphong;

        public Them_SuaPhong()
        {
            InitializeComponent();
            LP = new List<LoaiPhong>(PhongBUS.Instance.getDataLoaiPhong());
            cmbLoaiPhong.ItemsSource = LP;
            cmbLoaiPhong.DisplayMemberPath = "Tenloaiphong";
            cmbLoaiPhong.SelectedValuePath = "Maloaiphong";
        }

        public Them_SuaPhong(Phong phong) : this()
        {
            cmbLoaiPhong.DisplayMemberPath = "Tenloaiphong";
            cmbLoaiPhong.SelectedValuePath = "Maloaiphong";

            txtSoPhong.IsReadOnly = true;
            txtSoPhong.Text = phong.Maphong;
            cmbTinhTrang.Text = phong.Tinhtrang;
            cmbLoaiPhong.Text = phong.Tenloaiphong;
            
            txbTitle.Text = "Sửa thông tin phòng " + phong.Maphong;
            Maphong = phong.Maphong;
        }

        #region Method
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                new DialogCustoms("Vui lòng nhập số phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbLoaiPhong.Text))
            {
                new DialogCustoms("Vui lòng chọn loại phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbTinhTrang.Text))
            {
                new DialogCustoms("Vui lòng chọn tình trạng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                if (int.TryParse(txtSoPhong.Text, out so) == true || KiemTraTenPhong() == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng số phòng ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
            }
            return true;
        }

        public bool KiemTraTenPhong()
        {
            string str = txtSoPhong.Text;
            int so;
            if (str[0].Equals('P') && int.TryParse(str[1].ToString(), out so) && int.TryParse(str[2].ToString(), out so) && int.TryParse(str[3].ToString(), out so))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Event
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

		private void btnThem_Click(object sender, RoutedEventArgs e)
		{
			if (!KiemTra())
			{
				return;
			}
			else
			{
				Phong phong = new Phong()
				{
					Maphong = txtSoPhong.Text,
					Tinhtrang = cmbTinhTrang.Text,
					Tenloaiphong = cmbLoaiPhong.SelectedValue.ToString(),
                    
                };
			if (truyen != null)
			{
				truyen(phong);
			}
		}
		Window wd = Window.GetWindow(sender as Button);
		wd.Close();

        }

	//private void btnCapNhat_Click(object sender, RoutedEventArgs e)
	//{
	//    if (!KiemTra())
	//    {
	//        return;
	//    }
	//    else
	//    {
	//        Phong phong = new Phong()
	//        {
	//            Maphong = txtSoPhong.Text,
	//            Tinhtrang = cmbTinhTrang.Text,
	//            Tenloaiphong = cmbLoaiPhong.SelectedValue.ToString(),
	//            
	//        };
	//        if (sua != null)
	//        {
	//            sua(phong);
	//        }
	//    }
	//    Window wd = Window.GetWindow(sender as Button);
	//    wd.Close();
	//}
	#endregion
}
}
