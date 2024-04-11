using BTL_CNPM.Models;
using BTL_CNPM.Objects;
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
        public ActionResult JobList()
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            List<tblThongTinTuyenDung> listTTTuyendung = db.tblThongTinTuyenDung.ToList();
            return View(listTTTuyendung);
        }

        //Chi tiet viec lam user view
        public ActionResult JobDetail(string id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sMaTD == id).FirstOrDefault();
            return View(TTTuyendung);
        }


        public ActionResult JobCategory()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        //thong tin ung vien
        public ActionResult ThongTinUngVien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThongTinUngVien(tblNhanVien Nhanvien)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            Session["MaNV"] = Nhanvien.sMaNV;
            db.tblNhanVien.Add(Nhanvien);
            db.SaveChanges();
            return RedirectToAction("Index");
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
   
        //hien thi danh sach thong bao (user)
        public ActionResult Thongbao()
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            string maNV = Session["MaNV"].ToString();
            List<tblThongBao> listThongbao = db.tblThongBao.Where(row => row.sMaNV == maNV).ToList();
            return View(listThongbao);
        }

    }
}