using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}