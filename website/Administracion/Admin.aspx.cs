using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WebApplication1.RegistrosService;
using Alfanet.CommonObject;
using WebApplication1.AdminService;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegistrosClient client = null;
            try
            {
                //client = new RegistrosClient();
                //ConfigData db = client.GetConfigurationInformation();
                //Session["DatabaseEngine"] = db;
                //llenarGrupo();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //if (!IsPostBack)
            //{
            //    BindListView();
            //}
        }

        private void llenarGrupo()
        {
            AdminClient admin = null;
            try
            {
                admin = new AdminClient();
                ObjGrupo[] objListGrupo = null;
                ConfigData config = new ConfigData();
                config = (ConfigData)Session["DatabaseEngine"];
                objListGrupo = admin.selectGrupo(config);

                LVGrupo.DataSource = objListGrupo;
                LVGrupo.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //protected void IBEditar_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (LVGrupo.SelectedIndex>=0)
        //    {
        //        LVGrupo.SelectItem(LVGrupo.SelectedIndex);
        //    }
        //}

        protected void LVGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVGrupo.SelectedIndex >= 0)
            {
                LVGrupo.SelectItem(LVGrupo.SelectedIndex);
            }
        }
    }
}