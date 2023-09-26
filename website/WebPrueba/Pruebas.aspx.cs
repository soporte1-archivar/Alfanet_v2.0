using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WebApplication1.RegistrosService;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;

namespace WebApplication1.WebPrueba
{
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegistrosClient client = null;
            //try
            //{
            //    client = new RegistrosClient();
            //    ConfigData db = client.GetConfigurationInformation();
            //    Session["DatabaseEngine"] = db;
            //    List<ObjExample> list = new List<ObjExample>();
            //    CommonLibrary Funtions = new CommonLibrary();                
            //    string resultado;
            //    list = Funtions.FindObjectInCache("objectTest", out resultado);
            //    GridView1.DataSource = list;
            //    GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //RegistrosClient oCon = new RegistrosClient();
            //ObjExample obj  = new ObjExample();            
            //obj.Descripcion = "ESTA ES UNA PRUEBA INSERT HECHA DESDE ALFANET V2.0 HAS";
            //obj.TipoSolicitud = 1;
            //obj.PrioridadSolicitud = 1;
            //obj.EstadoSolicitud = 1;
            //obj.FechaSolicitud = DateTime.Now;
            //obj.FechaEstado = DateTime.Now;
            //obj.Cliente = 9739542;            
            //ConfigData config = new ConfigData();
            //config = (ConfigData)Session["DatabaseEngine"];
            //string result = oCon.SaveRegistro(obj,config);
            //CommonLibrary Funtions = new CommonLibrary();
            //string resultado;
            //Funtions.SaveObjectInCache("objectTest",obj,out resultado);
            //LblResult.Text = result;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //RegistrosClient oCon = new RegistrosClient();
            //ObjExample obj  = new ObjExample();             
            //obj.Descripcion = "ESTA ES UNA PRUEBA INSERT HECHA DESDE ALFANET V2.0 HAS";
            //obj.TipoSolicitud = 1;
            //obj.PrioridadSolicitud = 1;
            //obj.EstadoSolicitud = 1;
            //obj.FechaSolicitud = DateTime.Now;
            //obj.FechaEstado = DateTime.Now;
            //obj.Cliente = 9739542;
            //ConfigData config = new ConfigData();
            //config = (ConfigData)Session["DatabaseEngine"];
            //string result = oCon.UpdateRegistro(obj, Convert.ToInt32(txtRegistroUpdate.Text.Trim()),config);
            //LblResult.Text = result;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //RegistrosClient oCon = new RegistrosClient();
            //ConfigData config = new ConfigData();
            //config = (ConfigData)Session["DatabaseEngine"];
            //string result = oCon.DeleteRegistro(Convert.ToInt32(txtDelete.Text.Trim()),config);
            //LblResult.Text = result;

        }
    }
}
