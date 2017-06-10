using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace webApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Manager/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Login(Member model)
        {
            bool result = Common.DoUserLogin(model);
            if (result)
            {
                return RedirectToAction("", "Manager");
            }
            else
            {
                return Json(new { result_value = 0, message = "failed" });
            }
        }

        public ActionResult _Logout()
        {
            Common.DoUserLogout();
            return RedirectToAction("", "Home");
        }
    }
}
