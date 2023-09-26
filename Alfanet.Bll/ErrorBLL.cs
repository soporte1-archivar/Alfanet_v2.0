using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.CommonObject;
using Alfanet.Dal;

namespace Alfanet.Bll
{
    public class ErrorBLL
    {
        public bool SaveLogError(ObjError Error, ConfigData config)
        {
            QueryManager dal = null;            
            try
            {
                dal = new QueryManager();
                return dal.SaveLogError(Error, config);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
