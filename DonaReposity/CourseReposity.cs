using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaReposity
{
    public class CourseReposity : IContentReposity<ViewModels.ContentItem>
    {
        public CourseReposity()
        {
            this.content_type = ViewModels.Enums.ContentType.Course;
        }

    }
}
