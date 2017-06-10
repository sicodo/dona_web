using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class IContent
    {
        public int id_content { get; set; }
        public int fk_content_type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }

        public DateTime date_created { get; set; }
        public string fk_user_posted { get; set; }

        public DateTime? date_modified { get; set; }
        public int? fk_user_modified { get; set; }

        public bool is_published { get; set; }
        public bool is_deleted { get; set; }
    }
}
