using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DonaReposity
{
    public abstract class IReposity<T> where T : class
    {
        public string command;
        protected IQueryable<T> ExecuteQuery(string command = null, object param = null)
        {
            return ExecuteQuery<T>(command, param);
        }

        public IQueryable<T> ExecuteQuery(object param = null)
        {
            return ExecuteQuery<T>(null, param);
        }

        protected IQueryable<U> ExecuteQuery<U>(string command = null, object param = null)
        {
            IQueryable<U> result = null;
            IDBProvider provider = new MSSQLDBProvider();
            if (!string.IsNullOrEmpty(command))
                this.command = command;
            using (var conn = provider.GetDBConnection())
            {
                result = conn.Query<U>(this.command, param).AsQueryable<U>();
            }
            return result;
        }


        protected U ExecuteSingle<U>(string command = null, object param = null)
        {
            U result = default(U);
            IDBProvider provider = new MSSQLDBProvider();
            if (!string.IsNullOrEmpty(command))
                this.command = command;
            using (var conn = provider.GetDBConnection())
            {
                result = conn.Query<U>(this.command, param).SingleOrDefault();
            }
            return result;
        }

        protected T ExecuteSingle(string command = null, object param = null)
        {
            return ExecuteSingle<T>(command, param);
        }

        protected T ExecuteSingle(object param = null)
        {
            return ExecuteSingle<T>(null, param);
        }
    }
}
