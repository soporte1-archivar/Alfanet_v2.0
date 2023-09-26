using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Alfanet.ConnectionManager
{
    public class SqlServerConnection : Connection
    {
        public SqlServerConnection()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Database openConnection()
        {
            try
            {
                var db = EnterpriseLibraryContainer.Current.GetInstance<Database>("sqlConnectionString");
                return db;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int closeConnection()
        {
            throw new NotImplementedException();
        }
    }
}
