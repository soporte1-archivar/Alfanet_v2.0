using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using Alfanet.CommonObject;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data;
using System.Reflection;



namespace Alfanet.CommonLibrary
{
    public class CommonLibrary
    {      
        /// <summary>
        /// Persiste la información de configuración del usuario.
        /// </summary>
        /// <param name="configData">UserInformationData</param>
        public static void SaveEngineConfigurationData(int engineCode)
        {
            try
            {

                XElement xmlFile = XElement.Load(HttpContext.Current.Server.MapPath(@"~/config/config.xml"));

                //Obtener el contacto con nombre Luis
                var config = (from c in xmlFile.Descendants("DatabaseEngine")
                              select c).FirstOrDefault();//Element("Value").Value);

                if (config != null)
                    config.SetElementValue("Value", engineCode.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Recupera la información de configuración del usuario.
        /// </summary>
        /// <returns>UserInformationData</returns>
        public ConfigData GetConfigurationInformation()
        {
            XDocument document = null;
            List<ConfigData> configList = new List<ConfigData>();
            try
            {
                document = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/config/config.xml");

                configList = (from configuration in document.Descendants("DatabaseEngine")
                              select new ConfigData
                              {
                                  DataBaseEngine = Convert.ToInt32(configuration.Element("Value").Value)
                              }).ToList();
                return configList.ElementAt <ConfigData>(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Almacena objetos de tipo DataTable en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name,DataTable ob, out string result) 
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();                
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;                             

            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }           
        }

        /// <summary>
        /// Almacena objetos de tipo ObjExample en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, ObjExample ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;

            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Almacena objetos de tipo ObjWorkFlowDocuments en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, ObjWorkFlowDocuments ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;

            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Almacena objetos de tipo List<ObjCiudad> en memoria cache
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, List<ObjCiudad> obj, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, obj, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        public bool SaveObjectInCache(string name, List<ObjProcedencia> obj, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, obj, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Almacena objetos de tipo ObjDocumentos en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, List<ObjDocumentos> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Almacena objetos de tipo List<ObjFactura> en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, List<ObjFactura> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Almacena objetos de tipo List<ObjDependencia> en memoria cache
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="result"></param>
        /// <returns></returns>        
        public bool SaveObjectInCache(string name, List<ObjDependencia> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Almacena un objeto de tipo List<ObjAccion> en cache.
        /// </summary>
        /// <param name="name">Nombre en cache del objeto que se va a almacenar</param>
        /// <param name="ob">Objeto que se va a almacenar</param>
        /// <param name="result">Variable de salida, resultado del proceso.</param>
        /// <returns>Verdadero si el objeto es almacenado correctamente.</returns>
        public bool SaveObjectInCache(string name, List<ObjAccion> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Devuelve en un dataset los objetos de prueba en cache 
        /// </summary>
        /// <returns></returns>
        public List<ObjDocumentos> FindObjectInCache(string name, out string result)
        {
            List<ObjDocumentos> resultList = null;
            try
            {
                resultList = new List<ObjDocumentos>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjDocumentos>)objectCache[name];
                    result = string.Empty;
                    return resultList;                                  
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }          
            }
            catch (Exception)
            {
                result = "";
                return null;
            }
        }

        /// <summary>
        /// Devuelve en una lista de objetos de tipo ObjDependencia todo el listado de dependencias almacenadas en cache. 
        /// </summary>
        /// <returns></returns>
        public List<ObjDependencia> FindDependenciasInCache(string name, out string result)
        {
            List<ObjDependencia> resultList = null;
            try
            {
                resultList = new List<ObjDependencia>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjDependencia>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        public List<ObjProcedencia> FindProcedenciasInCache(string name, out string result)
        {
            List<ObjProcedencia> resultList = null;
            try
            {
                resultList = new List<ObjProcedencia>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjProcedencia>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        /// <summary>
        /// Devuelve en una lista de objetos de tipo objFactura todo el listado de dependencias almacenadas en cache. 
        /// </summary>
        /// <returns></returns>
        public List<ObjFactura> FindFacturasInCache(string name, out string result)
        {
            List<ObjFactura> resultList = null;
            try
            {
                resultList = new List<ObjFactura>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjFactura>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        public List<ObjAccion> FindAccionesInCache(string name, out string result)
        {
            List<ObjAccion> resultList = null;
            try
            {
                resultList = new List<ObjAccion>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjAccion>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }
        /// <summary>
        /// Devuelve un objeto de tipo ObjWorkFlowDocuments almacenado en cache
        /// </summary>
        /// <param name="name">Nombre con el que se almacenó el objeto</param>
        /// <param name="result">Descripción del resultado de la búsqueda</param>
        /// <returns></returns>
        public ObjWorkFlowDocuments FindObjInCache(string name, out string result)
        {
            ObjWorkFlowDocuments resultObj = null;
            try
            {
                resultObj = new ObjWorkFlowDocuments();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultObj = (ObjWorkFlowDocuments)objectCache[name];
                    result = string.Empty;
                    return resultObj;
                }
                else
                {
                    result = "Objeto no encontrado";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }
        /// <summary>
        ///Devuelve si se encuentra un objeto de cualquier tipo en el cache
        /// </summary>
        /// <param name="name">Nombre con el que se almacenó el objeto</param>
        /// <param name="result">Descripción del resultado de la búsqueda</param>
        /// <returns></returns>
        public bool FindAnyObjInCache(string name, out string result)
        {           
            try
            {                
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    result = "Objeto encontrado";
                    return true;
                }
                else
                {
                    result = "Objeto no encontrado";
                    return false;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return false;
            }
        }
        public List<ObjDocumentos> FindKeyInWorkFlow(string Objectsearch ,string Key) 
        {
            List<ObjDocumentos> resultKey = null;
            List<ObjDocumentos> aux = null;
            ObjWorkFlowDocuments findIt = null;
            try
            {
                string result = null;
                findIt = new ObjWorkFlowDocuments();
                resultKey = new List<ObjDocumentos>();
                findIt = FindObjInCache(Objectsearch, out result);
                resultKey.AddRange(findIt.Todos);
                resultKey.AddRange(findIt.CopiaExternos);
                resultKey.AddRange(findIt.EnviadosInternos);
                resultKey.AddRange(findIt.EnviadosInternosCopia);
                resultKey.AddRange(findIt.EnSeguimiento);
                aux = resultKey;
                int num;
                bool isnumber = int.TryParse(Key, out num);
                if (isnumber)
                {
                    resultKey = aux.Where(x => x.RadicadoDetalle.ToUpper().Contains(Key) || x.NumeroDocumento.Contains(Key) || x.DependenciaNombre.ToUpper().Contains(Key) || x.ProcedenciaNombre.ToUpper().Contains(Key)).ToList();
                }
                else
                {
                    resultKey = aux.Where(x => x.NumeroDocumento.Contains(Key) || x.RadicadoDetalle.ToUpper().Contains(Key) || x.DependenciaNombre.ToUpper().Contains(Key) || x.ProcedenciaNombre.ToUpper().Contains(Key)).ToList();
                }
                return resultKey;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un List en dataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>


        public DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                Type propType = info.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propType = Nullable.GetUnderlyingType(propType);
                }
                dt.Columns.Add(new DataColumn(info.Name, propType));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    object colVal = info.GetValue(t, null);
                    if (colVal != null)
                    {
                        row[info.Name] = colVal.ToString();
                    }
                    else
                    {
                        row[info.Name] = DBNull.Value;
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public bool SaveObjectInCache(string name, List<ObjNaturaleza> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        public bool SaveObjectInCache(string name, List<ObjMedio> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }
        public bool SaveObjectInCache(string name, List<ObjExpediente> ob, out string result)
        {
            AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
            try
            {
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                objectCache.Add(name, ob, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
                result = "Objeto Agregado al cache correctamente";
                return true;
            }
            catch (Exception ex)
            {
                result = "Error al agregar el objeto al cache " + ex.Message;
                return false;
            }
        }

        public List<ObjNaturaleza> FindNaturalezasInCache(string name, out string result)
        {
            List<ObjNaturaleza> resultList = null;
            try
            {
                resultList = new List<ObjNaturaleza>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjNaturaleza>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        public List<ObjMedio> FindMediosInCache(string name, out string result)
        {
            List<ObjMedio> resultList = null;
            try
            {
                resultList = new List<ObjMedio>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjMedio>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        public List<ObjExpediente> FindExpedientesInCache(string name, out string result)
        {
            List<ObjExpediente> resultList = null;
            try
            {
                resultList = new List<ObjExpediente>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjExpediente>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }

        public List<ObjCiudad> FindCiudadesInCache(string name, out string result)
        {
            List<ObjCiudad> resultList = null;
            try
            {
                resultList = new List<ObjCiudad>();
                ICacheManager objectCache = CacheFactory.GetCacheManager();
                if (objectCache.Contains(name))
                {
                    resultList = (List<ObjCiudad>)objectCache[name];
                    result = string.Empty;
                    return resultList;
                }
                else
                {
                    result = "No se encontraron resultados en cache";
                    return null;
                }
            }
            catch (Exception)
            {
                result = "Error";
                return null;
            }
        }
        
    }
}
