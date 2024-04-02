using BTL_CNPM.Models;
using BTL_CNPM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_CNPM.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKoan(String name, String taikhoan,String password)
        {
            QlyViecLamEntities db=new QlyViecLamEntities();
            tblTaiKhoan tk=new tblTaiKhoan();
            DateTime currentTime=DateTime.Now;
            String newID=taikhoan+currentTime.Minute.ToString()+currentTime.Second.ToString();

            tk.sMaTK = newID;
            tk.sMaNV = null;
            tk.sMaQuyen = Convert.ToString(2);
            tk.sTaiKhoan = taikhoan;
            tk.sMatKhau = password;
            tk.sTinhTrang = "Xem xét";

            db.tblTaiKhoans.Add(tk);
            db.SaveChanges();

            Session["user"] = taikhoan;
            return RedirectToAction("../Home/Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(String taikhoan, String matkhau)
        {
            QlyViecLamEntities db=new QlyViecLamEntities();
            var prov=db.tblTaiKhoans.Where(s=>s.sTaiKhoan==taikhoan && s.sMatKhau==matkhau).ToList();

            if (prov==null)
            {
               return RedirectToAction("../Home/Error404");
            }
            else
            {
                foreach(var item in prov)
                {
                    if (item.sMaQuyen == "1")
                    {
                        Session["user"] = item.sTaiKhoan;
                        return RedirectToAction("QlyAccount");
                    }
                    else
                    {
                        Session["user"]=item.sTaiKhoan;
                        return RedirectToAction("../Home/Index");
                    }
                }
            }
            ViewData["account"] = "Tài khoản hoặc mật khẩu ko đúng";
            return RedirectToAction("./Login");
        }
        public ActionResult QlyAccount()
        {
            QlyViecLamEntities db = new QlyViecLamEntities();

            return View(db.tblTaiKhoans.ToList());
        }
        public ActionResult QlyViecLam()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }
        [HttpPost]
        public ActionResult CapNhatAccount(String mataikhoan,String taikhoan, String matkhau, String tinhtrang)
        {
            QlyViecLamEntities db = new QlyViecLamEntities();
            var updateAccount = db.tblTaiKhoans.Find(mataikhoan);

            updateAccount.sTaiKhoan = taikhoan;
            updateAccount.sMaNV = null;
            updateAccount.sMatKhau=matkhau;
            updateAccount.sTinhTrang= tinhtrang;

            db.SaveChanges();
            return RedirectToAction("./QlyAccount");
        }

        [HttpPost]
        public ActionResult XoaAccount(String mataikhoan)
        {
            QlyViecLamEntities db = new QlyViecLamEntities();
            var deleteTK = db.tblTaiKhoans.Find(mataikhoan);
            db.tblTaiKhoans.Remove(deleteTK);
            db.SaveChanges();
            return RedirectToAction("./QlyAccount");
        }
    }
}