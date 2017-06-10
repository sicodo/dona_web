using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Dapper;

namespace DonaReposity
{
    public abstract class IContentReposity<T> : IReposity<T> where T:class
    {
        protected Enums.ContentType content_type { get; set; }

        public virtual IQueryable<T> Get() 
        {
            IQueryable<T> result = null;
            this.command = "SELECT * FROM Contents WHERE fk_content_type = @content_type";
            result = this.ExecuteQuery(new { content_type = (int)this.content_type });
            return result;
        }

        public virtual T Single(int id)
        {
            T result = default(T);
            this.command = "SELECT * FROM Contents WHERE fk_content_type = @content_type AND id_content = @id";
            result = this.ExecuteSingle(new { content_type = (int)this.content_type, id =id });
            return result;
        }

    }
}
