using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    [Serializable]
    public class CourseRegistration
    {
        public string id { get; set; }
        DateTime date_post { get; set; }
        public string ip { get; set; }

        public string full_name { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public string phone { get; set; }
        public string job_title { get; set; }
        public int id_course { get; set; }
        public Dictionary<string, string> skills { get; set; }
        public string course_request { get; set; }

    }

}
