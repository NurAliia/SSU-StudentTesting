using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sgu.StudentTesting.DAL
{
    public abstract class BaseDao
    {
        #region [Fields]
        private readonly string connectionString;

        #endregion [/Fields]

        #region [Ctor]
        public BaseDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion [/Ctor]
        #region [Method]
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        #endregion [/Method]

    }
}
