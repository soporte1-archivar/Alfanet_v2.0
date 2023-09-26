using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.CommonObject;
using Alfanet.Bll;

namespace AlfanetWCF_Library
{
    public class AdminService : IAdmin
    {
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjGrupo> selectGrupo(ConfigData config)
        {
            AdminBLL adminBLL= new AdminBLL();
            List<ObjGrupo> listObjGrupo= new List<ObjGrupo>();
            listObjGrupo = adminBLL.selectGrupo(config);
            return listObjGrupo;
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public string insertGrupo(ConfigData config)
        {
            AdminBLL admin = new AdminBLL();
            return admin.insertGrupo(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public string updateGrupo()
        {
            string a = "";
            return a;
        }
    }
}
