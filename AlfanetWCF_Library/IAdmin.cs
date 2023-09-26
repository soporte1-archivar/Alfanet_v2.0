using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;

namespace AlfanetWCF_Library
{
    [ServiceContract]
    public interface IAdmin
    {
        [OperationContract]
        List<ObjGrupo> selectGrupo(ConfigData config);

        [OperationContract]
        string insertGrupo(ConfigData config);

        [OperationContract]
        string updateGrupo();
    }
}
