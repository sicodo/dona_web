using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DonaReposity
{
    public class MemberReposity : IReposity<Member>
    {
        public virtual Member Single(string id_user, bool need_password = false, bool need_validate_key = false)
        {
            Member result = null;
            this.command = string.Format("SELECT id_user,name,is_locked,is_deleted{0}{1} FROM Members WHERE id_user = @id_user", 
                need_password ? ",password" : "",
                need_validate_key ? ",validate_key" : ""
            );
            result = this.ExecuteSingle(new { id_user = id_user });
            return result;
        }

    }
}
