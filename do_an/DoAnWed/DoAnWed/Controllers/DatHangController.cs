using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWed.Models;

namespace DoAnWed.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/
        DataClasses1DataContext data = new DataClasses1DataContext();
       
        public ActionResult ThemMatHang(int masp)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
            {
                gh = new GioHang();
            }
            int kq = gh.themSP(masp);
            Session["gh"] = gh;
            return RedirectToAction("SanPham", "Product");

        }
      
        public ActionResult XemGioHang()
        {

            GioHang gh = (GioHang)Session["gh"];

            return View(gh);
        }
        [HttpGet]
        public ActionResult CheckOut()
        {
                
            GioHang gh = (GioHang)Session["gh"];

            return View(gh);
        }
        [HttpPost]
        public ActionResult PayMent(FormCollection col)
        {
            string email = col["txtEmail"];
            string name = col["txtName"];
            string address = col["txtDiaChi"];
            string city = col["txtThanhPho"];
            string phone = col["txtPhone"];
            PayMent pm = new PayMent();
            pm.sEmail = email;
            pm.sName = name;
            pm.sPhone = phone;
            pm.sCity = city;
            pm.sAdderss = address;
            ViewBag.pm = pm;

            GioHang gh = (GioHang)Session["gh"];

            return View(gh);
        }
    }
}
