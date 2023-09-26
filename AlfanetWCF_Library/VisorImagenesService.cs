using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Alfanet.Bll;
using Alfanet.CommonObject;
using System.Globalization;
using System.Security.Permissions;
using System.Threading;

namespace AlfanetWCF_Library
{
    public class VisorImagenesService : IVisorImagenes
    {
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<string> GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo, out List<string> rutas, ConfigData config) 
        {
            VisorImagenesBLL data = new VisorImagenesBLL();

            return data.GetFacturaImagenById(GrupoCodigo, FacturaCodigo, config, out rutas); 
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<string> GetRutaImagenById(string ImagenRutaCodigo,  out List<string> rutas, ConfigData config)
        {
            VisorImagenesBLL data = new VisorImagenesBLL();

            return data.GetRutaImagenById(ImagenRutaCodigo, config, out rutas);
        }


        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public int SelectRutaCodigoFacturas(string path, ConfigData config)
        {
            VisorImagenesBLL data = new VisorImagenesBLL();
            return data.SelectRutaCodigoFacturas(path, config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool InsertRutaImagen(int ImagenRutaCodigo, string ImagenRutaDescripcion, int ImagenRutaAnio, int ImagenRutaMes, int ImagenRutaGrupo, string ImagenRutaPath, ConfigData config, out int RutaCodigo) 
        {
            VisorImagenesBLL data = new VisorImagenesBLL();
            return data.InsertRutaImagen(ImagenRutaCodigo, ImagenRutaDescripcion, ImagenRutaAnio, ImagenRutaMes, ImagenRutaGrupo, ImagenRutaPath, config,out RutaCodigo);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool InsertFacturaImagen(int radicadoCodigo, string GrupoCodigo, string imagenNombre, int ImagenRutaCodigo, ConfigData config)
        {
            VisorImagenesBLL data = new VisorImagenesBLL();
            return data.InsertFacturaImagen(radicadoCodigo,  GrupoCodigo,  imagenNombre,  ImagenRutaCodigo,  config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool EliminarImagen(int FacturaCodigo, int FacturaImagenFolio, ConfigData config)
        {
            VisorImagenesBLL data = new VisorImagenesBLL();
            return data.EliminarImagen(FacturaCodigo, FacturaImagenFolio, config);
        }

        

    }
}
