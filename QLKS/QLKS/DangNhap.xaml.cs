using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using QLKS.DataLayer.DAL;
using QLKS.Model;

namespace QLKS
{
	/// <summary>
	/// Interaction logic for DangNhap.xaml
	/// </summary>
	public partial class DangNhap : Window
	{
		public DangNhap()
		{
			InitializeComponent();
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//}

		//public bool Login()
		//{

		//	return TaiKhoanDAL.GetInstance().Login(txbTenDangNhap.Text, txbMatKhau.Password);
		//}
		//private void click_DangNhap(object sender, RoutedEventArgs e) {
		//	if (Login())
		//	{
		//		this.Hide();
		//		MainWindow f = new MainWindow();
		//		f.ShowDialog();

		//		//txbUserName.Text = String.Empty;
		//		//txbPassWord.Text = String.Empty;
		//		//txbUserName.Focus();

		//	}
		//	else
		//	{
		//		new DialogCustoms("Tên Đăng Nhập không tồn tại hoặc Mật Khẩu không đúng.\nVui lòng nhập lại!", "Thông báo", DialogCustoms.OK).ShowDialog();
		//	}
		//}




		public static string Base64Encode(string encode)
		{
			var PlainTextByes = System.Text.Encoding.UTF8.GetBytes(encode);
			return System.Convert.ToBase64String(PlainTextByes);
		}

		public static string MD5Hash(string input)
		{
			StringBuilder hash = new StringBuilder();
			MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
			byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

			for (int i = 0; i < bytes.Length; i++)
			{
				hash.Append(bytes[i].ToString("x2"));
			}
			return hash.ToString();
		}

		//3 lop
		private void click_DangNhap(object sender, RoutedEventArgs e)
		{
			string username = txbTenDangNhap.Text;
			string pass = txbMatKhau.Password;
			//TaiKhoan taiKhoan = TaiKhoanBUS.GetInstance().kiemTraTKTonTaiKhong(username, pass);

			string query = "Select * from Users where UserName = '" + username + "' and Password = '" + MD5Hash(Base64Encode(pass)) + "'";
			//string query = "USP_Login @username , @password";
			//string passencode = MD5Hash(Base64Encode(pass));
			DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] {username, MD5Hash(Base64Encode(pass)) });
			TaiKhoan tk;// = new TaiKhoan();
			
			if (data.Rows.Count > 0)
			{
				tk = new TaiKhoan(DataProvider.Ins.ExecuteQuery(query).Rows[0]);
				
				//TaiKhoan tk = new TaiKhoan(DataProvider.Ins.ExecuteQuery(query).Rows[0]);
				//return tk1;
				//TaiKhoan tk = (TaiKhoan)DataProvider.Ins.DB.Users.Where(p=>p.UserName == username && p.Password == passencode);
		//	}
			

			//if (tk != null)
			//{
				MainWindow main = new MainWindow(tk);
				main.Show();
				this.Close();
			}
			else
			{
				new DialogCustoms("Không tồn tại tài khoản mật khẩu  !", "Thông báo", DialogCustoms.OK).ShowDialog();
				txbTenDangNhap.Text = String.Empty;
				txbMatKhau.Password = String.Empty;
			}

		}


	}
}
