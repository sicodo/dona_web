using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp
{
    public class CustomViewEngine : WebFormViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[] {  
                "~/Views/{1}/{0}.cshtml",  
                "~/Views/{1}/{0}.cshtml",  
                "~/Views/Shared/{0}.cshtml",  
                "~/Views/Shared/{0}.cshtml",  
                "~/Views/Shared/Partials/{0}.cshtml",  
                // etc
            };
            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
}