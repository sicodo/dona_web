using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaReposity
{
    public class MSSQLDBProvider : IDBProvider
    {
        
        public override System.Data.Common.DbConnection GetDBConnection()
        {
            System.Data.Common.DbConnection result = null;
            if (string.IsNullOrEmpty(this.connection_string)) this.connection_string = System.Configuration.ConfigurationManager.ConnectionStrings["dona_db"].ConnectionString;
            result = new System.Data.SqlClient.SqlConnection(this.connection_string);

            return result;
        }

        public System.Data.Common.DbConnection GetDBConnection(string connection_string)
        {
            this.connection_string = connection_string;
            return this.GetDBConnection();
        }
    
    }
}
