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
    public class RadicacionMasivaService : IRadicacionMasiva
    {
        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjFactura> GetPreview(string dependenciaEnvio, string naturaleza, string medio, string CodDep, ConfigData config, byte[] file, string fileName, out List<string> result, out string objCacheName, out string summary, out string CamposVacios, out string DuplicadosDB, out string DuplicadosExcel)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjFactura> list = new List<ObjFactura>();
            return radicacionMasivaBLL.GetPreview(dependenciaEnvio, naturaleza, medio, CodDep, config, file, fileName, out result, out objCacheName, out summary, out CamposVacios, out DuplicadosDB, out DuplicadosExcel);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjParametros> GetParametrosIniciales(string grupoCodigo, ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjParametros> list = new List<ObjParametros>();
            return radicacionMasivaBLL.GetParametrosIniciales(grupoCodigo, config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjFactura> RadicarFacturas(string UserID, string nomDep, string Dependencia, string ObjCacheName, string tempImagesPath, ConfigData config, out string result)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjFactura> list = new List<ObjFactura>();
            return radicacionMasivaBLL.RadicarFacturas(UserID, nomDep, Dependencia, ObjCacheName, tempImagesPath, config, out result);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjNaturaleza> GetNaturalezas(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjNaturaleza> list = new List<ObjNaturaleza>();
            return radicacionMasivaBLL.GetNaturalezas(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjDependencia> GetDependencias(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjDependencia> list = new List<ObjDependencia>();
            return radicacionMasivaBLL.GetDependencias(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjAccion> GetAcciones(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjAccion> list = new List<ObjAccion>();
            return radicacionMasivaBLL.GetAcciones(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjMedio> GetMedios(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjMedio> list = new List<ObjMedio>();
            return radicacionMasivaBLL.GetMedios(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjExpediente> GetExpedientes(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjExpediente> list = new List<ObjExpediente>();
            return radicacionMasivaBLL.GetExpedientes(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjFactura> BuscarRadicados(string Radicador, string porImagen, long radInicial, long radFinal, string comEgresoIni, string comEgresoFin, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string numFacIni, string numFacFinal, string nombreNit, string detalle, string ubicacion, string modalidad, string unidad, string expediente, string ciudadInicial, string ciudadFinal, ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            List<ObjFactura> list = new List<ObjFactura>();
            return radicacionMasivaBLL.BuscarRadicados(Radicador, porImagen, radInicial, radFinal, comEgresoIni, comEgresoFin, fechaInicial, fechaFinal, FacnReciboIni, FacnReciboFin, facValorMenor, facValorMayor, numFacIni, numFacFinal, nombreNit, detalle, ubicacion, modalidad, unidad, expediente, ciudadInicial, ciudadFinal, config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public void ObtenerDatosDependencia(string Dependencia, ConfigData config, out string UserIdAlfa, out string NombreDependencia)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            radicacionMasivaBLL.ObtenerDatosDependencia(Dependencia, config, out UserIdAlfa, out NombreDependencia);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<string> ValidateFiles(string path, out string result, string cacheName)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.ValidateFiles(path, out result, cacheName);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool ClearTempImages(string path, out string result)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.ClearTempImages(path, out result);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public bool ValidarUsuarioPermitido(string Dependencia, ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.ValidarUsuarioPermitido(Dependencia, config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public string UpdateRadicado(string codigo, string detalle, List<string> compEgresoList, ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.UpdateRadicado(codigo, detalle, compEgresoList, config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjFactura> LoadFromCache(string nombre)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.LoadFromCache(nombre);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjCiudad> GetCiudades(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.GetCiudades(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjProcedencia> GetProcedencias(ConfigData config)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.GetProcedencias(config);
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeAndAfterCall)]
        public List<ObjFactura> GetResultadosBusqueda(string nombre)
        {
            RadicacionMasivaBLL radicacionMasivaBLL = new RadicacionMasivaBLL();
            return radicacionMasivaBLL.GetResultadosBusqueda(nombre);
        }
    }
}
