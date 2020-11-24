using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWed.Models;

namespace DoAnWed.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        DataClasses1DataContext data;
        public ProductController()
        {
            data = new DataClasses1DataContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPham()
        {
            List<SanPham> dsSP = data.SanPhams.ToList();
            return View(dsSP);
        }
        public ActionResult detail(int masp)
        {
            SanPham sp = data.SanPhams.SingleOrDefault(n=>n.MaSP==masp);
            ViewBag.tenloai = sp.Loai.TenLoai;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        public ActionResult gio()
        {
            GioHang gh = (GioHang)Session["gh"];
            return PartialView(gh);
        }
    }
}
