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
    public interface IVisorImagenes
    {
        [OperationContract]
        List<string> GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo, out List<string> rutas, ConfigData config);

        [OperationContract]
        List<string> GetRutaImagenById(string ImagenRutaCodigo, out List<string> rutas, ConfigData config);

        [OperationContract]
        int SelectRutaCodigoFacturas(string path, ConfigData config);

        [OperationContract]
        bool InsertRutaImagen(int ImagenRutaCodigo, string ImagenRutaDescripcion, int ImagenRutaAnio, int ImagenRutaMes, int ImagenRutaGrupo, string ImagenRutaPath, ConfigData config, out int RutaCodigo);

        [OperationContract]
        bool InsertFacturaImagen(int radicadoCodigo, string GrupoCodigo, string imagenNombre, int ImagenRutaCodigo, ConfigData config);

        [OperationContract]
        bool EliminarImagen(int FacturaCodigo, int FacturaImagenFolio, ConfigData config);

       


    }
}
