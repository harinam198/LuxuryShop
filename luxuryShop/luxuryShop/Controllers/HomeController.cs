using luxuryShop.Models.Enity;
using luxuryShop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace luxuryShop.Controllers
{
    public class HomeController : Controller
    {
        public luxuryEntities db = new luxuryEntities();

        public ActionResult Index()
        {
            var Product = new Category();
            ViewBag.Dienthoai = Product.Dienthoai();
            ViewBag.Tainghe = Product.Tainghe();
            ViewBag.Dongho = Product.Dongho();
            return View();
        }
        public ActionResult DienThoai()
        {
            var Product = new Category();
            ViewBag.Category = Product.Dienthoai();
            return View();
        }
        public ActionResult Tainghe()
        {
            var Product = new Category();
            ViewBag.Category = Product.Tainghe();
            return View();
        }
        public ActionResult DongHo()
        {
            var Product = new Category();
            ViewBag.Category = Product.Dongho();
            return View();
        }

        public ActionResult Detail(int ID)
        {
            Product sanpham1 = db.Products.Find(ID);
            if (sanpham1 == null)
            {
                return HttpNotFound();
            }
            return View(sanpham1);
        }
        public ActionResult Pay()
        {
            return View();
        }
    }
}