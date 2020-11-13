using luxuryShop.Models.Enity;
using luxuryShop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace luxuryShop.Areas.Admin.Controllers
{

    public class DashBoardController : BaseController
    {
        public luxuryEntities db = new luxuryEntities();
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Pagging(int pageIndex = 1, int pageSize = 5)
        {
            SanphamViewModels model = new SanphamViewModels();
            int upper = (pageIndex - 1) * pageSize;
            var emps = db.Products.OrderBy(x => x.ID);
            model.sanphams = emps.Skip(upper).Take(pageSize).ToList();
            model.pageIndex = pageIndex;
            model.pageSize = pageSize;
            model.TotalRecord = emps.Count();
            decimal totalPage = (decimal)model.TotalRecord / model.pageSize;
            model.TotalPage = decimal.ToInt32(Math.Ceiling(totalPage));
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Add(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add vào db
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Json(new { StatusCode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //Tên input, lỗi
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    return Json(new { StatusCode = 500, Message = allErrors.FirstOrDefault().ErrorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { StatusCode = 505, Message = "Lỗi Thêm Mới" }, JsonRequestBehavior.AllowGet);
            }
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

        public ActionResult Edit(int ID = 0)
        {
            Product sanpham1 = db.Products.Find(ID);
            if (sanpham1 == null)
            {
                return HttpNotFound();
            }
            return View(sanpham1);
        }

        [HttpPost]
        public ActionResult Edit(Product sanpham1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham1);
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            bool result = false;
            var u = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            if (u != null)
            {
                db.Products.Remove(u);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Donhang()
        {
            return View();
        }

        public PartialViewResult PaggingOrder(int pageIndex = 1, int pageSize = 20)
        {
            OrderViewModel model = new OrderViewModel();
            int upper = (pageIndex - 1) * pageSize;
            var emps = db.Carts.OrderBy(x => x.OrderID);
            model.orders = emps.Skip(upper).Take(pageSize).ToList();
            model.pageIndex = pageIndex;
            model.pageSize = pageSize;
            model.TotalRecord = emps.Count();
            decimal totalPage = (decimal)model.TotalRecord / model.pageSize;
            model.TotalPage = decimal.ToInt32(Math.Ceiling(totalPage));
            return PartialView(model);
        }
        public ActionResult DetailDonHang(int? OrderID)
        {
            if (OrderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ProductDetail> orderDetail = db.ProductDetails.Where(e => e.OrderID == OrderID).ToList();
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }
    }
}