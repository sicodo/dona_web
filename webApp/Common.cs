using DonaReposity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using ViewModels;

namespace webApp
{
    public class Common
    {

        public class Reposity
        {
            public static CourseReposity Course
            {
                get
                {
                    return new CourseReposity();
                }
            }

            public static ScheduleReposity Schedule
            {
                get
                {
                    return new ScheduleReposity();
                }
            }


            public static MemberReposity User
            {
                get
                {
                    return new MemberReposity();
                }
            }
        }

        public static IEnumerable<ContentItem> GetCourses()
        {
            return Reposity.Course.Get();
        }

        public static ContentItem GetCourse(int id)
        {
            return Reposity.Course.Single(id);
        }

        public static IEnumerable<ScheduleItem> GetSchedules()
        {
            return Reposity.Schedule.Get();
        }
        
        public static ScheduleItem GetSchedule(int id)
        {
            return Reposity.Schedule.Single(id);
        }

        public static bool DoUserLogin(Member model){
            bool result = false;

            var user = Reposity.User.Single(model.id_user, true);

            if (user != null)
            {
                if (user.isValidPassword(model.password))
                {
                    FormsAuthentication.SetAuthCookie(model.id_user, false);
                    result = true;
                }
            }
            return result;
        }

        public static void DoUserLogout()
        {
            FormsAuthentication.SignOut();
        }

        public static bool IsManagerRequest(){
            string controllerName = @HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            return controllerName.Equals("manager", StringComparison.InvariantCultureIgnoreCase);
        }

    }
}