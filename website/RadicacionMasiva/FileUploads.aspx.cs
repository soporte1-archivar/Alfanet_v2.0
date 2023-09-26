using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1.RadicacionMasiva
{
    public partial class FileUploads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile uploads = Request.Files["FileData"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            string dependencia = Session["Dependencia"].ToString().Replace('.', '_');
            string directoryTemp = System.Configuration.ConfigurationManager.AppSettings["path_images"] + dependencia + @"\";
            try
            {
                if (!Directory.Exists(directoryTemp))
                {
                    Directory.CreateDirectory(directoryTemp);
                }
                uploads.SaveAs(directoryTemp + file);
            }
            catch
            {

            }
        }
    }
}