using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonObject;
using Alfanet.CommonLibrary;

namespace WebApplication1.RadicacionRegistroMasivo.Sticker
{
    public partial class Sticker : System.Web.UI.UserControl
    {
        private ObjDocumentos documento;

        public ObjDocumentos Documento
        {
            get { return documento; }
            set { documento = value; }
        }        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LblStickerFecRad.Text = documento.WfmovimientoFecha.ToString();
            LblStickerNroRad.Text = documento.NumeroDocumento;
            LblStickercargarA.Text = documento.DependenciaDestino;
            LblStickercargarA.Text = documento.ProcedenciaNombre;
            LblDireccion.Text = documento.Direccion;
        }
    }
}