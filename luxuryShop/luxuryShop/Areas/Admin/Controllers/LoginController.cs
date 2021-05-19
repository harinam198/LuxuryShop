using luxuryShop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace luxuryShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(LoginViewModel model)
        {
            try
            {
                if (model.Email == "hainam" && model.Password == "123456")
                {
                    Session.Add("UserInformation", "hainam123456");
                    //Session["UserInformation"] = "hainam123456";
                    return Json(new { Code = 200 }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Code = 500, ErrorMessage = "Đăng nhập thất bại" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Code = 500, ErrorMessage = "Đăng nhập thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("UserInformation");
            Session.Abandon();
                return RedirectToAction("/");
        }
    }
}