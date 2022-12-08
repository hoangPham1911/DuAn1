using _2_BUS.ViewModels;
using _3_PL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_PL.Helpers
{
    public class AccoutHelper
    {
        public static  AccoutHelper Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccoutHelper();
                }
                return _instance;
            } 
        }
        private static  AccoutHelper _instance;
        private static NhanVienViewModels _userLoged;

        private AccoutHelper()
        {

        }

        public NhanVienViewModels GetUserLoged()
        {
            return _userLoged;
        }

        public void SetUserLogin(NhanVienViewModels nhanVien)
        {
            _userLoged = nhanVien;
        }
    }
}
