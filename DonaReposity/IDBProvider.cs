using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaReposity
{
    public abstract class IDBProvider
    {
        public string connection_string { get; set; }
        public abstract System.Data.Common.DbConnection GetDBConnection();
    }
}
