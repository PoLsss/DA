using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using QLKS.DataLayer;
using QLKS.UserControls;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region uc_view
        private UserControlHome Home;
        private UserControl_Phong Phong_UC;
        private UserControl_PhieuThue ThuePhong_UC;
        //private uc_NhanVien NhanVien_UC;
        private UserControl_QLPhong QuanLyPhong_UC;
        private UserContro_QLKhachHang QuanLyKhachHang_UC;
        private UserControl_QLLoaiPhong QuanLyLoaiPhong_UC;
        private UserControl_PhuThu QuanLyPhuThu_UC;
        //private uc_QuanLyTienNghi QuanLyTienNghi_UC;
        //private uc_QuanLyChiTietTienNghi QuanLyChiTietTienNghi_UC;
        //private uc_QuanLyLoaiDichVu QuanLyLoaiDichVu_UC;
        private UserControl_HoaDon HoaDon_UC;
        private UserControl_ThongKe ThongKe_UC;
        #endregion
        #region Khai báo biến
        public List<ItemMenuMainWindow> listMenu { get; set; }
        private string title_Main;
        private int minHeight_ucControlbar;
        private int maNV;
        private int capDoQuyen;

		public MainWindow()
		{
			InitializeComponent();


		}
		public string Title_Main
        {
            get => title_Main;
            set
            {
                title_Main = value;
                OnPropertyChanged("Title_Main");
            }
        }
        public int MinHeight_ucControlbar
        {
            get => minHeight_ucControlbar;
            set
            {
                minHeight_ucControlbar = value;
                OnPropertyChanged("MinHeight_ucControlbar");
                if (value == 1)
                {
                    boGoc.Rect = new Rect(0, 0, SystemParameters.MaximizedPrimaryScreenWidth, SystemParameters.MaximizedPrimaryScreenHeight);
                }
                else
                {
                    boGoc.Rect = new Rect(0, 0, 1300, 700);
                }
            }
        }
		public int CapDoQuyen { get => capDoQuyen; set => capDoQuyen = value; }
		public int MaNV { get => maNV; set => maNV = value; }
		#endregion

		TaiKhoan taiKhoan;


		public MainWindow(TaiKhoan tk) : this()
		{
			this.taiKhoan = tk;
			this.CapDoQuyen = tk.CapDoQuyen;
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
		}
		#region method
		public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
        private void initListViewMenu()
        {
            listMenu = new List<ItemMenuMainWindow>();
            //Khoi tao Menu
            if (CapDoQuyen == 1)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt Phòng", foreColor = "Green", kind_Icon = "BookAccount" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL khách hàng", foreColor = "#FFD41515", kind_Icon = "Account" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL loại phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL phụ thu", foreColor = "Blue", kind_Icon = "FaceAgent" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Thống kê", foreColor = "#FF0069C1", kind_Icon = "ChartAreaspline" });
			}
			else if (CapDoQuyen == 2)
			{
				listMenu.Add(new ItemMenuMainWindow() { name = "Trang chủ", foreColor = "gray", kind_Icon = "home" });
				listMenu.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#fff08033", kind_Icon = "homecity" });
				listMenu.Add(new ItemMenuMainWindow() { name = "Đặt phòng", foreColor = "green", kind_Icon = "bookaccount" });
				listMenu.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#ffd41515", kind_Icon = "receipt" });
			}

			lisviewMenu.ItemsSource = listMenu;
            lisviewMenu.SelectedValuePath = "name";
            Title_Main = "Trang Chủ";
        }
		#endregion

		#region event

		private void load_Windows(object sender, RoutedEventArgs e)
		{
			this.DataContext = this;
			Home = new UserControlHome();
			contenDisplayMain.Content = Home;
			initListViewMenu();


		

		}

		private void lisviewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (lisviewMenu.SelectedValue != null)
			{
				switch (lisviewMenu.SelectedIndex)
				{
					case 0:
						if (Title_Main.Equals(lisviewMenu.SelectedValue.ToString()))
						{
							break;
						}
						contenDisplayMain.Content = Home;
						break;
					case 1:
						//if (Phong_UC == null)
						//{
							Phong_UC = new UserControl_Phong();
						//}
						contenDisplayMain.Content = Phong_UC;
					
						break;
					case 2:
						if (ThuePhong_UC == null)
						{
							ThuePhong_UC = new UserControl_PhieuThue();
						}
						contenDisplayMain.Content = ThuePhong_UC;
						break;
					case 3:
						if (HoaDon_UC == null)
						{
							HoaDon_UC = new UserControl_HoaDon();
						}
						contenDisplayMain.Content = HoaDon_UC;
						break;
					
					case 4:
						if (QuanLyKhachHang_UC == null)
						{
							QuanLyKhachHang_UC = new UserContro_QLKhachHang();
						}
						contenDisplayMain.Content = QuanLyKhachHang_UC;
						break;
					case 5:
						if (QuanLyPhong_UC == null)
						{
							QuanLyPhong_UC = new UserControl_QLPhong();
						}
						contenDisplayMain.Content = QuanLyPhong_UC;
						break;
					case 6:
						if (QuanLyLoaiPhong_UC == null)
						{
							QuanLyLoaiPhong_UC = new UserControl_QLLoaiPhong();
						}
						contenDisplayMain.Content = QuanLyLoaiPhong_UC;
						break;
					case 7:
						if (QuanLyPhuThu_UC == null)
						{
							QuanLyPhuThu_UC = new UserControl_PhuThu();
						}
						contenDisplayMain.Content = QuanLyPhuThu_UC;
						break;
					case 8:
						//if (ThongKe_UC == null)
						//{
							ThongKe_UC = new UserControl_ThongKe();
						//}
						contenDisplayMain.Content = ThongKe_UC;
						break;
				}
						Title_Main = lisviewMenu.SelectedValue.ToString();
						btnCloseLVMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
			
			}
		}
		#endregion



		private void btnDangXuat_Click(object sender, RoutedEventArgs e)
		{

			DialogCustoms dialog = new DialogCustoms("Bạn có muốn đăng xuất ?", "Thông báo", DialogCustoms.YesNo);
			
			if (dialog.ShowDialog() == true)
			{
				new DangNhap().Show();
				this.Close();
			}

		}
	}


    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }

        public ItemMenuMainWindow() { }

    }
}
