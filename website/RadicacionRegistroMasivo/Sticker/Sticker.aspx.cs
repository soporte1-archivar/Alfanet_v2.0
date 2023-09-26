using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;
using System.Web.UI.WebControls;


namespace WebApplication1.RadicacionRegistroMasivo.Sticker
{
    public partial class Sticker1 : System.Web.UI.Page
    {
        private int iterador = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            CommonLibrary common = new CommonLibrary();
            string result;
            List<ObjDocumentos> documents = common.FindObjectInCache("ObjectResult", out  result);


            List<WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker> llenado = new List<WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker>();
            WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker obj = null;
            iterador = (documents.Count) - 1;
            foreach (ObjDocumentos item in documents)
            {
                obj = new WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker();
                obj.Documento = item;
                llenado.Add(obj);
                obj = null;
            }
            lstvObjectSticker.DataSource = llenado;
            lstvObjectSticker.DataBind();

        }

        protected void lstvObjectSticker_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                CommonLibrary common = new CommonLibrary();
                string result;
                List<ObjDocumentos> documents = common.FindObjectInCache("ObjectResult", out  result);
                var itemHeaders = (WebApplication1.RadicacionRegistroMasivo.Sticker.Sticker)e.Item.FindControl("Item");
                if (itemHeaders != null)
                {
                    itemHeaders.Documento = documents[iterador];
                    iterador = iterador - 1;
                }
            }
        }


    }
}