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

    }
}