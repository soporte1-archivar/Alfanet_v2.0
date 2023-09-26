using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.CommonObject;
using System.Data;
using System.Threading;
using System.Globalization;

namespace Alfanet.Dal
{
    public class QueryManager
    {

        //private Configuration config = null;
        //private List<ConfigData> data = null;

        public QueryManager(){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet selectAdminGrupo(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectAdminGrupo();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int insertAdminGrupo(ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    ObjGrupo obj = new ObjGrupo();
                    result = dal.insertAdminGrupo(obj);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet selectDocumentVenc(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectDocumentVenc();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Obtiene kos documentos del workflow de una dependencia
        /// </summary>
        /// <param name="config"></param>
        /// <param name="CodigoDependencia"></param>
        /// <returns></returns>
        public DataSet GetWorkFlowDocuments(ConfigData config, string CodigoDependencia)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectWorkFlow(CodigoDependencia);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Obtiene los parametros de deteminado grupo en la tabla alfa_parametros
        /// </summary>
        /// <param name="config"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public DataSet GetParametrosIniciales(ConfigData config, string grupo)
        {

            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.GetParametrosIniciales(grupo);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        ///  Obtiene todas las dependencias
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet GetDependencias(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectDependencias();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Cambia y trabaja un documento para asignarlo a otra dependencia
        /// </summary>
        /// <param name="document"></param>
        /// <param name="dependenciaDestino"></param>
        /// <param name="note"></param>
        /// <param name="dependenciaOrigen"></param>
        /// <param name="accion"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public int RedirectDocument(string document, string dependenciaDestino, string note, string dependenciaOrigen, string accion, ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.RedirectDocument(document, dependenciaDestino, note, dependenciaOrigen, accion);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene las acciones registradas en bd
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet GetAcciones(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectAcciones();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Obtiene las naturalezas registradas en base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet GetNaturalezas(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectNaturalezas();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// metodo para hace insercion masiva en la tabla facturas 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="datos"></param>
        /// <param name="result"></param>
        public void BulkInsertFacturas(ConfigData config, DataTable datos, out string result)
        {
            
            try
            {
                string result1 = null;
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    
                    dal.BulkInsertFacturas(datos, out result1);
                    result = result1;
                }
                else if (config.DataBaseEngine == 2)
                {
                    result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                result = result1;
            }
            catch (Exception)
            {
                result = "Error";
                throw;
            }
        }


        public string RadicacionMasivaUnoaUno(string UserID, string nomDep,string CodDep, ConfigData config, ObjFactura datos, out string result)
        {
            string result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");                
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    radicadoCodigo = dal.RadicacionMasivaUnoaUno(UserID,nomDep,CodDep,datos, out result1);                                       
                }
                else if (config.DataBaseEngine == 2)
                {
                    result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                result = result1; 
                return radicadoCodigo;
            }
            catch (Exception)
            {
                result = "ERROR";
                return radicadoCodigo;
            }
        }

        public ObjDocumentos RadicacionMasivaUnoaUno(string UserID, string nomDep, string CodDep, ConfigData config, ObjDocumentos datos, out string result)
        {
            string result1 = string.Empty;
            string radicadoCodigo = string.Empty;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    datos = dal.RadicacionMasivaUnoaUno(UserID, nomDep, CodDep, datos, out result1);   
                    ObjProcedencia Procedencia = ReturnProcedencia(datos.ProcedenciaNUI, config);
                    datos.ProcedenciaNombre = Procedencia.ProcedenciaNombre;
                    datos.Direccion = Procedencia.ProcedenciaDireccion;
                    datos.ProcedenciaNombre = Procedencia.ProcedenciaNombre;
                    DataSet data = new DataSet();
                    data = ObtenerDatosDependencia(datos.CodDestino, config);
                    ObjDependencia dependencia = new ObjDependencia();
                    dependencia.UserId = data.Tables[0].Rows[0]["UserId"].ToString();
                    dependencia.DependenciaNombre = data.Tables[0].Rows[0]["DependenciaNombre"].ToString();
                    datos.DependenciaDestino = dependencia.DependenciaNombre;
                }
                else if (config.DataBaseEngine == 2)
                {
                    result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                result = result1;

                return datos;
            }
            catch (Exception)
            {
                result = "ERROR";
                return datos = null;
            }
        }

        
        /// <summary>
        /// Obtiene los medios registrados en base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet GetMedios(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectMedios();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Obtiene todos los expedientes consignados en base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet GetExpedientes(ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.selectExpedientes();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida si una procedencia existe por codigo o nit en base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <param name="procedenciaNui"></param>
        /// <returns></returns>
        public bool ValidarProcedenciaNui(ConfigData config, string procedenciaNui)
        {
            bool solve = true;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    int result = dal.ValidarProcedenciaNui(procedenciaNui);
                    if (result == 1)
                    {
                        solve = true;
                    }
                    else
                    {
                        solve = false;
                    }

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return solve;

            }
            catch (Exception)
            {
                return false;  
                
                throw;
            }
            
        }
        /// <summary>
        /// obtiene y aumenta los consecutivos de un grupo 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="GrupoCodigo"></param>
        /// <returns></returns>
        public int ObtenerConsecutivos(ConfigData config, int GrupoCodigo)
        {
            int result = -1;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    return dal.ObtenerConsecutivos(GrupoCodigo);
                    
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;

            }
            catch (Exception)
            {
                return 0;

                throw;
            }
        }


        /// <summary>
        /// Devuelve los dias de vencimiento de una naturaleza
        /// </summary>
        /// <param name="config"></param>
        /// <param name="Naturaleza"></param>
        /// <returns></returns>
        public double ObtenerDiasVencimiento(ConfigData config, string Naturaleza)
        {
            double solve = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    solve = dal.ObtenerDiasVencimiento(Naturaleza);
                   

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return solve;

            }
            catch (Exception)
            {
                return 0;

                throw;
            }
        }
        /// <summary>
        /// Trae los datos de una dependencia
        /// </summary>
        /// <param name="Dependencia"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet ObtenerDatosDependencia(string Dependencia, ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.ObtenerDatosDependencia(Dependencia);


                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;

            }
            catch (Exception)
            {
              

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radInicial"></param>
        /// <param name="radFinal"></param>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public DataSet BuscarRadicados(string Radicador, string porImagen, long radInicial, long radFinal, string comEgresoIni, string comEgresoFin, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string numFacIni, string numFacFinal, string nombreNit, string detalle, string ubicacion, string modalidad, string unidad, string expediente, string ciudadInicial, string ciudadFinal, ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.BuscarRadicados(Radicador, porImagen, radInicial, radFinal, comEgresoIni, comEgresoFin, fechaInicial, fechaFinal, FacnReciboIni, FacnReciboFin, facValorMenor, facValorMayor, numFacIni, numFacFinal, nombreNit, detalle, ubicacion, modalidad, unidad, expediente, ciudadInicial, ciudadFinal);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Valida si el expendiente existe sino lo crea
        /// </summary>
        /// <param name="config"></param>
        /// <param name="Expediente"></param>
        /// <returns></returns>
        public bool ValidarExpediente(ConfigData config, string Expediente)
        {
            bool result = true;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.ValidarExpediente(Expediente);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SelectRutaCodigoFacturas(int year, int month, string path, ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.SelectRutaCodigoFacturas(year, month, path);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int InsertRegistroImagen(string grupoCodigo, string radicadoCodigo, string fileName, string rutaCodigo, ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.InsertRegistroImagen(grupoCodigo, radicadoCodigo, fileName, rutaCodigo);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
        /// <summary>
        /// Valida si el usuario tiene permisos de radicacion masiva y devuelve la serie en la que tiene permiso de insercion
        /// </summary>
        /// <param name="config"></param>
        /// <param name="Dependencia"></param>
        /// <returns></returns>
        public bool ValidarUsuarioPermitido(ConfigData config, string Dependencia)
        {
            bool solve = true;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    string result = dal.ValidarUsuarioPermitido(Dependencia);
                    if (result != "No")
                    {
                        solve = true;
                    }
                    else
                    {
                        solve = false;
                    }

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return solve;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }
        /// <summary>
        /// valida si un registro (facturas solamente) ya esta registrado en base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <param name="remision"></param>
        /// <param name="factura"></param>
        /// <returns></returns>
        public bool ValidarExistenciaUnica(ConfigData config, string factura, string NIT)
        {
            bool result = true;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.ValidarExistenciaUnica(factura, NIT);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo, ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.GetFacturaImagenById(GrupoCodigo, FacturaCodigo);


                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;

            }
            catch (Exception)
            {


                throw;
            }
        }

        public DataSet GetRutaImagenById(string ImagenRutaCodigo, ConfigData config)
        {
            DataSet result = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.GetRutaImagenById(ImagenRutaCodigo);


                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;

            }
            catch (Exception)
            {


                throw;
            }
        }

        public int UpdateDetalleRadicado(string codigo, string detalle, ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.UpdateDetalleRadicado(codigo, detalle);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public bool InsertComprobantesEgreso(string codigo, string compEgreso, ConfigData config)
        {
            bool result = false;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    int q = dal.InsertComprobantesEgreso(codigo, compEgreso);
                    if (q == 1)
                    {
                        result = true;
                    }
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public DataSet GetCiudades(ConfigData config)
        {
            DataSet ciudades = null;
            try
            {
                ciudades = new DataSet();
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    ciudades = dal.GetCiudades();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return ciudades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveLogError(ObjError Error, ConfigData config)
        {
            bool result = false;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    return dal.SaveLogError(Error, config);
                   
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public bool InsertRutaImagen(int ImagenRutaCodigo, string ImagenRutaDescripcion, int ImagenRutaAnio, int ImagenRutaMes, int ImagenRutaGrupo, string ImagenRutaPath, ConfigData config, out int RutaCodigo)
        {
            bool result = false;
            Int64 Cod = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    return dal.InsertRutaImagen( ImagenRutaCodigo,  ImagenRutaDescripcion,  ImagenRutaAnio,  ImagenRutaMes,  ImagenRutaGrupo,  ImagenRutaPath, out RutaCodigo);
                    Cod = RutaCodigo;
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                    RutaCodigo = -1;
                    
                }
                RutaCodigo = (int)Cod;
                return result;
            }
            catch (Exception)
            {
                RutaCodigo = -1;
                return result;
            }
        }

        public bool InsertFacturaImagen(int radicadoCodigo, string GrupoCodigo, string imagenNombre, int ImagenRutaCodigo, ConfigData config)
        {
            bool result = false;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    return dal.InsertFacturaImagen(radicadoCodigo, GrupoCodigo, imagenNombre, ImagenRutaCodigo);
                }
                if (config.DataBaseEngine == 2)
                {
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public int InsertFacturaImagen(string grupoCodigo, string radicadoCodigo, string fileName, string rutaCodigo, ConfigData config)
        {
            int result = 0;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.InsertFacturaImagen(grupoCodigo, radicadoCodigo, fileName, rutaCodigo);
                }
                else if (config.DataBaseEngine != 2)
                {
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public DataSet GetProcedencias(ConfigData config)
        {
            DataSet procedencias = null;
            try
            {
                procedencias = new DataSet();
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    procedencias = dal.GetProcedencias();
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return procedencias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarImagen(int FacturaCodigo, int FacturaImagenFolio, ConfigData config)
        {
            bool result = false;

            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    return dal.EliminarImagen(FacturaCodigo, FacturaImagenFolio);

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.


                }

                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }

        public DataSet ObtenerComprobantesEgresoAsociados(ConfigData config, string CodigoRadicado)
        {
            DataSet ComprobantesEgreso = null;
            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    ComprobantesEgreso = dal.ObtenerComprobantesEgresoAsociados(CodigoRadicado);

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.


                }

                return ComprobantesEgreso;
            }
            catch (Exception)
            {
                ComprobantesEgreso = null;
                return ComprobantesEgreso;
            }
        }

        public DataSet GetInfoRadPadre(ConfigData config, string RadicadoCodigo)
        {
            DataSet padreInfo = null;
            try
            {
                padreInfo = new DataSet();
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    padreInfo = dal.GetInfoRadPadre(RadicadoCodigo);
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return padreInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObjDocumentos RegistroMasivoUnoaUno(string UserID, string nomDep, string Dependencia, ConfigData config, ObjDocumentos item, out string result)
        {
            string result1 = string.Empty;
            string radicadoCodigo = string.Empty;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    item = dal.RegistroMasivoUnoaUno(UserID, nomDep, Dependencia, item, out result1);
                }
                else if (config.DataBaseEngine == 2)
                {
                    result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                result = result1;

                return item;
            }
            catch (Exception)
            {
                result = "ERROR";
                return item = null;
            }
        }

        public ObjDocumentos RegistroResolucionesMasivoUnoaUno(string UserID, string nomDep, string Dependencia, ConfigData config, ObjDocumentos item, out string result)
        {
            string result1 = string.Empty;
            string radicadoCodigo = string.Empty;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    item = dal.RegistroResolucionesMasivoUnoaUno(UserID, nomDep, Dependencia, item, out result1);
                }
                else if (config.DataBaseEngine == 2)
                {
                    result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                result = result1;

                return item;
            }
            catch (Exception)
            {
                result = "ERROR";
                return item = null;
            }
        }

        public ObjProcedencia ReturnProcedencia(string ProcedenciaNUI, ConfigData config)
        {
            string result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            ObjProcedencia result = new ObjProcedencia();

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    DataSet data = dal.ReturnProcedencia(ProcedenciaNUI);
                    foreach (DataRow item in data.Tables[0].Rows)
                    {
                        result.CiudadNombre = item["CiudadNombre"].ToString();
                        result.ProcedenciaCodigo = ProcedenciaNUI;
                        result.ProcedenciaNombre = item["ProcedenciaNombre"].ToString();
                        result.ProcedenciaDireccion = item["ProcedenciaDireccion"].ToString();
                        
                    }
                }
                else if (config.DataBaseEngine == 2)
                {                    
                    //result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception ex)
            {
                
                ObjError objectsError = new ObjError();
                objectsError.MessegeError = ex.Message;
                objectsError.StackTrace = ex.StackTrace;
                objectsError.ErrorCode = ex.Source;
                SqlServerDal dal = new SqlServerDal();
                dal.SaveLogError(objectsError, config);
                return result; 
            }
        }

        public List<ObjDocumentos> GetPendingDocuments(ConfigData config, string dependenciaCodigo)
        {
            List<ObjDocumentos> listDocumentsPending = null;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    DataSet data = dal.GetPendingDocuments(dependenciaCodigo);
                    listDocumentsPending = new List<ObjDocumentos>();
                    ObjDocumentos document = null;
                    foreach (DataRow dr in data.Tables[0].Rows)
                    {
                        document = new ObjDocumentos();
                        document.NumeroDocumento = dr["NumeroDocumento"].ToString();
                        document.ProcedenciaNombre = dr["Procedencia"].ToString();
                        document.WfmovimientoFecha = dr["WFMovimientoFecha"].ToString();
                        document.DependenciaNombre = dr["DependenciaNomOrigen"].ToString();
                        document.GrupoCodigo = dr["GrupoCodigo"].ToString();
                        listDocumentsPending.Add(document);
                        //document = null;
                    }
                }
                else if (config.DataBaseEngine == 2)
                {
                    //result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                return listDocumentsPending;
            }
            catch (Exception ex)
            {

                ObjError objectsError = new ObjError();
                objectsError.MessegeError = ex.Message;
                objectsError.StackTrace = ex.StackTrace;
                objectsError.ErrorCode = ex.Source;
                SqlServerDal dal = new SqlServerDal();
                dal.SaveLogError(objectsError, config);
                return listDocumentsPending;
            }
        }

        public bool DocumentAccepted(ConfigData config, string numeroDocumento, string grupoCodigo)
        {
            bool result = false;

            try
            {
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.DocumentAccepted(numeroDocumento, grupoCodigo);

                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.


                }

                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }

        public ObjDocumentos GetDocumentoInfo(ConfigData config, string numeroDocumento, string grupo)
        {
            ObjDocumentos document = null;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    DataSet data = dal.GetDocumentoInfo(numeroDocumento);
                    document = new ObjDocumentos();                                        
                    document.NumeroDocumento = data.Tables[0].Rows[0]["NumeroDocumento"].ToString();
                    document.WfmovimientoFecha = data.Tables[0].Rows[0]["WFMovimientoFecha"].ToString();
                    document.DependenciaNombre = data.Tables[0].Rows[0]["DependenciaNomOrigen"].ToString();
                    document.GrupoCodigo = data.Tables[0].Rows[0]["GrupoCodigo"].ToString();
                    
                }
                else if (config.DataBaseEngine == 2)
                {
                    //result = "Oracle";
                    //llamado al mismo metodo en oracle.
                }
                return document;
            }
            catch (Exception ex)
            {

                ObjError objectsError = new ObjError();
                objectsError.MessegeError = ex.Message;
                objectsError.StackTrace = ex.StackTrace;
                objectsError.ErrorCode = ex.Source;
                SqlServerDal dal = new SqlServerDal();
                dal.SaveLogError(objectsError, config);
                return document;
            }
           
        }

        public DataSet GetReceivedDocuments(DateTime fechaIni, DateTime fechaFin, string dependencia, ConfigData config)
        {
            DataSet result = null;
            try
            {
                result = new DataSet();
                if (config.DataBaseEngine == 1)
                {
                    SqlServerDal dal = new SqlServerDal();
                    result = dal.GetReceivedDocuments(fechaIni, fechaFin, dependencia);
                    return result;
                }
                else if (config.DataBaseEngine == 2)
                {
                    //llamado al mismo metodo en oracle.
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
