using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_CNPM.Objects
{
    public class TaiKhoan
    {
        private String hoten;
        private String email;
        private String password;


        public string Hoten { get => hoten; set => hoten = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}