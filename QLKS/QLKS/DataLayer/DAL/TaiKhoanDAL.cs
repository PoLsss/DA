using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using QLKS.Model;

namespace QLKS.DataLayer.DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;

		
		private TaiKhoanDAL()
        {
        }

		public static TaiKhoanDAL Instance {
            get { if (instance == null) instance = new TaiKhoanDAL(); return instance; }
            set { instance = value; } 
        }

		public static string Base64Encode(string encode) {
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



		//internal bool Login(string userName, string passWord)
		//      {


		//          string hashPass = MD5Hash(Base64Encode(passWord));
		//          string query = "USP_Login @UserName , @Password";
		//          DataTable data = DataProvider.Ins.ExecuteQuery(query, new object[] { userName, passWord });
		//          return data.Rows.Count > 0;
		//      }

		public TaiKhoan layTaiKhoanTuDataBase(string username, string pass)
		{
			string query = "Select * from Users where UserName = 'admin' and Password = 'db69fc039dcbd2962cb4d28f5891aae1'";
			string passencode = MD5Hash(Base64Encode(pass));
			DataTable data = DataProvider.Ins.ExecuteQuery(query);
			TaiKhoan tk = new TaiKhoan();
			if (data.Rows.Count > 0)
			{
				TaiKhoan tk1 = new TaiKhoan(DataProvider.Ins.ExecuteQuery(query).Rows[0]);
				return tk1;
				//TaiKhoan tk = (TaiKhoan)DataProvider.Ins.DB.Users.Where(p=>p.UserName == username && p.Password == passencode);
			}
			else return tk;

		}

	}
}
