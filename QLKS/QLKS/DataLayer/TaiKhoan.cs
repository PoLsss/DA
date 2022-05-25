using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DataLayer
{
	public class TaiKhoan
	{
        #region Properties
        private string userName;
        private string displayName;
        private string passWord;
        private int  capdoquyen;
        private int id;

        public string UserName { get => userName; set { userName = value; } }
		public string DisplayName { get => displayName; set { displayName = value;  } }
        public string Password { get => passWord; set { passWord = value;  } }
        public int CapDoQuyen { get => capdoquyen; set { capdoquyen = value;  } }
        public int Id { get => id; set { id = value; } }
        #endregion


        public static TaiKhoan Instance;

        public TaiKhoan() { }


		public static TaiKhoan GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TaiKhoan();
            }
            return Instance;
        }
        
        public TaiKhoan(string userName, string displayName, string passWord, int capdoquyen)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Password = passWord;
            this.CapDoQuyen = capdoquyen;
        }

        public TaiKhoan(DataRow row)
        {
            this.Id = (int) row["Id"];
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.CapDoQuyen = (int)row["CapDoQuyen"];
            this.Password = row["Password"].ToString();
        }
    }
}
