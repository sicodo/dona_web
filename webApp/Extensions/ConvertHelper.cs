using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Extensions
{
    public static class ConvertHelper
    {
        public static string RenderRazorViewToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static string ToDateString(this DateTime obj)
        {
            return obj.ToString("dd/MM/yyyy");
        }

        public static string ToDateTimeString(this DateTime obj)
        {
            return obj.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static string ToLocalString(this bool obj)
        {
            return obj ? "Yes" : "No";
        }
    }
}