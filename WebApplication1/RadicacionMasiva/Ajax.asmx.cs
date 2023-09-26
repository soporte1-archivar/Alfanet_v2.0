using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.WorkFlowService;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;

namespace WebApplication1.RadicacionMasiva
{
    /// <summary>
    /// Summary description for Ajax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ajax : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetNaturalezas(string keyword)
        {
            CommonLibrary common = null;
            List<ObjNaturaleza> naturalezas = null;
            try
            {
                naturalezas = new List<ObjNaturaleza>();
                common = new CommonLibrary();
                string resultSearch = null;
                naturalezas = common.FindNaturalezasInCache("Naturalezas", out resultSearch);
                List<string> output = new List<string>();
                naturalezas = naturalezas.Where(x => x.NaturalezaNombre.ToUpper().Contains(keyword.ToUpper()) || x.NaturalezaCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjNaturaleza item in naturalezas)
                {
                    string anidado = item.NaturalezaCodigo + " | " + item.NaturalezaNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public List<string> GetDependencias(string keyword)
        {
            CommonLibrary common = null;
            List<ObjDependencia> dependencias = null;
            try
            {
                dependencias = new List<ObjDependencia>();
                common = new CommonLibrary();
                string resultSearch = null;
                dependencias = common.FindDependenciasInCache("Dependencias", out resultSearch);
                List<string> output = new List<string>();
                dependencias = dependencias.Where(x => x.DependenciaNombre.ToUpper().Contains(keyword.ToUpper()) || x.DependenciaCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjDependencia item in dependencias)
                {
                    string anidado = item.DependenciaCodigo + " | " + item.DependenciaNombre;
                    output.Add(anidado);
                }
                return output;

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que busca el listado de acciones almacenadas en cache. Filtra dichas acciones según keyword,
        /// y devuelve una lista de strins "cod | nombre" de las acciones que cumplen con el criterio de búsqueda
        /// contenido en keyword.
        /// </summary>
        /// <param name="keyword">Texto escrito por el usuario en el autocomplete.</param>
        /// <returns>Lista de strings "cod | nombre" de las acciones que cumplen con el criterio de búsqueda</returns>
        [WebMethod]
        public List<string> GetAcciones(string keyword)
        {
            CommonLibrary common = null;
            List<ObjAccion> acciones = null;
            try
            {
                acciones = new List<ObjAccion>();
                common = new CommonLibrary();
                string resultSearch = null;
                acciones = common.FindAccionesInCache("Acciones", out resultSearch);
                List<string> output = new List<string>();
                acciones = acciones.Where(x => x.AccionNombre.ToUpper().Contains(keyword.ToUpper()) || x.AccionCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjAccion item in acciones)
                {
                    string anidado = item.AccionCodigo + " | " + item.AccionNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [WebMethod]
        public List<string> GetCiudades2(string keyword)
        {
            CommonLibrary common = null;
            List<ObjCiudad> ciudades = null;
            try
            {
                ciudades = new List<ObjCiudad>();
                common = new CommonLibrary();
                string resultSearch = null;
                ciudades = common.FindCiudadesInCache("Ciudades", out resultSearch);
                List<string> output = new List<string>();
                ciudades = ciudades.Where(x => x.CiudadNombre.ToUpper().Contains(keyword.ToUpper()) || x.CiudadCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjCiudad item in ciudades)
                {
                    string anidado = item.CiudadCodigo + " | " + item.CiudadNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public List<string> GetProcedencias(string keyword)
        {
            CommonLibrary common = null;
            List<ObjProcedencia> procedencias = null;
            try
            {
                procedencias = new List<ObjProcedencia>();
                common = new CommonLibrary();
                string resultSearch = null;
                procedencias = common.FindProcedenciasInCache("Procedencias", out resultSearch);
                List<string> output = new List<string>();
                procedencias = procedencias.Where(x => x.ProcedenciaNombre.ToUpper().Contains(keyword.ToUpper()) || x.ProcedenciaCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjProcedencia item in procedencias)
                {
                    string anidado = item.ProcedenciaCodigo + " | " + item.ProcedenciaNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public List<string> GetMedios(string keyword)
        {
            CommonLibrary common = null;
            List<ObjMedio> medios = null;
            try
            {
                medios = new List<ObjMedio>();
                common = new CommonLibrary();
                string resultSearch = null;
                medios = common.FindMediosInCache("Medios", out resultSearch);
                List<string> output = new List<string>();
                medios = medios.Where(x => x.MedioNombre.ToUpper().Contains(keyword.ToUpper()) || x.MedioCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjMedio item in medios)
                {
                    string anidado = item.MedioCodigo + " | " + item.MedioNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public List<string> GetExpedientes(string keyword)
        {
            CommonLibrary common = null;
            List<ObjExpediente> expedientes = null;
            try
            {
                expedientes = new List<ObjExpediente>();
                common = new CommonLibrary();
                string resultSearch = null;
                expedientes = common.FindExpedientesInCache("Expedientes", out resultSearch);
                List<string> output = new List<string>();
                expedientes = expedientes.Where(x => x.ExpedienteNombre.ToUpper().Contains(keyword.ToUpper()) || x.ExpedienteCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

                foreach (ObjExpediente item in expedientes)
                {
                    string anidado = item.ExpedienteCodigo + " | " + item.ExpedienteNombre;
                    output.Add(anidado);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método ajax utilizado para la actualización de facturas. 
        /// </summary>
        /// <param name="codigo">Nº de radicado de la factura</param>
        /// <param name="detalle">Campo detalle</param>
        /// <param name="comprobante">Comprobante de egreso, ingresado por el usuario al momento de modificar.</param>
        /// <returns></returns>
        [WebMethod]
        public string UpdateFacturaRadicada(string codigo, string detalle, string comprobante)
        {            
            string output = string.Empty;
            try
            {
                
                return "Hola";
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
