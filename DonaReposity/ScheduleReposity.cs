using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DonaReposity
{
    public class ScheduleReposity : IContentReposity<ScheduleItem>
    {
        public ScheduleReposity()
        {
            this.content_type = ViewModels.Enums.ContentType.Schedule;
        }

        public override IQueryable<ScheduleItem> Get()
        {
            IQueryable<ScheduleItem> result = null;
            this.command = @"SELECT ct.*, sd.date_begin FROM Contents AS ct
                    LEFT JOIN ScheduleDetails AS sd ON sd.id_content = ct.id_content
                    WHERE ct.fk_content_type = @content_type";
            result = this.ExecuteQuery(new { content_type = (int)this.content_type });
            return result;
        }

    }
}
