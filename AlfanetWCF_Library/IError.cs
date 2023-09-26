using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;
using System.Globalization;
using System.Security.Permissions;
using System.Threading;


namespace AlfanetWCF_Library
{
    [ServiceContract]
    public interface IError
    {
        [OperationContract]
        bool SaveLogError(ObjError Error, ConfigData config);

    }
}
