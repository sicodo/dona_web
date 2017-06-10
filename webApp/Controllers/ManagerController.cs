using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace webApp.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _GetCourses()
        {
            var items = Common.GetCourses();

            return PartialView("~/Views/Manager/Partials/_CourseList.cshtml", items);
        }

    }
}
