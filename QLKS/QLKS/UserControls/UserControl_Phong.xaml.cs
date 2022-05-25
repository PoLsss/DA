using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using QLKS.DataLayer;
using QLKS.DataLayer.BUS;
using QLKS.DataLayer.DAL;
using QLKS.Model;

namespace QLKS
{
	/// <summary>
	/// Interaction logic for UserControl_Phong.xaml
	/// </summary>
	public partial class UserControl_Phong : UserControl
	{
		#region Khai bao bien
		List<Phong> lsPhong;
		ObservableCollection<Phong> lsPhongA;
		ObservableCollection<Phong> lsPhongB;
		ObservableCollection<Phong> lsPhongC;
		ObservableCollection<Phong> lsTrong;
		#endregion

		private int maNV;
		public int MaNV { get => maNV; set => maNV = value; }
		public UserControl_Phong( )
		{
			InitializeComponent();
			capNhatLaiDuLieuListViewTheoNgayGio();
			LoadPhong();
			Load_time();
			lsTrong = new ObservableCollection<Phong>();
			initEvent();
		}
		#region Method
		void LoadPhong() {
			List<Phong> phonglist = PhongDAL.Instance.LoadPhongList();
			lsPhong = new List<Phong>();
			lsPhongA = new ObservableCollection<Phong>();
			lsPhongB = new ObservableCollection<Phong>();
			lsPhongC = new ObservableCollection<Phong>();
			foreach (Phong item in  phonglist) {
				if (item.Tenloaiphong.Equals("Phòng A"))
				{
					lsPhongA.Add(item);
				}
				else if (item.Tenloaiphong.Equals("Phòng B"))
				{
					lsPhongB.Add(item);
				}
				else
				{
					lsPhongC.Add(item);
				}
			}
			lvPhongA.ItemsSource = lsPhongA;
			lvPhongB.ItemsSource = lsPhongB;
			lvPhongC.ItemsSource = lsPhongC;
			rdTatCa.IsChecked = true;
			rdTatCaLoaiPhong.IsChecked = true;
			rdTatCaPhong.IsChecked = true;
		}
		private void Load_time(){
			DispatcherTimer time = new DispatcherTimer();
			time.Tick += new EventHandler(ucPhong_Loaded);
			time.Interval = new TimeSpan(0,0,1);
			time.Start();
		}
		private List<Phong> filterPhongTheoLoai(string loai)
		{
			return lsPhong.Where(p => p.Tenloaiphong.Equals(loai)).ToList();
		}
		private void refeshLoaiPhong()
		{
			lsPhongA = new ObservableCollection<Phong>(filterPhongTheoLoai("Phòng A"));
			lsPhongB = new ObservableCollection<Phong>(filterPhongTheoLoai("Phòng B"));
			lsPhongC = new ObservableCollection<Phong>(filterPhongTheoLoai("Phòng C"));
			lvPhongA.ItemsSource = lsPhongA;
			lvPhongB.ItemsSource = lsPhongB;
			lvPhongC.ItemsSource = lsPhongC;
		}

		private void initEvent()
		{
			//Khởi tạo sự kiện cho listView
			lvPhongA.PreviewMouseLeftButtonUp += LvPhongALL_PreviewMouseLeftButtonUp;
			lvPhongB.PreviewMouseLeftButtonUp += LvPhongALL_PreviewMouseLeftButtonUp;
			lvPhongC.PreviewMouseLeftButtonUp += LvPhongALL_PreviewMouseLeftButtonUp;

			//Khởi tạo sự kiện click cho RadioButton
			rdPhongTrong.Click += rb_Click;
			rdPhongDaDat.Click += rb_Click;
			rdPhongDangThue.Click += rb_Click;
			rdPhongDon.Click += rb_Click;
			rdPhongDoi.Click += rb_Click;
			rdPhongGiaDinh.Click += rb_Click;
			rdDaDonDep.Click += rb_Click;
			rdChuaDonDep.Click += rb_Click;
			rdSuaChua.Click += rb_Click;
			rdTatCaPhong.Click += rb_Click;
			rdTatCaLoaiPhong.Click += rb_Click;
			rdTatCa.Click += rb_Click;
		}

		private bool PhongFilter(object obj)
		{
			Phong ph = obj as Phong;
			RadioButton radioTinhTrang = null;
			RadioButton radioDonDep = null;

			foreach (RadioButton i in spTrangThai.Children)
			{
				if (i.IsChecked.Value == true)
				{
					radioTinhTrang = i;
				}
			}
			foreach (RadioButton j in spDonDep.Children)
			{
				if (j.IsChecked.Value == true)
				{
					radioDonDep = j;
				}
			}
			if (radioDonDep != null && radioTinhTrang != null)
			{
				if (radioDonDep.Content.ToString().Equals("Tất cả") && radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
				{
					return true;
				}
				else if (radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
				{
					return ph.Dondep.Equals(radioDonDep.Content.ToString());
				}
				else if (radioDonDep.Content.ToString().Equals("Tất cả"))
				{
					return ph.Tinhtrang.Equals(radioTinhTrang.Content.ToString());
				}
				else
				{
					return ph.Tinhtrang.Equals(radioTinhTrang.Content.ToString()) && ph.Dondep.Equals(radioDonDep.Content.ToString());
				}
			}
			else if (radioDonDep != null)
			{
				if (radioDonDep.Content.ToString().Equals("Tất cả"))
					return true;
				else
					return ph.Dondep.Equals(radioDonDep.Content.ToString());
			}
			else if (radioTinhTrang != null)
			{
				if (radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
					return true;
				else
					return ph.Tinhtrang.Equals(radioTinhTrang.Content.ToString());
			}
			return true;
		}

		private void timKiemTheomaPhong()
		{
			CollectionView viewPhongA = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongA.ItemsSource);
			viewPhongA.Filter = filterTimKiem;
			CollectionView viewPhongB = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongB.ItemsSource);
			viewPhongB.Filter = filterTimKiem;
			CollectionView viewPhongC = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongC.ItemsSource);
			viewPhongC.Filter = filterTimKiem;
			refreshListView();
		}

		private bool filterTimKiem(object obj)
		{
			if (String.IsNullOrEmpty(txbTimKiem.Text))
				return true;
			else
				return (obj as Phong).Maphong.Contains(txbTimKiem.Text);
		}

		private void checkLoaiPhong(RadioButton rd)
		{
			if (rd.Content.Equals("Phòng loại A"))
			{
				lvPhongA.ItemsSource = lsPhongA;
				lvPhongB.ItemsSource = lsTrong;
				lvPhongC.ItemsSource = lsTrong;
				refreshListView();
			}
			else if (rd.Content.Equals("Phòng loại B"))
			{
				lvPhongB.ItemsSource = lsPhongB;
				lvPhongA.ItemsSource = lsTrong;
				lvPhongC.ItemsSource = lsTrong;
				refreshListView();
			}
			else if (rd.Content.Equals("Phòng loại C"))
			{
				lvPhongC.ItemsSource = lsPhongC;
				lvPhongA.ItemsSource = lsTrong;
				lvPhongB.ItemsSource = lsTrong;
				refreshListView();
			}
			else if (rd.Content.Equals("Tất cả loại phòng"))
			{
				lvPhongC.ItemsSource = lsPhongC;
				lvPhongB.ItemsSource = lsPhongB;
				lvPhongA.ItemsSource = lsPhongA;
				refreshListView();
			}

		}
		private void refreshListView()
		{
			CollectionViewSource.GetDefaultView(lvPhongA.ItemsSource).Refresh();
			CollectionViewSource.GetDefaultView(lvPhongB.ItemsSource).Refresh();
			CollectionViewSource.GetDefaultView(lvPhongC.ItemsSource).Refresh();
		}
		private void capNhatLaiDuLieuListViewTheoNgayGio()
		{
			lsPhong = PhongBUS.Instance.getDataPhongTheoNgay();
			refeshLoaiPhong();
			rdTatCa.IsChecked = true;
			rdTatCaLoaiPhong.IsChecked = true;
			rdTatCaPhong.IsChecked = true;
		}

		#endregion

		#region Event
		// Sự kiện loade UC
		private void ucPhong_Loaded(object sender, EventArgs e)
        {
			var dt = DateTime.Now;
            dtpChonNgay.Text =dt.ToString("M/d/yyyy");
			tpGio.Text = dt.ToString("h:m:s");
        }


		//Khi click vào radioButton
		private void rb_Click(object sender, RoutedEventArgs e)
		{

			if (((sender as RadioButton).Parent as StackPanel).Name.ToString().Equals("spLoaiPhong"))
			{
				checkLoaiPhong(sender as RadioButton);
			}
			else
			{
				CollectionView viewPhongA = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongA.ItemsSource);
				CollectionView viewPhongB = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongB.ItemsSource);
				CollectionView viewPhongC = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongC.ItemsSource);
				viewPhongA.Filter = PhongFilter;
				viewPhongB.Filter = PhongFilter;
				viewPhongC.Filter = PhongFilter;
				refreshListView();
			}

		}

		//Khi click vào 1 item trong LV
		private void LvPhongALL_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ListView lv = sender as ListView;
			Phong phong = lv.SelectedItem as Phong;
			if (phong != null)
			{
				ChiTietPhong ct = new ChiTietPhong();
				ct.truyenData(phong);
				ct.ShowDialog();
				//if (ct.ShowDialog() == true)
				//{
					capNhatLaiDuLieuListViewTheoNgayGio();
				//}
				lv.UnselectAll();
			}
		}
		//Tìm kiếm theo mã phòng
		private void click_EnterSearch(object sender, RoutedEventArgs e)
		{
			timKiemTheomaPhong();
		}

		private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
		{
			timKiemTheomaPhong();
		}
		private void tpGio_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
		{
			//capNhatLaiDuLieuListViewTheoNgayGio();
		}

		private void selectedDateChang_DatePicker(object sender, SelectionChangedEventArgs e)
		{
			capNhatLaiDuLieuListViewTheoNgayGio();
		}


		#endregion

	}
}
