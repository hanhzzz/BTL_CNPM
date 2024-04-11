using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_CNPM.Models;

namespace BTL_CNPM.Controllers
{
    public class VieclamController : Controller
    {
        // GET: Vieclam
        public ActionResult AdminQlyViecLam()
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            List<tblThongTinTuyenDung> tblThongTinTuyenDung = db.tblThongTinTuyenDung.ToList();
            return View(tblThongTinTuyenDung);
        }

        //them tin tuyen dung
        public  ActionResult CreateVieclam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVieclam(tblThongTinTuyenDung CreateTuyendung)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            db.tblThongTinTuyenDung.Add(CreateTuyendung);
            db.SaveChanges();
            return RedirectToAction("AdminQlyViecLam");
        }

        //chinh sua tin tuyen dung
        public ActionResult EditViecLam(string id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sMaTD == id).FirstOrDefault();
            return View(TTTuyendung);
        }

        [HttpPost]
        public ActionResult EditViecLam(tblThongTinTuyenDung tuyendungupdate)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sMaTD == tuyendungupdate.sMaTD).FirstOrDefault();
            TTTuyendung.sMaTD = tuyendungupdate.sMaTD;
            TTTuyendung.sVitri = tuyendungupdate.sVitri;
            TTTuyendung.sDoituong = tuyendungupdate.sDoituong;
            TTTuyendung.dNgayyeucau = tuyendungupdate.dNgayyeucau;
            TTTuyendung.dNgayhethan = tuyendungupdate.dNgayhethan;
            TTTuyendung.sMotaTD = tuyendungupdate.sMotaTD;
            TTTuyendung.iMucluong = tuyendungupdate.iMucluong;
            TTTuyendung.sDaingo = tuyendungupdate.sDaingo;
            TTTuyendung.sNoilamviec = tuyendungupdate.sNoilamviec;
            db.SaveChanges();
            return RedirectToAction("AdminQlyViecLam");
        }

        //xoa tin tuyen dung
        public ActionResult DeleteViecLam(string id)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendung = db.tblThongTinTuyenDung.Where(row => row.sMaTD == id).FirstOrDefault();
            return View(TTTuyendung);
        }

        [HttpPost]
        public ActionResult DeleteVieclam(string id, tblThongTinTuyenDung thongTinTuyenDung)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            tblThongTinTuyenDung TTTuyendungDelete = db.tblThongTinTuyenDung.Where(row => row.sMaTD == id).FirstOrDefault();
            db.tblThongTinTuyenDung.Remove(TTTuyendungDelete);
            db.SaveChanges();
            return RedirectToAction("AdminQlyViecLam");
        }

        //Danh sach nguoi ung tuyen moi cong viec admin view
        public ActionResult DanhSachUngTuyen(string sMaTD)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            List<tblDanhSachUngTuyen> listDanhSachUngTuyen = db.tblDanhSachUngTuyen.Where(row => row.sMaTD == sMaTD).ToList();
            List<tblNhanVien> listNhanVienUngTuyen = new List<tblNhanVien>();
            foreach(var item in listDanhSachUngTuyen)
            {
                tblNhanVien Nhanvien = db.tblNhanVien.Where(row => row.sMaNV == item.sMaNV).FirstOrDefault();
                listNhanVienUngTuyen.Add(Nhanvien);
            }
            return View(listNhanVienUngTuyen);
        }

        //admin gui thong bao cho ung vien (admin)
        public ActionResult Guithongbao(string sMaNV)
        {
            string maNV = sMaNV;
            ViewBag.maNV = maNV;
            return View();
        }

        [HttpPost]
        public ActionResult Guithongbao(tblThongBao thongBao)
        {
            QlyViecLamEntities1 db = new QlyViecLamEntities1();
            db.tblThongBao.Add(thongBao);
            db.SaveChanges();
            return RedirectToAction("AdminQlyViecLam");
        }
    }
}