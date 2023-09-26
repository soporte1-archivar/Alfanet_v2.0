using Alfanet.CommonObject;
using System.Collections.Generic;
using System.ServiceModel;



namespace AlfanetWCF_Library
{
    [ServiceContract]
    public interface IRadicacionMasiva
    {
        [OperationContract]
        List<ObjFactura> GetPreview(string dependenciaEnvio, string naturaleza, string medio, string CodDep, ConfigData config, byte[] file, string fileName, out List<string> result, out string objCacheName, out string summary, out string CamposVacios, out string DuplicadosDB, out string DuplicadosExcel);

        [OperationContract]
        List<ObjParametros> GetParametrosIniciales(string grupoCodigo, ConfigData config);

        [OperationContract]
        List<ObjNaturaleza> GetNaturalezas(ConfigData config);

        [OperationContract]
        List<ObjDependencia> GetDependencias(ConfigData config);

        [OperationContract]
        List<ObjAccion> GetAcciones(ConfigData config);

        [OperationContract]
        List<ObjMedio> GetMedios(ConfigData config);

        [OperationContract]
        List<ObjExpediente> GetExpedientes(ConfigData config);

        [OperationContract]
        List<ObjFactura> RadicarFacturas(string UserID, string nomDep, string Dependencia, string ObjCacheName, string tempImagesPath, ConfigData config, out string result);

        [OperationContract]
        List<ObjFactura> BuscarRadicados(string Radicador, string porImagen, long radInicial, long radFinal, string comEgresoIni, string comEgresoFin, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string numFacIni, string numFacFinal, string nombreNit, string detalle, string ubicacion, string modalidad, string unidad, string expediente, string ciudadInicial, string ciudadFinal, ConfigData config);

        [OperationContract]
        void ObtenerDatosDependencia(string Dependencia, ConfigData config, out string UserIdAlfa, out string NombreDependencia);

        [OperationContract]
        List<string> ValidateFiles(string path, out string result, string cacheName);

        [OperationContract]
        bool ClearTempImages(string path, out string result);

        [OperationContract]
        bool ValidarUsuarioPermitido(string Dependencia, ConfigData config);

        [OperationContract]
        string UpdateRadicado(string codigo, string detalle, List<string> compEgresoList, ConfigData config);

        [OperationContract]
        List<ObjFactura> LoadFromCache(string nombre);

        [OperationContract]
        List<ObjCiudad> GetCiudades(ConfigData config);

        [OperationContract]
        List<ObjProcedencia> GetProcedencias(ConfigData config);

        [OperationContract]
        List<ObjFactura> GetResultadosBusqueda(string nombre);
    }
}
