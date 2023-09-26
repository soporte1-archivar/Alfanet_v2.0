using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Alfanet.ConnectionManager
{
    class OracleConnection : Connection
    {
        public OracleConnection()
        {
            //ALL
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Database openConnection()
        {
            try
            {
                var db = EnterpriseLibraryContainer.Current.GetInstance<Database>("oracleConnectionString");
                return db;
            }
            catch (Exception)
            {
                throw;
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
