using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.WorkFlowService;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;

namespace WebApplication1.WorkFlow
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
    }
}
