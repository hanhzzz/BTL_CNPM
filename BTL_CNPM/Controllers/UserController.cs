using BTL_CNPM.Models;
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
            QlyViecLamEntities1 db=new QlyViecLamEntities1();
            tblTaiKhoan tk=new tblTaiKhoan();
            DateTime currentTime=DateTime.Now;
            String newID=taikhoan+currentTime.Minute.ToString()+currentTime.Second.ToString();

            tk.sMaTK = newID;
            tk.sMaQuyen = Convert.ToString(2);
            tk.sTaiKhoan = taikhoan;
            tk.sMatKhau = password;
            tk.sTinhTrang = "Xem xét";

            db.tblTaiKhoan.Add(tk);
            db.SaveChanges();

            Session["user"] = taikhoan;
            return RedirectToAction("../Home/Index");
        }

        //dang nhap user view
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(String taikhoan, String matkhau)
        {
            QlyViecLamEntities1 db=new QlyViecLamEntities1();
            var prov=db.tblTaiKhoan.Where(s=>s.sTaiKhoan==taikhoan && s.sMatKhau==matkhau).ToList();

            if (prov==null)
            {
               return RedirectToAction("../Home/Error404");
            }
            else
            {
                foreach(var item in prov)
                {
                    Session["MaquyenUser"] = item.sMaQuyen;
                    if (Session["MaquyenUser"].ToString() == "1")
                    {
                        Session["user"] = item.sTaiKhoan;
                        Session["MaTK"] = item.sMaTK;
                        return RedirectToAction("QlyAccount");
                    }
                    else
                    {
                        Session["user"]=item.sTaiKhoan;
                        Session["MaTK"] = item.sMaTK;
                        string MaTK = Session["MaTK"].ToString();
                        var currentNV = db.tblNhanVien.Where(row => row.sMaTK == MaTK).FirstOrDefault();
                        if (currentNV != null)
                        {
                            Session["MaNV"] = currentNV.sMaNV;
                        }
                        else
                        {
                            Session["MaNV"] = null;
                        }

                        return RedirectToAction("../Home/Index");
                    }
                }
            }
            ViewData["account"] = "Tài khoản hoặc mật khẩu ko đúng";
            return RedirectToAction("./Login");
        }
        public ActionResult QlyAccount()
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();

            return View(db.tblTaiKhoan.ToList());
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }
        [HttpPost]
        public ActionResult CapNhatAccount(String mataikhoan,String taikhoan, String matkhau, String tinhtrang)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            var updateAccount = db.tblTaiKhoan.Find(mataikhoan);

            updateAccount.sTaiKhoan = taikhoan;
            updateAccount.sMatKhau=matkhau;
            updateAccount.sTinhTrang= tinhtrang;

            db.SaveChanges();
            return RedirectToAction("./QlyAccount");
        }

        [HttpPost]
        public ActionResult XoaAccount(String mataikhoan)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            var deleteTK = db.tblTaiKhoan.Find(mataikhoan);
            db.tblTaiKhoan.Remove(deleteTK);
            db.SaveChanges();
            return RedirectToAction("./QlyAccount");
        }


    }
}