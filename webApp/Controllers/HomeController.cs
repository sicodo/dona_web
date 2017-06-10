using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using webApp.Extensions;

namespace webApp.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _GetContent(int id, int content_type)
        {
            switch (content_type)
            {
                case (int)Enums.ContentType.Course: 
                    return Json(Common.GetCourse(id), JsonRequestBehavior.AllowGet);

                default: 
                    return Content("invalid request!");
            }                
        }

        public ActionResult _GetCourse(int id_course)
        {
            return _GetContent(id_course, (int)Enums.ContentType.Course);
        }

        public ActionResult _Schedule()
        {
            return PartialView("Partials/_Schedule");
        }

        [HttpPost]
        public ActionResult _RegisterCourse(CourseRegistration model)
        {
            string body_html = this.RenderRazorViewToString("EmailTemplates/EmailCourseRegister", model);
            bool result = Ultilities.EmailHelper.Send("phantuanthanh@gmail.com", "test", body_html);
            return Json(new {
                result_value = result ? 1 : 0,
                message = result ? "successfull" : "failed",
            });
        }
    }
}
