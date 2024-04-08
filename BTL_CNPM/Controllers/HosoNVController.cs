using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_CNPM.Models;

namespace BTL_CNPM.Controllers
{
    public class HosoNVController : Controller
    {
        // GET: HosoNV
        public ActionResult Index()
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            List<HOSONHANVIEN> hosoNV = db.HOSONHANVIEN.ToList();
            return View(hosoNV);
        }

        //tao ho so
        public ActionResult TaoHoso()
        {
            return View();
        }

        [HttpPost]

        public ActionResult TaoHoso(HOSONHANVIEN hosoNV)
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            db.HOSONHANVIEN.Add(hosoNV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //chinh sua ho so
        public ActionResult Edit(int id)
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            HOSONHANVIEN hosoNV = db.HOSONHANVIEN.Where(row => row.MANHANVIEN == id).FirstOrDefault();
            return View(hosoNV);
        }

        [HttpPost]
        public ActionResult Edit(HOSONHANVIEN hsNVupdate)
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            HOSONHANVIEN hosoNV = db.HOSONHANVIEN.Where(row => row.MANHANVIEN == hsNVupdate.MANHANVIEN).FirstOrDefault();
            //update
            hosoNV.MANHANVIEN = hsNVupdate.MANHANVIEN;
            hosoNV.MAHOSO = hsNVupdate.MAHOSO;
            hosoNV.TENNHANVIEN = hsNVupdate.TENNHANVIEN;
            hosoNV.NGAYLAP = hsNVupdate.NGAYLAP;
            hosoNV.VITRI = hsNVupdate.VITRI;
            hosoNV.CCCD = hsNVupdate.CCCD;
            hosoNV.NGAYSINH = hsNVupdate.NGAYSINH;
            hosoNV.SDT = hsNVupdate.SDT;
            hosoNV.DIACHI = hsNVupdate.DIACHI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //xoa ho so
        public ActionResult Delete(int id)
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            HOSONHANVIEN hosoNV = db.HOSONHANVIEN.Where(row => row.MANHANVIEN == id).FirstOrDefault();
            return View(hosoNV);
        }

        [HttpPost]

        public ActionResult Delete(int id, HOSONHANVIEN hsNV)
        {
            HosonhanvienNMCNPMEntities db = new HosonhanvienNMCNPMEntities();
            HOSONHANVIEN hosoNV = db.HOSONHANVIEN.Where(row => row.MANHANVIEN == id).FirstOrDefault();
            db.HOSONHANVIEN.Remove(hosoNV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}