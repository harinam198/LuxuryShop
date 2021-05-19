using luxuryShop.Models.Enity;
using luxuryShop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace luxuryShop.Controllers
{
    public class HomeController : Controller
    {
        public luxuryEntities db = new luxuryEntities();

        public ActionResult Index()
        {
            var Product = new Category();
            ViewBag.Dienthoai = Product.Dienthoai(8);
            ViewBag.Tainghe = Product.Tainghe();
            ViewBag.Dongho = Product.Dongho();
            ViewBag.BestSeller = Product.BestSeller();
            return View();
        }
        public ActionResult DienThoai()
        {
            var Product = new Category();
            ViewBag.Category = Product.Dienthoai(100);
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
        [HttpPost]
        public ActionResult AddOrder(List<ProductDetail> arr, Cart data2)
        {
            int orderID;
            data2.CreateDate = DateTime.Now;
            db.Carts.Add(data2);
            db.SaveChanges();
            orderID = data2.OrderID;
            foreach (ProductDetail item in arr)
            {
                item.OrderID = orderID;
            }
            db.ProductDetails.AddRange(arr.AsEnumerable());
            db.SaveChanges();

            //gửi email
            int? total = 0;
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Areas/client/template/email.html"));
            foreach (var item in arr)
            {
                content = content.Replace("{{NameProduct}}", item.Name);
                content = content.Replace("{{ID}}", item.OrderID.ToString());
                content = content.Replace("{{Price}}", item.Price.ToString());
                content = content.Replace("{{soluong}}", item.Quantity.ToString());
                string.Format("{0:#,##0}", total += item.Quantity * item.Price);
            }
            string shipEmail = data2.OrderEmail;
            string recipient = shipEmail;
            content = content.Replace("{{CustomerName}}", data2.OrderName);
            content = content.Replace("{{Phone}}", data2.OrderMobile);
            content = content.Replace("{{Email}}", data2.OrderEmail);
            content = content.Replace("{{Address}}", data2.OrderAddress);
            content = content.Replace("{{Total}}", total.ToString());
            content = content.Replace("{{CreateDate}}", data2.CreateDate.ToString());

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;
            WebMail.UserName = "lehainamx1@gmail.com";
            WebMail.Password = "01238450198";
            WebMail.Send(to: recipient, subject: "Đơn Hàng Từ LuxuryStore", body: content);
            return RedirectToAction("Index");
        }
        public ActionResult SearchItem(string productName)
        {
            try
            {
                if (string.IsNullOrEmpty(productName))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                List<Product> searchItem = db.Products.Where(e => e.Name.Contains(productName)).ToList();
                return View(searchItem);
            }
            catch
            {
                return RedirectToAction("ActionDenied", "Common");
            }
        }
    }
}