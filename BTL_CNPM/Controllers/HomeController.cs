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
            Jobs jb1 = new Jobs("jb1", "Chuyển viên nhân sự", "CMC Corp", "Nhân viên chính thức", "Thỏa thuận", "Hà Nội", new DateTime(2024, 4, 12), 2);
            Jobs jb2 = new Jobs("jb2", "Chuyển viên Quản trị rủi ro", "CMC Corp", "Nhân viên chính thức", "Thỏa thuận", "Hà Nội", new DateTime(2024, 5, 1), 6);
            Jobs jb3 = new Jobs("jb3", "Chuyển viên Phát triển dự án", "CMC Corp", "Nhân viên chính thức", "Thỏa thuận", "Hà Nội", new DateTime(2024, 4, 30), 7);
            Jobs jb4 = new Jobs("jb4", "Chuyển viên Đầu tư công nghệ", "CMC Corp", "Nhân viên chính thức", "Thỏa thuận", "Hà Nội", new DateTime(2024, 4, 4), 2);
            Jobs jb5 = new Jobs("jb5", "Chuyển viên Kinh doanh cho thuê văn phòng", "CMC Corp", "Nhân viên chính thức", "Thỏa thuận", "Hồ Chí Minh", new DateTime(2024, 5, 2), 9);

            List<Jobs> jobList = new List<Jobs>();
            jobList.Add(jb1);
            jobList.Add(jb2);
            jobList.Add(jb3);
            jobList.Add(jb4);
            jobList.Add(jb5);
            return View(jobList);
        }
        public ActionResult JobDetail()
        {
            return View();
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
    }
}