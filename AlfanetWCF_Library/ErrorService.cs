using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.Bll;
using Alfanet.CommonObject;

namespace AlfanetWCF_Library 
{
    public class ErrorService : IError
    {
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool SaveLogError(ObjError Error, ConfigData config)
        {
            ErrorBLL bll = new ErrorBLL();
            return bll.SaveLogError(Error, config);               
            
        }
    }
}
