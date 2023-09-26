using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Alfanet.ConnectionManager
{
   public abstract class Connection
    {        
        protected string connectionString;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public Connection()
        {
            //ALL.
        }
        public abstract Database openConnection();

        public abstract int closeConnection();
    }
}
