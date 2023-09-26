using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.ConnectionManager;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Alfanet.CommonObject;
using System.Data;
using Alfanet.CommonLibrary;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;


namespace Alfanet.Dal
{
	public class SqlServerDal
	{
        //CRUD SQL SERVER.
		public DataSet selectAdminGrupo()
		{
			string query = "select GrupoCodigo,GrupoNombre,GrupoCodigoPadre,GrupoConsecutivo,GrupoHabilitar,Grupopermiso "
							+ "from grupo";
							
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				DataSet ds = new DataSet();
				using (DbCommand dbCommand = db.GetSqlStringCommand(query))
				{
					try
					{
						ds = db.ExecuteDataSet(dbCommand);
						return ds;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int insertAdminGrupo(ObjGrupo grupo)
		{
			string query = "insert into grupo"
							+ "(GrupoCodigo,GrupoNombre,GrupoCodigoPadre,GrupoConsecutivo,GrupoHabilitar,Grupopermiso)"
							+ "values ( '"
							+ grupo.GrupoCodigo + "',"
							+ grupo.GrupoNombre + ","
							+ grupo.GrupoCodigoPadre + ","
							+ grupo.GrupoConsecutivo + ","
							+ grupo.GrupoHabilitar + ","
							+ grupo.Grupopermiso + ")";
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				using (DbCommand dbCommand = db.GetSqlStringCommand(query))
				{
					try
					{
						int data = db.ExecuteNonQuery(dbCommand);
						return data;
					}
					catch (Exception)
					{
						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int updateAdminGrupo(ObjGrupo grupo, int grupoCodigo)
		{
			string query = "update grupo set "
							+ "grupoCodigo ='" + grupo.GrupoCodigo + "',"
							+ "grupoNombre=" + grupo.GrupoNombre + ","
							+ "grupoCodigoPadre=" + grupo.GrupoCodigoPadre + ","
							+ "grupoConsecutivo=" + grupo.GrupoConsecutivo + ","
							+ "grupoHabilitar=" + grupo.GrupoHabilitar + ","
							+ "grupopermiso=" + grupo.Grupopermiso
							+ " where grupoCodigo = " + grupoCodigo;
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				using (DbCommand dbCommand = db.GetSqlStringCommand(query))
				{
					try
					{
						int data = db.ExecuteNonQuery(dbCommand);
						return data;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int deleteAdminGrupo(int grupoCodigo)
		{
			string query = "delete from grupo where grupoCodigo = " + grupoCodigo;

			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				using (DbCommand dbCommand = db.GetSqlStringCommand(query))
				{
					try
					{
						int data = db.ExecuteNonQuery(dbCommand);
						return data;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataSet selectDocumentVenc()
		{
			string query = "SELECT WFMovimientos.NumeroDocumento, WFMovimientos.DependenciaCodDestino, WFMovimientos.WFMovimientoPaso, "
								   +"WFMovimientos.WFMovimientoTipo, WFMovimientos.GrupoCodigo, Grupo.GrupoNombre, Procedencia.ProcedenciaNombre, "
								   +"Procedencia.ProcedenciaNUI,Radicado.NaturalezaCodigo,Radicado.MedioCodigo,Radicado.RadicadoFechaVencimiento, "
								   +"Dependencia.DependenciaNombre, WFMovimientos.WFMovimientoNotas, WFAccion.WFAccionNombre, Radicado.RadicadoDetalle, "
								   +"Naturaleza.NaturalezaNombre,Count(Registrocodigo) as Respuesta "
							+"FROM Radicado "
								+"INNER JOIN WFMovimientos ON Radicado.RadicadoCodigo = WFMovimientos.NumeroDocumento AND Radicado.GrupoCodigo = WFMovimientos.GrupoCodigo "
								+"Left Outer JOIN Procedencia ON Radicado.ProcedenciaCodigo = Procedencia.ProcedenciaNUI "
								+"Left outer join RadicadoFuente ON WFMovimientos.NumeroDocumento = RadicadoFuente.RadicadoCodigoFuente "
								+"Left Outer JOIN WFAccion ON WFMovimientos.WFAccionCodigo = WFAccion.WFAccionCodigo "
								+"Left Outer JOIN Dependencia ON WFMovimientos.DependenciaCodOrigen = Dependencia.DependenciaCodigo "
								+"Left Outer Join Naturaleza ON Radicado.NaturalezaCodigo = Naturaleza.NaturalezaCodigo "
								+"Left Outer JOIN Grupo ON Radicado.GrupoCodigo = Grupo.GrupoCodigo "
							+"WHERE (WFMovimientos.WFMovimientoPasoActual = '1') "
								+"AND (WFMovimientos.WFMovimientoPasoFinal = '0') "
								+"AND ((WFMovimientos.WFMovimientoTipo = '1') "
								+"OR (WFMovimientos.WFMovimientoTipo = '4')) "
								+ "AND (WFMovimientos.DependenciaCodDestino = '01.38') "
							+"GROUP BY WFMovimientos.NumeroDocumento,WFMovimientos.DependenciaCodDestino,WFMovimientos.WFMovimientoPaso,WFMovimientos.WFMovimientoTipo, "
								+"WFMovimientos.GrupoCodigo,Grupo.GrupoNombre,Procedencia.ProcedenciaNombre,Procedencia.ProcedenciaNUI,Radicado.NaturalezaCodigo, "
								+"Radicado.MedioCodigo,Radicado.RadicadoFechaVencimiento,Dependencia.DependenciaNombre, WFMovimientos.WFMovimientoNotas, "
								+"WFAccion.WFAccionNombre, Radicado.RadicadoDetalle,Naturaleza.NaturalezaNombre "
							+"order by NumeroDocumento DESC";

			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				DataSet ds = new DataSet();
				using (DbCommand dbCommand = db.GetSqlStringCommand(query))
				{
					try
					{
						ds = db.ExecuteDataSet(dbCommand);
						return ds;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public DataSet selectWorkFlow(string CodigoDependencia)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("radicado_obtenerWF_av2"))
                {
                    try
                    {
                        db.AddInParameter(dbCommand, "CodigoDependencia", DbType.String, CodigoDependencia);
                        ds = db.ExecuteDataSet(dbCommand);
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public DataSet selectDependencias()
		{  
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				DataSet ds = new DataSet();
				using (DbCommand dbCommand = db.GetStoredProcCommand("dependencia_obtenerdependencias_av2"))
				{
					try
					{
						ds = db.ExecuteDataSet(dbCommand);
						return ds;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        /// <summary>
        /// Redirecciona un documento de un usuario hacia otro.
        /// </summary>
        /// <param name="document">Número del documento que se va a enviar</param>
        /// <param name="dependenciaDestino">Código de la dependencia a la que se le va a enviar el documento</param>
        /// <param name="note">Post it o nota que el usuario le agregó al documento</param>
        /// <param name="dependenciaOrigen">Código de la dependencia que esta enviando el documento</param>
        /// <param name="accion">Código de la acción indicada por el usuario</param>
        /// <returns>int con el número de filas afectadas en la ejecución de la consulta</returns>
		internal int RedirectDocument(string document, string dependenciaDestino, string note, string dependenciaOrigen, string accion)
		{
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();

                using (DbCommand dbCommand = db.GetStoredProcCommand("wfmovimiento_redireccionardocumento_av2"))
                {
                    try
                    {
                        db.AddInParameter(dbCommand, "NumeroDocumento", DbType.Int32, document);
                        db.AddInParameter(dbCommand, "DependenciaCodDestino", DbType.String, dependenciaDestino);
                        db.AddInParameter(dbCommand, "WFMovimientoNotas", DbType.String, note);
                        db.AddInParameter(dbCommand, "DependenciaCodOrigen", DbType.String, dependenciaOrigen);
                        db.AddInParameter(dbCommand, "WFAccionCodigo", DbType.String, accion);
                        int result = db.ExecuteNonQuery(dbCommand);
                        return result;
                    }
                    catch (Exception ex)
                    {                        
                        throw ex;
                    }
                }
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		internal DataSet selectAcciones()
		{
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				DataSet ds = new DataSet();
				using (DbCommand dbCommand = db.GetStoredProcCommand("accion_obteneracciones_av2"))
				{
					try
					{
						ds = db.ExecuteDataSet(dbCommand);

						return ds;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Realiza el Bulk Insert  en la Tabla Facturas
        /// </summary>
        /// <returns></returns>

        public void BulkInsertFacturas(DataTable Datos, out string result)
        {




            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();

                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    //blah blah

                    //we use SqlBulkCopy that is not in the Microsoft Data Access Layer Block.
                    using (SqlBulkCopy copy = new SqlBulkCopy((SqlConnection) connection, SqlBulkCopyOptions.Default, null))
                    {
                       copy.DestinationTableName = "Facturas";
                        DataTable table = new DataTable();
                        result = "OK";
                        copy.WriteToServer(Datos);


                    }
                }

                //using (DbCommand dbCommand = db.GetStoredProcCommand("dependencia_obtenerdependencias_av2"))
                //{
                //    //try
                //    //{
                //    //    ds = db.ExecuteDataSet(dbCommand);
                //    //    return ds;
                //    //}
                //    //catch (Exception ex)
                //    //{
                //    //    throw ex;
                //    //}
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Realiza consultas a la tabla parametros
        /// </summary>
        /// <returns></returns>

        public DataSet GetParametrosIniciales(string grupoCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("alfa_parametros_consulta_av2"))
                {
                    try
                    {
                        db.AddInParameter(dbCommand, "grupo", DbType.Int32, int.Parse(grupoCodigo));
                        ds = db.ExecuteDataSet(dbCommand);
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet selectNaturalezas()
        {             
			SqlServerConnection conn = null;
			try
			{
				conn = new SqlServerConnection();
				Database db = conn.openConnection();
				DataSet ds = new DataSet();
				using (DbCommand dbCommand = db.GetStoredProcCommand("naturaleza_obtenernaturalezas_av2"))
				{
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
			}
			catch (Exception ex)
			{
				throw ex;
			}		
        }

        internal DataSet selectMedios()
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("medio_obtenermedios_av2"))
                {
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataSet selectExpedientes()
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("expediente_obtenerexpedientes_av2"))
                {
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ValidarProcedenciaNui(string procedenciaNui)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("procedencias_validarprocedencianui_av2"))
                {
                    db.AddInParameter(dbCommand, "procedencianui", DbType.String, procedenciaNui);                    
                    db.AddOutParameter(dbCommand, "existe", DbType.Int16, 50);
                    ds = db.ExecuteDataSet(dbCommand);
                    int resp = int.Parse(db.GetParameterValue(dbCommand, "existe").ToString());
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string RadicacionMasivaUnoaUno(string UserID, string nomDep, string CodDep, ObjFactura item, out string result1)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturas_radicarfacturas_av2"))
                {                        
                    db.AddInParameter(dbCommand, "RadicadoCodigo ", DbType.String, item.RadicadoCodigo);
                    db.AddInParameter(dbCommand, "GrupoCodigo ", DbType.String, item.GrupoCodigo);
                    db.AddInParameter(dbCommand, "WFMovimientoFecha ", DbType.DateTime, item.WFMovimientoFecha);
                    db.AddInParameter(dbCommand, "FechaProcedencia ", DbType.DateTime, item.FechaProcedencia );
                    db.AddInParameter(dbCommand, "procedenciaNUI ", DbType.String, item.ProcedenciaNUI);
                    db.AddInParameter(dbCommand, "NaturalezaCodigo ", DbType.String, item.NaturalezaCodigo);
                    db.AddInParameter(dbCommand, "DependenciaCodigo ", DbType.String, CodDep);
                    db.AddInParameter(dbCommand, "Detalle ", DbType.String, item.Detalle);
                    db.AddInParameter(dbCommand, "FechaVencimiento ", DbType.DateTime, item.FechaVencimiento);
                    db.AddInParameter(dbCommand, "ExpedienteCodigo ", DbType.String, item.ExpedienteCodigo);
                    db.AddInParameter(dbCommand, "MedioCodigo ", DbType.String, item.MedioCodigo);
                    db.AddInParameter(dbCommand, "DependenciaCodDestino ", DbType.String, item.DependenciaCodDestino);
                    db.AddInParameter(dbCommand, "Anexo ", DbType.String, item.Anexo);
                    db.AddInParameter(dbCommand, "FechaRadicacion ", DbType.DateTime, item.FechaRadicacion );
                    db.AddInParameter(dbCommand, "HoraRadicacion ", DbType.DateTime, item.FechaRadicacion);
                    db.AddInParameter(dbCommand, "UserId ", DbType.String, UserID);
                    db.AddInParameter(dbCommand, "DependenciaNomDestino ", DbType.String, item.DependenciaNomDestino);
                    db.AddInParameter(dbCommand, "DependenciaNombre ", DbType.String, nomDep);
                    db.AddInParameter(dbCommand, "UserIdAud ", DbType.String, item.UserIdAud);
                    db.AddInParameter(dbCommand, "facn_numero ", DbType.String, item.Facn_numero);
                    db.AddInParameter(dbCommand, "facn_empresa ", DbType.String, item.Facn_empresa);
                    db.AddInParameter(dbCommand, "facc_documento ", DbType.String, item.Facc_documento);
                    db.AddInParameter(dbCommand, "facn_ubicacion ", DbType.String, item.Facn_ubicacion);
                    db.AddInParameter(dbCommand, "facv_total ", DbType.String, item.Facv_total);
                    db.AddInParameter(dbCommand, "facc_estado ", DbType.String, item.Facc_estado);
                    db.AddInParameter(dbCommand, "facc_prefijo ", DbType.String, item.Facc_prefijo);
                    db.AddInParameter(dbCommand, "facn_factura2 ", DbType.String, item.Facn_factura2);
                    db.AddInParameter(dbCommand, "facc_factura ", DbType.String, item.Facc_factura);
                    db.AddInParameter(dbCommand, "facc_alto_costo ", DbType.String, item.Facc_alto_costo);
                    db.AddInParameter(dbCommand, "terc_nombre ", DbType.String, item.Terc_nombre);
                    db.AddInParameter(dbCommand, "facf_confirmacion ", DbType.DateTime, item.Facf_confirmacion);
                    db.AddInParameter(dbCommand, "facn_recibo ", DbType.String, item.Facn_recibo);
                    db.AddInParameter(dbCommand, "facv_copago ", DbType.String, item.Facv_copago);
                    db.AddInParameter(dbCommand, "facv_responsable ", DbType.String, item.Facv_responsable);
                    db.AddInParameter(dbCommand, "facc_conciliado ", DbType.String, item.Facc_conciliado);
                    db.AddInParameter(dbCommand, "facv_imputable ", DbType.String, item.Facv_imputable);                        
                    db.AddInParameter(dbCommand, "facf_radicado ", DbType.DateTime, item.Facf_radicado);
                    db.AddInParameter(dbCommand, "facf_final ", DbType.DateTime, item.Facf_final);
                    //db.AddInParameter(dbCommand, "facc_digitalizado ", DbType.String, item.Facc_digitalizado);
                    db.AddInParameter(dbCommand, "facc_almacenamiento ", DbType.String, item.Facc_almacenamiento);
                    db.AddInParameter(dbCommand, "cntc_concepto ", DbType.String, item.Cntc_concepto);
                    db.AddInParameter(dbCommand, "conc_nombre ", DbType.String, item.Conc_nombre);
                    db.AddInParameter(dbCommand, "facv_tercero ", DbType.String, item.Facv_tercero);
                    db.AddInParameter(dbCommand, "serie ", DbType.String, item.Serie);
                    db.AddOutParameter(dbCommand, "radicadoCodigoOut", DbType.String, 20);                    
                    ds = db.ExecuteDataSet(dbCommand);
                    radicadoCodigo = db.GetParameterValue(dbCommand, "@radicadoCodigoOut").ToString();                   
                    result1 = "OK";
                    return radicadoCodigo;
                }
            }
            catch (Exception)
            {
                result1 = "ERROR";                
                return radicadoCodigo;
            }
        }


        internal ObjDocumentos RadicacionMasivaUnoaUno(string UserID, string nomDep, string CodDep, ObjDocumentos item, out string result1)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            SqlServerConnection conn = null;
            try
            {              
		
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Radicado_CreateRadicado_RadicadMasivo"))
                {
                    db.AddInParameter(dbCommand, "GrupoCodigo ", DbType.String, item.GrupoCodigo);
                    db.AddInParameter(dbCommand, "WFMovimientoFecha ", DbType.DateTime, DateTime.Parse(item.WfmovimientoFecha));
                    db.AddInParameter(dbCommand, "RadicadoFechaProcedencia ", DbType.DateTime, DateTime.Parse(item.FechaProcedencia));
                    db.AddInParameter(dbCommand, "ProcedenciaCodigo ", DbType.String, item.ProcedenciaNUI);
                    db.AddInParameter(dbCommand, "RadicadoNumeroExterno ", DbType.String, item.NumeroExterno);
                    db.AddInParameter(dbCommand, "NaturalezaCodigo ", DbType.String, item.NaturalezaCodigo);
                    db.AddInParameter(dbCommand, "DependenciaCodigo ", DbType.String, CodDep);
                    db.AddInParameter(dbCommand, "RadicadoDetalle ", DbType.String, item.RadicadoDetalle);
                    db.AddInParameter(dbCommand, "RadicadoAnexo ", DbType.String, item.Anexo);
                    db.AddInParameter(dbCommand, "RadicadoFechaVencimiento ", DbType.DateTime,  item.FechaVencimiento == null ? DateTime.Now :DateTime.Parse(item.FechaVencimiento));
                    db.AddInParameter(dbCommand, "ExpedienteCodigo ", DbType.String, item.ExpedienteCodigo);
                    db.AddInParameter(dbCommand, "MedioCodigo ", DbType.String, item.MedioCodigo);
                    db.AddInParameter(dbCommand, "DependenciaCodDestino ", DbType.String, item.CodDestino);
                    db.AddInParameter(dbCommand, "SerieCodigo ", DbType.String, item.SerieCodigo);
                    db.AddInParameter(dbCommand, "RadicadoPadre ", DbType.String, item.RadicadoPadre);
                    db.AddInParameter(dbCommand, "FechaImposicion ", DbType.String, item.FechaImposicion);
                    db.AddInParameter(dbCommand, "PlacaVehiculo ", DbType.String, item.PlacaVehiculo);
                    db.AddInParameter(dbCommand, "CodInfraccion ", DbType.String, item.CodInfraccion);
                    db.AddInParameter(dbCommand, "Observaciones ", DbType.String, item.Observaciones);
                    db.AddInParameter(dbCommand, "Anexos ", DbType.String, item.Anexo);
                    db.AddInParameter(dbCommand, "MedioRecepcion ", DbType.String, item.MedioCodigo);                                                          
                    db.AddInParameter(dbCommand, "IUIT ", DbType.String, item.Iuit);
                    db.AddInParameter(dbCommand, "UserId ", DbType.String, UserID);                 
                    db.AddOutParameter(dbCommand, "radicadoCodigo", DbType.Int64, 20);

                    


                    ds = db.ExecuteDataSet(dbCommand);
                    radicadoCodigo = db.GetParameterValue(dbCommand, "radicadoCodigo").ToString();
                    item.NumeroDocumento = radicadoCodigo;                    
                    result1 = "OK";
                    return item;
                }
            }
            catch (Exception)
            {
                result1 = "ERROR";
                return item = null;
            }
        }

        internal int ObtenerConsecutivos(int GrupoCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("grupo_obtenernumeroconsecutivogrupo_av2"))
                {
                    db.AddInParameter(dbCommand, "GrupoCodigo", DbType.Int32, GrupoCodigo);
                    db.AddOutParameter(dbCommand, "Consecutivo", DbType.Int32, 50);
                    ds = db.ExecuteDataSet(dbCommand);
                    int resp = int.Parse(db.GetParameterValue(dbCommand, "Consecutivo").ToString());
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataSet BuscarRadicados(string Radicador,string porImagen, long radInicial, long radFinal, string comEgresoIni, string comEgresoFin, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string numFacIni, string numFacFinal, string nombreNit, string detalle, string ubicacion, string modalidad, string unidad, string expediente, string ciudadInicial, string ciudadFinal)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("consultas_radicacionmasiva_av2"))
                {
                    db.AddInParameter(dbCommand, "Radicador", DbType.String, Radicador);
                    db.AddInParameter(dbCommand, "porImagen", DbType.String, porImagen);
                    db.AddInParameter(dbCommand, "radinicial", DbType.String, radInicial);
                    db.AddInParameter(dbCommand, "radfinal", DbType.String, radFinal);
                    db.AddInParameter(dbCommand, "numEgreIni", DbType.String, comEgresoIni);
                    db.AddInParameter(dbCommand, "numEgreFin", DbType.String, comEgresoFin);
                    db.AddInParameter(dbCommand, "fechainicial", DbType.String, fechaInicial);
                    db.AddInParameter(dbCommand, "fechafinal", DbType.String, fechaFinal);
                    db.AddInParameter(dbCommand, "FacnReciboIni", DbType.String, FacnReciboIni);
                    db.AddInParameter(dbCommand, "FacnReciboFin", DbType.String, FacnReciboFin);
                    db.AddInParameter(dbCommand, "facValorMenor", DbType.String, facValorMenor);
                    db.AddInParameter(dbCommand, "facValorMayor", DbType.String, facValorMayor);
                    db.AddInParameter(dbCommand, "numFacIni", DbType.String, numFacIni);
                    db.AddInParameter(dbCommand, "numFacFinal", DbType.String, numFacFinal);
                    db.AddInParameter(dbCommand, "detalle", DbType.String, detalle);
                    db.AddInParameter(dbCommand, "nombreoNit", DbType.String, nombreNit);
                    db.AddInParameter(dbCommand, "unidad", DbType.String, unidad);
                    db.AddInParameter(dbCommand, "ubicacion", DbType.String, ubicacion);
                    db.AddInParameter(dbCommand, "modalidad", DbType.String, modalidad);
                    db.AddInParameter(dbCommand, "expediente", DbType.String, expediente);
                    db.AddInParameter(dbCommand, "ciudadinicial", DbType.String, ciudadInicial);
                    db.AddInParameter(dbCommand, "ciudadfinal", DbType.String, ciudadFinal);
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal double ObtenerDiasVencimiento(string Naturaleza)
        {
            
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("naturaleza_ObtenerDiasVencimiento_av2"))
                {
                    db.AddInParameter(dbCommand, "NaturalezaCodigo", DbType.Int32, Naturaleza);
                    db.AddOutParameter(dbCommand, "DiasVence", DbType.Int32, 50);
                    ds = db.ExecuteDataSet(dbCommand);
                    double resp = double.Parse(db.GetParameterValue(dbCommand, "DiasVence").ToString());
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataSet ObtenerDatosDependencia(string Dependencia)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("usuariosxdependencia_ObtenerUserID_av2"))
                {
                    db.AddInParameter(dbCommand, "CodigoDependencia", DbType.String, Dependencia);                    
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool ValidarExpediente(string Expediente)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();

                using (DbCommand dbCommand = db.GetStoredProcCommand("expediente_validarExpediente_av2"))
                {
                    db.AddInParameter(dbCommand, "ExpedienteCodigo", DbType.String, Expediente);
                    db.AddOutParameter(dbCommand, "Result", DbType.Int32, 50);
                    db.ExecuteDataSet(dbCommand);
                    int resp = int.Parse(db.GetParameterValue(dbCommand, "Result").ToString());
                    if (resp==1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string ValidarUsuarioPermitido(string Dependencia)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();                
                using (DbCommand dbCommand = db.GetStoredProcCommand("usuariosradicacionmasiva_validarusuario_av2"))
                {
                    db.AddInParameter(dbCommand, "CodigoDependencia", DbType.String, Dependencia);
                    db.AddOutParameter(dbCommand, "SerieCodigo", DbType.String, 50);
                    db.ExecuteDataSet(dbCommand);
                    string resp = db.GetParameterValue(dbCommand, "SerieCodigo").ToString();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool ValidarExistenciaUnica(string factura, string NIT)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();

                using (DbCommand dbCommand = db.GetStoredProcCommand("factura_validarexistenciaunica_av2"))
                {                    
                    db.AddInParameter(dbCommand, "factura", DbType.String, factura);
                    db.AddInParameter(dbCommand, "NIT", DbType.String, NIT);
                    db.AddOutParameter(dbCommand, "Result", DbType.Int32, 50);
                    db.ExecuteDataSet(dbCommand);
                    int resp = int.Parse(db.GetParameterValue(dbCommand, "Result").ToString());
                    if (resp == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
 
            }
        }

        internal int SelectRutaCodigoFacturas(int year, int month, string path)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("imagenruta_getimagenrutacodigo_av2"))
                {
                    db.AddInParameter(dbCommand, "year", DbType.Int32, year);
                    db.AddInParameter(dbCommand, "month", DbType.Int32, month);
                    db.AddInParameter(dbCommand, "path", DbType.String, path);
                    db.AddOutParameter(dbCommand, "rutaCodigo", DbType.Int32, 8);
                    db.ExecuteNonQuery(dbCommand);
                    return Convert.ToInt32(db.GetParameterValue(dbCommand, "@rutaCodigo").ToString());                     
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal int InsertFacturaImagen(string grupoCodigo, string radicadoCodigo, string fileName, string rutaCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturaimagen_createfacturaimagen_av2"))
                {
                    db.AddInParameter(dbCommand, "GrupoCodigo", DbType.String, grupoCodigo);
                    db.AddInParameter(dbCommand, "radicadoCodigo", DbType.Int64, radicadoCodigo);
                    db.AddInParameter(dbCommand, "imagenNombre", DbType.String, fileName);
                    db.AddInParameter(dbCommand, "ImagenRutaCodigo", DbType.Int32, rutaCodigo);
                    return db.ExecuteNonQuery(dbCommand);                     
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal DataSet GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo)
        {
             SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturaImagen_selectById_av2"))
                {
                    db.AddInParameter(dbCommand, "GrupoFacturaCodigo", DbType.String, GrupoCodigo);
                    db.AddInParameter(dbCommand, "FacturaCodigoCodigo", DbType.String, FacturaCodigo); 
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal DataSet GetRutaImagenById(string ImagenRutaCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("ImagenRuta_SelectById"))
                {
                    db.AddInParameter(dbCommand, "ImagenRutaCodigo", DbType.String, ImagenRutaCodigo);                   
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateDetalleRadicado(string codigo, string detalle)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();                
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturas_updatedetalle_av2"))
                {
                    db.AddInParameter(dbCommand, "codigofactura", DbType.Int64, codigo);
                    db.AddInParameter(dbCommand, "detalle", DbType.String, detalle);
                    return db.ExecuteNonQuery(dbCommand);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertComprobantesEgreso(string codigo, string compEgreso)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturas_insertcomprobante_egreso_av2"))
                {
                    db.AddInParameter(dbCommand, "codigofactura", DbType.Int64, codigo);
                    db.AddInParameter(dbCommand, "comprobante", DbType.String, compEgreso);
                    db.AddOutParameter(dbCommand, "salida", DbType.Int32, 8);
                    db.ExecuteNonQuery(dbCommand);
                    return Convert.ToInt32(db.GetParameterValue(dbCommand, "@salida").ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataSet GetCiudades()
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("ciudad_getciudades_av2"))
                {                    
                  return db.ExecuteDataSet(dbCommand);           
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool SaveLogError(ObjError Error, ConfigData config)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("logError_registraLog_av2"))
                {
                    db.AddInParameter(dbCommand, "strackTrace", DbType.String, Error.StackTrace);
                    db.AddInParameter(dbCommand, "errorCode", DbType.String, Error.ErrorCode);
                    db.AddInParameter(dbCommand, "MessegeError", DbType.String, Error.MessegeError);                   
                    db.ExecuteNonQuery(dbCommand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }

        internal DataSet GetProcedencias()
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("procedencia_getprocedencias_av2"))
                {
                    return db.ExecuteDataSet(dbCommand);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool InsertRutaImagen(int ImagenRutaCodigo, string ImagenRutaDescripcion, int ImagenRutaAnio, int ImagenRutaMes, int ImagenRutaGrupo, string ImagenRutaPath, out int RutaCodigo)
        {
           SqlServerConnection conn = null;
            try
            {
                bool salida;
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("ImagenRuta_Insert"))
                {
                    db.AddInParameter(dbCommand, "ImagenRutaCodigo", DbType.Int64, ImagenRutaCodigo);
                    db.AddInParameter(dbCommand, "ImagenRutaDescripcion", DbType.String, ImagenRutaDescripcion);
                    db.AddInParameter(dbCommand, "ImagenRutaAnio", DbType.Int64, ImagenRutaAnio);
                    db.AddInParameter(dbCommand, "ImagenRutaMes", DbType.Int64, ImagenRutaMes);
                    db.AddInParameter(dbCommand, "ImagenRutaGrupo", DbType.Int64, ImagenRutaGrupo);
                    db.AddInParameter(dbCommand, "ImagenRutaPath", DbType.String, ImagenRutaPath);    
                    ds = db.ExecuteDataSet(dbCommand);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        RutaCodigo = int.Parse(ds.Tables[0].Rows[0]["ImagenRutaCodigo"].ToString());
                        salida = true;
                    }
                    else 
                    {
                        RutaCodigo = -1;
                        salida = false;
                    }
                    return salida;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool InsertFacturaImagen(int radicadoCodigo, string GrupoCodigo, string imagenNombre, int ImagenRutaCodigo)
        {
            SqlServerConnection conn = null;
            try
            {                
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturaimagen_createfacturaimagen_av2"))
                {
                    db.AddInParameter(dbCommand, "radicadoCodigo", DbType.Int64, radicadoCodigo);
                    db.AddInParameter(dbCommand, "GrupoCodigo", DbType.String, GrupoCodigo);
                    db.AddInParameter(dbCommand, "imagenNombre", DbType.String, imagenNombre);
                    db.AddInParameter(dbCommand, "ImagenRutaCodigo", DbType.Int64, ImagenRutaCodigo);                    
                    ds = db.ExecuteDataSet(dbCommand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal bool EliminarImagen(int FacturaCodigo, int FacturaImagenFolio)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturaImagen_eliminarFacturaImagen_av2"))
                {
                    db.AddInParameter(dbCommand, "Original_FacturaCodigo", DbType.Int64, FacturaCodigo);
                    db.AddInParameter(dbCommand, "Original_FacturaImagenFolio", DbType.Int64, FacturaImagenFolio);                   
                    ds = db.ExecuteDataSet(dbCommand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal DataSet ObtenerComprobantesEgresoAsociados(string CodigoRadicado)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("facturas_comprobante_ObtenerComprobantes_av2"))
                {
                    db.AddInParameter(dbCommand, "FacturaCodigo", DbType.Int64, int.Parse(CodigoRadicado));                    
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        internal DataSet GetInfoRadPadre(string RadicadoCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Radicado_ReadRadicadoById_Mas"))
                {
                    db.AddInParameter(dbCommand, "RadicadoCodigo", DbType.Decimal, (Int64.Parse(RadicadoCodigo)));
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        internal ObjDocumentos RegistroMasivoUnoaUno(string UserID, string nomDep, string Dependencia, ObjDocumentos item, out string result1)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            SqlServerConnection conn = null;
            try
            {

                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Registro_CreateRegistro_CreateRegistroMasivo"))
                {     
                    db.AddInParameter(dbCommand, "GrupoCodigo ", DbType.String, item.GrupoCodigo);
                    db.AddInParameter(dbCommand, "WFMovimientoFecha ", DbType.DateTime, DateTime.Parse(item.WfmovimientoFecha));
                    db.AddInParameter(dbCommand, "ProcedenciaCodDestino ", DbType.String, item.ProcedenciaNUI);
                    db.AddInParameter(dbCommand, "DependenciaCodDestino ", DbType.String, item.DependenciaDestino);
                    db.AddInParameter(dbCommand, "DependenciaCodigo ", DbType.String, Dependencia);
                    db.AddInParameter(dbCommand, "NaturalezaCodigo ", DbType.String, item.NaturalezaCodigo);
                    db.AddInParameter(dbCommand, "radicadoCodigo ", DbType.Int64, item.RadicadoFuente);
                    db.AddInParameter(dbCommand, "RegistroDetalle ", DbType.String, item.RadicadoDetalle);
                    db.AddInParameter(dbCommand, "ExpedienteCodigo ", DbType.String, item.ExpedienteCodigo);                
                    db.AddInParameter(dbCommand, "MedioCodigo ", DbType.String, item.MedioCodigo);
                    db.AddInParameter(dbCommand, "SerieCodigo ", DbType.String, item.SerieCodigo);
                    db.AddInParameter(dbCommand, "RegistroTipo ", DbType.String, item.RegistroTipo);   
                    db.AddInParameter(dbCommand, "WFMovimientoTipo ", DbType.Int32, int.Parse(item.RegistroTipo));    
                    db.AddInParameter(dbCommand, "UserId ", DbType.String, UserID);
                    db.AddOutParameter(dbCommand, "RegistroCodigo", DbType.Int64, 20);
                    ds = db.ExecuteDataSet(dbCommand);
                    radicadoCodigo = db.GetParameterValue(dbCommand, "RegistroCodigo").ToString();
                    item.NumeroDocumento = radicadoCodigo;
                    result1 = "OK";
                    return item;
                }
            }
            catch (Exception)
            {
                result1 = "ERROR";
                return item = null;
            }
        }

        internal ObjDocumentos RegistroResolucionesMasivoUnoaUno(string UserID, string nomDep, string Dependencia, ObjDocumentos item, out string result1)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            result1 = string.Empty;
            string radicadoCodigo = string.Empty;
            SqlServerConnection conn = null;
            try
            {

                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Registro_CreateResolucion_CreateResolucionMasivo"))
                {
                    db.AddInParameter(dbCommand, "GrupoCodigo ", DbType.String, item.GrupoCodigo);
                    db.AddInParameter(dbCommand, "WFMovimientoFecha ", DbType.DateTime, DateTime.Parse(item.WfmovimientoFecha));
                    db.AddInParameter(dbCommand, "ProcedenciaCodDestino ", DbType.String, item.ProcedenciaNUI);
                    db.AddInParameter(dbCommand, "DependenciaCodDestino ", DbType.String, item.DependenciaDestino);
                    db.AddInParameter(dbCommand, "DependenciaCodigo ", DbType.String, Dependencia);
                    db.AddInParameter(dbCommand, "NaturalezaCodigo ", DbType.String, item.NaturalezaCodigo);
                    db.AddInParameter(dbCommand, "radicadoCodigo ", DbType.Int64, item.RadicadoFuente);
                    db.AddInParameter(dbCommand, "ResolucionDetalle ", DbType.String, item.RadicadoDetalle);
                    db.AddInParameter(dbCommand, "ExpedienteCodigo ", DbType.String, item.ExpedienteCodigo);
                    db.AddInParameter(dbCommand, "MedioCodigo ", DbType.String, item.MedioCodigo);
                    db.AddInParameter(dbCommand, "SerieCodigo ", DbType.String, item.SerieCodigo);                    
                    db.AddInParameter(dbCommand, "WFMovimientoTipo ", DbType.Int32, int.Parse(item.RegistroTipo));
                    db.AddInParameter(dbCommand, "UserId ", DbType.String, UserID);
                    db.AddOutParameter(dbCommand, "ResolucionCodigo", DbType.Int64, 20);
                    ds = db.ExecuteDataSet(dbCommand);
                    radicadoCodigo = db.GetParameterValue(dbCommand, "ResolucionCodigo").ToString();
                    item.NumeroDocumento = radicadoCodigo;
                    result1 = "OK";
                    return item;
                }
            }
            catch (Exception)
            {
                result1 = "ERROR";
                return item = null;
            }
        }


        internal DataSet ReturnProcedencia(string ProcedenciaNui)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                DataSet ds = new DataSet();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Procedencia_ReadProcedenciaByIdv2"))
                {
                    db.AddInParameter(dbCommand, "ProcedenciaNUI", DbType.String, ProcedenciaNui);
                    db.AddInParameter(dbCommand, "tipoDocumento", DbType.String, null);
                    ds = db.ExecuteDataSet(dbCommand);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }



        internal int InsertRegistroImagen(string grupoCodigo, string radicadoCodigo, string fileName, string rutaCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("Registroimagen_createRegistroimagen_av2"))
                {
                    db.AddInParameter(dbCommand, "GrupoCodigo", DbType.String, grupoCodigo);
                    db.AddInParameter(dbCommand, "radicadoCodigo", DbType.Int64, radicadoCodigo);
                    db.AddInParameter(dbCommand, "imagenNombre", DbType.String, fileName);
                    db.AddInParameter(dbCommand, "ImagenRutaCodigo", DbType.Int32, rutaCodigo);
                    return db.ExecuteNonQuery(dbCommand);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal DataSet GetPendingDocuments(string dependenciaCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("wfmovimientos_obtenerDocumentos_av2"))
                {
                    db.AddInParameter(dbCommand, "DependenciaCodigo", DbType.String, dependenciaCodigo);                   
                    return db.ExecuteDataSet(dbCommand);
                }
            }
            catch (Exception)
            {
                DataSet error = null;
                return error;
               
            }
        }

        internal bool DocumentAccepted(string numeroDocumento, string grupoCodigo)
        {
            SqlServerConnection conn = null;
            try
            {
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("wfmovimientos_AceptarDocumentos_av2"))
                {
                    db.AddInParameter(dbCommand, "numeroDocumento", DbType.Int64, numeroDocumento);
                    db.AddInParameter(dbCommand, "grupoCodigo", DbType.Int32, grupoCodigo);
                    db.AddOutParameter(dbCommand, "result", DbType.Int32, 20);
                    db.ExecuteDataSet(dbCommand);
                    int result = int.Parse(db.GetParameterValue(dbCommand, "result").ToString());
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {               
                return false;
            }
        }

        internal DataSet GetDocumentoInfo(string numeroDocumento)
        {
            throw new NotImplementedException();
        }

        internal DataSet GetReceivedDocuments(DateTime fechaIni, DateTime fechaFin, string dependencia)
        {
            SqlServerConnection conn = null;
            DataSet data = null;
            try
            {
                data = new DataSet();
                conn = new SqlServerConnection();
                Database db = conn.openConnection();
                using (DbCommand dbCommand = db.GetStoredProcCommand("radicado_consultar_recibidos_av2"))
                {
                    db.AddInParameter(dbCommand, "fechaIni", DbType.DateTime, fechaIni);
                    db.AddInParameter(dbCommand, "fechaFin", DbType.DateTime, fechaFin);
                    db.AddInParameter(dbCommand, "dependencia", DbType.String, dependencia);
                    data = db.ExecuteDataSet(dbCommand);
                    return data;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
