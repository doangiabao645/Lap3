using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private string connection;
        private dbSachOnlineDataContext data;
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SachID).Take(count).ToList();
        }
        public SachOnlineController()
        {
            // Khởi tạo chuỗi kết nối
            connection = "Data Source=LAPTOP-O5R6LPBI;Initial Catalog=SachOnline;Integrated Security=True";
            data = new dbSachOnlineDataContext(connection);
        }


        // GET: SachOnline
        public ActionResult Index()
        {
            //Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
       /* public ActionResult ChuDePartial()
        {
            return PartialView();
        }*/
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }
    
        public ActionResult ChuDePartial() { 
            var listChuDe = from cd in data.CHUDEs select cd; 
            return PartialView(listChuDe); }
        public  ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.ChuDeID==id select s;
            return View(sach);
        }
        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var listSachTheoNXB = from s in data.SACHes where s.NhaXuatBanID == id select s;
            return View(listSachTheoNXB);
        }
        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes
                       where s.SachID == id
                       select s;
            return View(sach.Single());
        }

    }
}