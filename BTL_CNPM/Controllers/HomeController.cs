using BTL_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_CNPM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        //trang joblist user view
        public ActionResult JobList(string search = "")
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            List<tblThongTinTuyenDung> listTTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sVitri.Contains(search)).ToList();
            ViewBag.search = search;
            return View(listTTTuyendung);
        }

        //Chi tiet viec lam user view
        public ActionResult JobDetail(string id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sMaTD == id).FirstOrDefault();
            return View(TTTuyendung);
        }

        public ActionResult Contact()
        {
            return View();
        }

        //ho so ung vien user view
        public ActionResult HoSoUngVien()
        {
            if (Session["MaTK"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            string MaNV = Session["MaNV"].ToString();
            tblNhanVien NhanVien = db.tblNhanVien.Where(row => row.sMaNV == MaNV).FirstOrDefault();
            tblHoSoNhanVien HoSoNV = db.tblHoSoNhanVien.Where(row => row.sMaNV == NhanVien.sMaNV).FirstOrDefault();
            if(HoSoNV != null)
            {
                return View(HoSoNV);
            }

            return View();
        }

        [HttpPost]
        public ActionResult HoSoUngVien(tblHoSoNhanVien HosoNV)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();

            tblNhanVien Nhanvien = new tblNhanVien();
            Session["MaNV"] = HosoNV.sMaNV;
            Nhanvien.sMaNV = Session["MaNV"].ToString();
            Nhanvien.sMaTK = Session["MaTK"].ToString();

            db.tblNhanVien.Add(Nhanvien);
            db.tblHoSoNhanVien.Add(HosoNV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //chinh sua ho so user view
        public ActionResult EditHoSo(string id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblHoSoNhanVien HoSoNV = db.tblHoSoNhanVien.Where(row => row.sMaNV == id).FirstOrDefault();
            return View(HoSoNV);
        }

        [HttpPost]
        public ActionResult EditHoSo(tblHoSoNhanVien hosoupdate, int id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblHoSoNhanVien Hoso = db.tblHoSoNhanVien.Where(row => row.iMaHoSoNV == id).FirstOrDefault();
            Hoso.sTenNV = hosoupdate.sTenNV;
            Hoso.sEmail = hosoupdate.sEmail;
            Hoso.iCCCD = hosoupdate.iCCCD;
            Hoso.dNgaysinh = hosoupdate.dNgaysinh;
            Hoso.iSDT = hosoupdate.iSDT;
            Hoso.sDiachi = hosoupdate.sDiachi;
            Hoso.sHocvan = hosoupdate.sHocvan;
            Hoso.sKinhnghiem = hosoupdate.sKinhnghiem;
            db.SaveChanges();
            return RedirectToAction("HoSoUngVien");
        }

        //them ung vien vao danh sach ung tuyen 
        [HttpGet]
        public ActionResult ThemDanhSachUngTuyen(string sMaTD)
        {
            string MaNV;
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblDanhSachUngTuyen danhSachUngTuyen = new tblDanhSachUngTuyen();
            if(Session["MaNV"] == null)
            {
                return RedirectToAction("ThongTinUngVien");
            }
            else
            {
                MaNV = Session["MaNV"].ToString();
                danhSachUngTuyen.sMaTD = sMaTD;
                danhSachUngTuyen.sMaNV = MaNV;
                db.tblDanhSachUngTuyen.Add(danhSachUngTuyen);
                db.SaveChanges();
                return RedirectToAction("Joblist");
            }
        }
   
        //hien thi danh sach thong bao user view
        public ActionResult Thongbao()
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            if (Session["MaNV"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            string maNV = Session["MaNV"].ToString();
            List<tblThongBao> listThongbao = db.tblThongBao.Where(row => row.sMaNV == maNV).ToList();
            return View(listThongbao);
        }

    }
}