// Alfanet.Bll.RadicacionMasivaBLL
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Alfanet.CommonLibrary;
using Alfanet.CommonObject;
using Alfanet.Dal;
using FileHelpers;

public class RadicacionMasivaBLL
{
    private QueryManager Dal = null;
    private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public List<ObjFactura> GetPreview(string Serie, string naturaleza, string medio, string CodDep, ConfigData config, byte[] file, string fileName, out List<string> result, out string objCacheName, out string Summary, out string SCamposVacios, out string SDuplicadosBD, out string SDuplicadosExcel)
    {
        List<ObjFactura> objList = null;
        List<ObjFactura> objList2 = null;
        result = new List<string>();
        Summary = null;
        DataTable data = null;
        try
        {
            objList = new List<ObjFactura>();
            objList2 = new List<ObjFactura>();
            string serverFileName;
            log.Debug("file" + file + " filename " + fileName);
            bool saved = SaveTempFile(file, fileName, out serverFileName);
            string result2 = string.Empty;
            if (saved)
            {
                data = new DataTable();
                data = ReadDataFromFile(serverFileName, out result2);
                if (data != null)
                {
                    if (data.Columns.Count != 23)
                    {
                        objCacheName = "Error en la estructura del archivo";
                        SCamposVacios = string.Empty;
                        SDuplicadosBD = string.Empty;
                        SDuplicadosExcel = string.Empty;
                        return objList;
                    }
                    string[] partes = Serie.Split('|');
                    naturaleza = naturaleza.Remove(naturaleza.IndexOf(" | "));
                    medio = medio.Remove(medio.IndexOf(" | "));
                    Serie = Serie.Remove(Serie.IndexOf(" | "));
                    string faltantes = string.Empty;
                    string Sdup = string.Empty;
                    string SCampos = string.Empty;
                    string SDupExcel = string.Empty;
                    objList = CreateFacturaList(serverFileName, data, naturaleza, Serie, partes[1].ToString(), medio, config, out faltantes, out SCampos, out Sdup, out SDupExcel);
                    objList2 = CreateFacturaList2(data, naturaleza, Serie, partes[1].ToString(), medio);
                    if (string.IsNullOrWhiteSpace(SDupExcel))
                        result = ValidateFacturaList(objList2);
                    else                    
                        objList.Clear();

                    

                    if (result.Count() > 0)
                    {
                        objCacheName = "No fue posible almacenar los datos en Cache";
                        SCamposVacios = string.Empty;
                        SDuplicadosBD = string.Empty;
                        SDuplicadosExcel = string.Empty;
                        return objList2;
                    }
                    CommonLibrary common = new CommonLibrary();
                    Summary = faltantes;
                    string nameObjectCache = "RadicacionMasivaTable_" + CodDep;
                    string SaveResult;
                    common.SaveObjectInCache(nameObjectCache, objList, out SaveResult);
                    objCacheName = nameObjectCache;
                    SCamposVacios = SCampos;
                    SDuplicadosBD = Sdup;
                    SDuplicadosExcel = SDupExcel;
                    return objList;
                }
                objCacheName = "No hay datos para cargar en el documento";
                SCamposVacios = string.Empty;
                SDuplicadosBD = string.Empty;
                SDuplicadosExcel = string.Empty;
                return objList;
            }
            objCacheName = "El archivo no pudo ser cargado al sistema";
            SCamposVacios = string.Empty;
            SDuplicadosBD = string.Empty;
            SDuplicadosExcel = string.Empty;
            return objList;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error {ex.Message} {ex.InnerException}");
            objList = new List<ObjFactura>();
            objCacheName = "Error en la generación de la vista previa.<br/>Posible error en el formato del archivo, o en un tipo de dato.";
            SCamposVacios = string.Empty;
            SDuplicadosBD = string.Empty;
            SDuplicadosExcel = string.Empty;
            return objList;
        }
    }

    private List<string> ValidateFacturaList(List<ObjFactura> objList)
    {
        List<ObjFactura> Nulos = new List<ObjFactura>();
        Nulos = objList.Where(x=> 
        {
            int result;
            if (!string.IsNullOrWhiteSpace(x.Facn_empresa) && !string.IsNullOrWhiteSpace(x.Facc_documento) && !string.IsNullOrWhiteSpace(x.Facn_numero) 
            && !string.IsNullOrWhiteSpace(x.Facn_ubicacion) && !string.IsNullOrWhiteSpace(x.Facv_tercero) && !double.IsNaN(x.Facv_total) && !string.IsNullOrWhiteSpace(x.Facc_estado) 
            && !string.IsNullOrWhiteSpace(x.Facn_factura2) && !string.IsNullOrWhiteSpace(x.Facc_factura) && !string.IsNullOrWhiteSpace(x.Facc_alto_costo) 
            && !string.IsNullOrWhiteSpace(x.Terc_nombre) && !string.IsNullOrWhiteSpace(x.Facn_recibo) && !string.IsNullOrWhiteSpace(x.Facv_copago) 
            && !string.IsNullOrWhiteSpace(x.Facv_responsable) && !string.IsNullOrWhiteSpace(x.Facc_conciliado) && !string.IsNullOrWhiteSpace(x.Facv_imputable))
            {
                DateTime facf_confirmacion = x.Facf_confirmacion;
                if (!string.IsNullOrWhiteSpace(x.Facc_almacenamiento) && !string.IsNullOrWhiteSpace(x.Cntc_concepto))
                {
                    result = ((x.Conc_nombre == "") ? 1 : 0);
                    goto IL_017d;
                }
            }
            result = 1;
            goto IL_017d;
        IL_017d:
            return (byte)result != 0;
        }).ToList();
        List<string> Salida = new List<string>();
        if (Nulos.Count() > 0)
        {
            Salida.Add("Hay campos obligatorios sin diligenciar verifique su archivo. <br/> (Recuerde que los campos obligatorios son todos excepto: facc_prefijo, facf_radicado, y facf_final)");
        }
        return Salida;
    }

    private List<ObjFactura> CreateFacturaList(string fileName, DataTable data, string Naturaleza, string serie, string DependenciaNombre, string Medio, ConfigData config, out string Faltantes, out string SCamposVacios, out string SDuplicadosBD, out string SDuplicadosExcel)
    {
        ObjFactura factura = null;
        List<ObjFactura> listDocuments = null;
        Faltantes = "La(s) Procedencia(s) ";
        string Summary = "";
        string CamposVacios = "";
        string DuplicadosBD = "";
        string DuplicadosExcel = "";
        try
        {
            Dal = new QueryManager();
            listDocuments = new List<ObjFactura>();
            double DiasVencimiento = Dal.ObtenerDiasVencimiento(config, Naturaleza);
            foreach (DataRow dr in data.Rows)
            {
                //Se va a crear la lista de registros, sin importar nada

               
                    string facturaValidar = dr["facc_factura"].ToString().Trim();
                    if (Dal.ValidarExistenciaUnica(config, facturaValidar, dr["facv_tercero"].ToString().Trim()))
                    {
                        factura = new ObjFactura();
                        factura.DependenciaNomDestino = DependenciaNombre;
                        factura.ExpedienteCodigo = dr["facv_tercero"].ToString().Trim() + "_" + dr["facn_recibo"].ToString().Trim();
                        Dal.ValidarExpediente(config, factura.ExpedienteCodigo);
                        factura.GrupoCodigo = "4";
                        factura.Serie = serie;
                        factura.ProcedenciaNUI = dr["facv_tercero"].ToString().Trim();
                        factura.Facn_numero = dr["facn_numero"].ToString();
                        factura.Facn_empresa = dr["facn_empresa"].ToString();
                        factura.Facc_documento = dr["facc_documento"].ToString();
                        factura.Facv_tercero = dr["facv_tercero"].ToString();
                        factura.Facn_ubicacion = dr["facn_ubicacion"].ToString();
                        factura.Facv_total = Convert.ToDouble(dr["facv_total"].ToString());
                        factura.Facc_estado = dr["facc_estado"].ToString();
                        factura.Facc_prefijo = dr["facc_prefijo"].ToString();
                        factura.Facn_factura2 = dr["facn_factura2"].ToString();
                        factura.Facc_factura = dr["facc_factura"].ToString().Trim();
                        factura.Facc_alto_costo = dr["facc_alto_costo"].ToString();
                        factura.Terc_nombre = dr["terc_nombre"].ToString();
                        factura.Facf_confirmacion = ((dr["facf_confirmacion"].ToString() == null) ? DateTime.Now : DateTime.Parse(dr["facf_confirmacion"].ToString()));
                        factura.Facn_recibo = dr["facn_recibo"].ToString();
                        factura.Facv_copago = dr["facv_copago"].ToString();
                        factura.Facv_responsable = dr["facv_responsable"].ToString();
                        factura.Facc_conciliado = dr["facc_conciliado"].ToString();
                        factura.Facv_imputable = dr["facv_imputable"].ToString();
                        factura.Facf_radicado = ((dr["facf_radicado"].ToString() == "") ? DateTime.Now : DateTime.Parse(dr["facf_radicado"].ToString()));
                        factura.FechaRadicacion = DateTime.Now;
                        factura.FechaVencimiento = factura.FechaRadicacion.AddDays(DiasVencimiento);
                        factura.Facf_final = ((dr["facf_final"].ToString() == "") ? DateTime.Now : DateTime.Parse(dr["facf_final"].ToString()));
                        factura.Facc_almacenamiento = dr["facc_almacenamiento"].ToString();
                        factura.Cntc_concepto = dr["cntc_concepto"].ToString();
                        factura.Conc_nombre = dr["conc_nombre"].ToString();
                        factura.NaturalezaCodigo = Naturaleza;
                        factura.WFMovimientoFecha = DateTime.Now;
                        factura.FechaProcedencia = DateTime.Now;
                        factura.MedioCodigo = Medio;
                        factura.FileName = factura.Facc_factura.ToUpper() + "+" + dr["facv_tercero"].ToString().Trim();
                        factura.Detalle = "Registro Oasis: " + dr["facn_numero"].ToString() + " Valor: " + dr["facv_total"].ToString() + " Nit del Prestador: " + dr["facv_tercero"].ToString() + " Responsable: " + dr["facv_responsable"].ToString() + " Unidad Almacenamiento: " + dr["facc_almacenamiento"].ToString() + " Modalidad de Contrato: " + dr["conc_nombre"].ToString();
                        listDocuments.Add(factura);
                    }
                    else
                    {
                        DuplicadosBD = DuplicadosBD + "<br/>la factura " + facturaValidar + " Ya Existe en Base de datos revise los datos del archivo <br />";
                }

               
            }

            // Se itera sobre los diferentes nits que vienen en el campo facv_tercero del archivo con el fin de validar su procedencia
            foreach (var item in listDocuments.Select(x => x.Facv_tercero).Distinct())
            {
                if (!Dal.ValidarProcedenciaNui(config, item))
                {
                    Summary = (Summary.Contains(item) ? Summary : (Summary + " " + item + ","));
                }
            }

            //Se valida que la lista no traiga facturas repetidas, si lo hace, se eliminan de la lista los elementos repetidos
            //Si el número de diferentes facturas es diferente a la cantidad de documentos que trae el archivo

            var lstFactDuplicadas = listDocuments.GroupBy(x => x.Facc_factura).Where(grp => grp.Count() > 1).Select(x => x.Key);

            foreach (var item in lstFactDuplicadas)
            {
                DuplicadosExcel = $"{DuplicadosExcel} <br/> La factura {item} se encuentra más de una vez en el archivo 333<br />";
            }


            Faltantes = Faltantes + Summary + " No Existe(n) en Alfanet ";
            SCamposVacios = CamposVacios;
            SDuplicadosBD = DuplicadosBD;
            SDuplicadosExcel = DuplicadosExcel;
            return listDocuments;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en CreateFacturaList, {ex.Message} {ex.InnerException}");
            throw;
        }
    }

    private List<ObjFactura> CreateFacturaList2(DataTable data, string Naturaleza, string serie, string DependenciaNombre, string Medio)
    {
        ObjFactura factura = null;
        List<ObjFactura> listDocuments = null;
        try
        {
            listDocuments = new List<ObjFactura>();
            foreach (DataRow dr in data.Rows)
            {
                factura = new ObjFactura();
                factura.DependenciaNomDestino = DependenciaNombre;
                factura.ExpedienteCodigo = dr["facv_tercero"].ToString().Trim() + "_" + dr["facn_recibo"].ToString().Trim();
                factura.GrupoCodigo = "4";
                factura.Serie = serie;
                factura.ProcedenciaNUI = dr["facv_tercero"].ToString().Trim();
                factura.Facn_numero = dr["facn_numero"].ToString();
                factura.Facn_empresa = dr["facn_empresa"].ToString();
                factura.Facc_documento = dr["facc_documento"].ToString();
                factura.Facv_tercero = dr["facv_tercero"].ToString();
                factura.Facn_ubicacion = dr["facn_ubicacion"].ToString();
                factura.Facv_total = Convert.ToDouble(dr["facv_total"].ToString());
                factura.Facc_estado = dr["facc_estado"].ToString();
                factura.Facc_prefijo = dr["facc_prefijo"].ToString();
                factura.Facn_factura2 = dr["facn_factura2"].ToString();
                if (factura.Facc_prefijo != "")
                {
                    factura.Facc_factura = factura.Facc_prefijo + factura.Facn_factura2;
                }
                else
                {
                    factura.Facc_factura = dr["facc_factura"].ToString().Trim();
                }
                factura.Facc_alto_costo = dr["facc_alto_costo"].ToString();
                factura.Terc_nombre = dr["terc_nombre"].ToString();
                factura.Facf_confirmacion = ((dr["facf_confirmacion"].ToString() == null) ? DateTime.Now : DateTime.Parse(dr["facf_confirmacion"].ToString()));
                factura.Facn_recibo = dr["facn_recibo"].ToString();
                factura.Facv_copago = dr["facv_copago"].ToString();
                factura.Facv_responsable = dr["facv_responsable"].ToString();
                factura.Facc_conciliado = dr["facc_conciliado"].ToString();
                factura.Facv_imputable = dr["facv_imputable"].ToString();
                factura.Facf_radicado = ((dr["facf_radicado"].ToString() == "") ? DateTime.Now : DateTime.Parse(dr["facf_radicado"].ToString()));
                factura.FechaRadicacion = DateTime.Now;
                factura.FechaVencimiento = factura.FechaRadicacion.AddDays(2.0);
                factura.Facf_final = ((dr["facf_final"].ToString() == "") ? DateTime.Now : DateTime.Parse(dr["facf_final"].ToString()));
                factura.Facc_almacenamiento = dr["facc_almacenamiento"].ToString();
                factura.Cntc_concepto = dr["cntc_concepto"].ToString();
                factura.Conc_nombre = dr["conc_nombre"].ToString();
                factura.NaturalezaCodigo = Naturaleza;
                factura.WFMovimientoFecha = DateTime.Now;
                factura.FechaProcedencia = DateTime.Now;
                factura.MedioCodigo = Medio;
                factura.FileName = dr["facc_factura"].ToString().Trim().ToUpper() + "+" + dr["facv_tercero"].ToString().Trim();
                factura.Detalle = "Registro Oasis: " + dr["facc_factura"].ToString() + " Valor: " + dr["facv_total"].ToString() + " Nit del Prestador: " + dr["facv_tercero"].ToString() + " Responsable: " + dr["facv_responsable"].ToString() + " Unidad Almacenamiento: " + dr["facc_almacenamiento"].ToString() + " Modalidad de Contrato: " + dr["conc_nombre"].ToString();
                listDocuments.Add(factura);
            }
            return listDocuments;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en CreateFacturaList2, {ex.Message} {ex.InnerException}");
            throw;
        }
    }

    private List<ObjFactura> CreateFacturaListFromCSV(DataTable data, string Naturaleza, string serie, string DependenciaNombre, string Medio, ConfigData config, out string Faltantes, out string SCamposVacios, out string SDuplicadosBD)
    {
        ObjFactura factura = null;
        List<ObjFactura> listDocuments = null;
        Faltantes = "La(s) Procedencia(s) ";
        string Summary = string.Empty;
        string CamposVacios = string.Empty;
        string DuplicadosBD = string.Empty;
        var DuplicadosExcel = string.Empty;
        try
        {
            Dal = new QueryManager();
            listDocuments = new List<ObjFactura>();
            double DiasVencimiento = Dal.ObtenerDiasVencimiento(config, Naturaleza);
            foreach (DataRow dr in data.Rows)
            {
                char[] delimiterChar = new char[1] { ',' };
                string[] words = dr.ToString().Split(delimiterChar);
                if (words[4] != "")
                {

                    if (Dal.ValidarExistenciaUnica(config, words[9].Trim(), words[4].Trim()))
                    {
                        factura = new ObjFactura();
                        factura.DependenciaNomDestino = DependenciaNombre;
                        factura.ExpedienteCodigo = words[4].Trim() + "_" + words[12];
                        Dal.ValidarExpediente(config, factura.ExpedienteCodigo);
                        factura.GrupoCodigo = "4";
                        factura.Serie = serie;
                        factura.ProcedenciaNUI = words[4].Trim();
                        factura.Facn_numero = words[2];
                        factura.Facn_empresa = words[0];
                        factura.Facc_documento = words[1];
                        factura.Facv_tercero = words[4];
                        factura.Facn_ubicacion = words[3];
                        factura.Facv_total = Convert.ToDouble(words[5].Trim());
                        factura.Facc_estado = words[6];
                        factura.Facc_prefijo = words[7];
                        factura.Facn_factura2 = words[8];
                        factura.Facc_factura = words[9];
                        factura.Facc_alto_costo = words[10];
                        factura.Terc_nombre = words[11];
                        factura.Facf_confirmacion = DateTime.Parse(words[17]);
                        factura.Facn_recibo = words[12];
                        factura.Facv_copago = words[13];
                        factura.Facv_responsable = words[14];
                        factura.Facc_conciliado = words[15];
                        factura.Facv_imputable = words[16];
                        factura.Facf_radicado = DateTime.Parse(words[18].Trim());
                        factura.FechaRadicacion = DateTime.Now;
                        factura.FechaVencimiento = factura.FechaRadicacion.AddDays(DiasVencimiento);
                        factura.Facf_final = DateTime.Parse(words[19].Trim());
                        factura.Facc_almacenamiento = words[21];
                        factura.Cntc_concepto = words[22];
                        factura.Conc_nombre = words[23];
                        factura.NaturalezaCodigo = Naturaleza;
                        factura.WFMovimientoFecha = DateTime.Now;
                        factura.FechaProcedencia = DateTime.Now;
                        factura.MedioCodigo = Medio;
                        factura.FileName = words[9].Trim() + "+" + words[4].Trim();
                        factura.Detalle = "Registro Oasis: " + words[9] + " Valor: " + words[5] + " Nit del Prestador: " + words[4] + " Radicador: " + words[14] + " Unidad Almacenamieto: " + words[21] + " Modalida de Contrato: " + words[23];
                        listDocuments.Add(factura);
                    }
                    else
                    {
                        DuplicadosBD = DuplicadosBD + "<br/>La factura  Nº" + words[9] + " Ya Existe en Base de datos revise los datos del archivo <br />";
                    }
                    
                }
                else
                {
                    CamposVacios = " Tiene campos obligatorios vacios <br />";
                }
            }

            // Se itera sobre los diferentes nits que vienen en el campo facv_tercero del archivo con el fin de validar su procedencia
            foreach (var item in listDocuments.Select(x => x.Facv_tercero).Distinct())
            {
                if (!Dal.ValidarProcedenciaNui(config, item))
                {
                    Summary = (Summary.Contains(item) ? Summary : (Summary + " " + item + ","));
                }
            }

            //Se valida que la lista no traiga facturas repetidas, si lo hace, se eliminan de la lista los elementos repetidos
            //Si el número de diferentes facturas es diferente a la cantidad de documentos que trae el archivo

            var lstFactDuplicadas = listDocuments.GroupBy(x => x.Facc_factura).Where(grp => grp.Count() > 1).Select(x => x.Key);

            foreach (var item in lstFactDuplicadas)
            {
                DuplicadosExcel = $"{DuplicadosExcel} <br/> La factura {item} se encuentra más de una vez en el archivo <br />";
            }


            SCamposVacios = CamposVacios;
            SDuplicadosBD = DuplicadosBD;
            Faltantes = Faltantes + Summary + " No Existe(n) en Alfanet ";
            return listDocuments;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en CreateFacturaListFromCSV {ex.Message} {ex.InnerException}");
            throw;
        }
    }

    private DataTable ReadDataFromFile(string fileName, out string result)
    {
        string path = string.Empty;
        try
        {
            path = calculateTempPath();
            if (path == string.Empty)
            {
                result = "Error en la ruta del archivo";
                return null;
            }
            string serverFileName = path + fileName;
            if (fileName.ToLower().EndsWith(".xls") || fileName.ToLower().EndsWith(".xlsx"))
            {
                string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + serverFileName + ";Persist Security Info=False;Extended Properties=Excel 8.0;";
                OleDbConnection oConn = new OleDbConnection(cadenaConexion);
                oConn.Open();
                OleDbCommand oCmd = new OleDbCommand("SELECT * FROM [ECFP$]", oConn);
                OleDbDataAdapter oDa = new OleDbDataAdapter();
                oDa.SelectCommand = oCmd;
                DataSet oDs = new DataSet();
                oDa.Fill(oDs, "Datos");
                oConn.Close();
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    result = "Lectura exitosa";
                    return oDs.Tables[0];
                }
                result = "No hay datos para procesar";
                return null;
            }
            if (fileName.ToLower().EndsWith(".csv"))
            {
                DataTable oDs2 = new DataTable();
                oDs2 = ReadCSV(serverFileName);
                result = "Lectura exitosa";
                return oDs2;
            }
            result = "Formato no admitido";
            return null;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en ReadDataFromFile {ex.Message} {ex.InnerException}");
            result = "Error desconocido";
            return null;
        }
    }

    private DataTable ReadCSV(string serverFileName)
    {
        FileHelperEngine engine = null;
        DataTable data = null;
        try
        {
            engine = new FileHelperEngine(typeof(ObjDocumentForCsv));
            ObjDocumentForCsv[] res = (ObjDocumentForCsv[])engine.ReadFile(serverFileName);
            data = new DataTable();
            data.Columns.Add(res[0].facn_empresa);
            data.Columns.Add(res[0].facc_documento);
            data.Columns.Add(res[0].facn_numero);
            data.Columns.Add(res[0].facn_ubicacion);
            data.Columns.Add(res[0].facv_tercero);
            data.Columns.Add(res[0].facv_total);
            data.Columns.Add(res[0].facc_estado);
            data.Columns.Add(res[0].facc_prefijo);
            data.Columns.Add(res[0].facn_factura2);
            data.Columns.Add(res[0].facc_factura);
            data.Columns.Add(res[0].facc_alto_costo);
            data.Columns.Add(res[0].terc_nombre);
            data.Columns.Add(res[0].facn_recibo);
            data.Columns.Add(res[0].facv_copago);
            data.Columns.Add(res[0].facv_responsable);
            data.Columns.Add(res[0].facc_conciliado);
            data.Columns.Add(res[0].facv_imputable);
            data.Columns.Add(res[0].facf_confirmacion);
            data.Columns.Add(res[0].facf_radicado);
            data.Columns.Add(res[0].facf_final);
            data.Columns.Add(res[0].facc_almacenamiento);
            data.Columns.Add(res[0].cntc_concepto);
            data.Columns.Add(res[0].conc_nombre);
            for (int i = 1; i < res.Length; i++)
            {
                DataRow row = data.NewRow();
                row[0] = res[i].facn_empresa;
                row[1] = res[i].facc_documento;
                row[2] = res[i].facn_numero;
                row[3] = res[i].facn_ubicacion;
                row[4] = res[i].facv_tercero;
                row[5] = res[i].facv_total;
                row[6] = res[i].facc_estado;
                row[7] = res[i].facc_prefijo;
                row[8] = res[i].facn_factura2;
                row[9] = res[i].facc_factura;
                row[10] = res[i].facc_alto_costo;
                row[11] = res[i].terc_nombre;
                row[12] = res[i].facn_recibo;
                row[13] = res[i].facv_copago;
                row[14] = res[i].facv_responsable;
                row[15] = res[i].facc_conciliado;
                row[16] = res[i].facv_imputable;
                row[17] = res[i].facf_confirmacion;
                row[18] = res[i].facf_radicado;
                row[19] = res[i].facf_final;
                row[20] = res[i].facc_almacenamiento;
                row[21] = res[i].cntc_concepto;
                row[22] = res[i].conc_nombre;
                data.Rows.Add(row);
            }
            return data;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en CreateFacturaListFromCSV {ex.Message} {ex.InnerException}");
            throw;
        }
    }

    private bool SaveTempFile(byte[] file, string fileName, out string name)
    {
        string path = string.Empty;
        try
        {
            name = "temp_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + fileName;
            path = calculateTempPath();
            if (path == string.Empty)
            {
                name = string.Empty;
                return false;
            }
            File.WriteAllBytes(path + name, file);
            return true;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en SaveTempFile {ex.Message} {ex.InnerException}");
            name = string.Empty;
            return false;
        }
    }

    private string calculateTempPath()
    {
        try
        {
            return AppDomain.CurrentDomain.BaseDirectory.ToString() + "temp/";
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en calculateTempPath {ex.Message} {ex.InnerException}");
            return string.Empty;
        }
    }

    public List<ObjFactura> RadicarFacturas(string UserID, string nomDep, string CodDep, string objCacheName, string tempImagesPath, ConfigData config, out string result)
    {
        CommonLibrary common = null;
        QueryManager dal = null;
        List<ObjFactura> Factura = null;
        List<ObjFactura> resumenList = null;
        result = string.Empty;
        try
        {
            dal = new QueryManager();
            common = new CommonLibrary();
            string resultFindFacturas = null;
            Factura = new List<ObjFactura>();
            Factura = common.FindFacturasInCache(objCacheName, out resultFindFacturas);
            string radicadoCodigo = string.Empty;
            resumenList = new List<ObjFactura>();
            int rutaCodigo = SelectRutaCodigoFacturas(config);
            if (rutaCodigo == 0)
            {
                result = "Error al iniciar el proceso de radicación";
                return resumenList;
            }
            ObjFactura resumen = null;
            foreach (ObjFactura item in Factura)
            {
                if (dal.ValidarExistenciaUnica(config, item.Facc_factura, item.ProcedenciaNUI))
                {
                    string expediente = string.Empty;
                    radicadoCodigo = dal.RadicacionMasivaUnoaUno(UserID, nomDep, CodDep, config, item, out result);
                    if (result == "OK" && radicadoCodigo != "-1")
                    {
                        bool imagen = AsociarImagenRadicado(radicadoCodigo, item.FileName, rutaCodigo.ToString(), tempImagesPath, config);
                        resumen = new ObjFactura();
                        resumen.RadicadoCodigo = radicadoCodigo;
                        resumen.FechaRadicacion = item.FechaRadicacion;
                        resumen.ExpedienteNombre = item.ExpedienteCodigo;
                        resumen.Imagen = (imagen ? "Con Imagen" : "Sin Imangen");
                        resumenList.Add(resumen);
                    }
                }
            }
            string resultSaveResumen = string.Empty;
            common.SaveObjectInCache("ResumenList", resumenList, out resultSaveResumen);
            result = "Proceso realizado correctamente";
            return resumenList;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en calculateTempPath {ex.Message} {ex.InnerException}");
            result = "Error al realizar el proceso de radicación";
            return new List<ObjFactura>();
        }
    }

    private int SelectRutaCodigoFacturas(ConfigData config)
    {
        QueryManager dal = null;
        string path = ConfigurationManager.AppSettings["repositoriofacturas"] + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\";
        try
        {
            dal = new QueryManager();
            return dal.SelectRutaCodigoFacturas(DateTime.Now.Year, DateTime.Now.Month, path, config);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    private bool AsociarImagenRadicado(string radicadoCodigo, string fileName, string rutaCodigo, string tempImagesPath, ConfigData config)
    {
        List<string> result = null;
        QueryManager dal = null;
        try
        {
            dal = new QueryManager();
            string[] files = Directory.GetFiles(tempImagesPath, "*.*");
            result = new List<string>();
            result = (from x in files.ToList()
                      where x.ToUpper().Contains(fileName)
                      select x).ToList();
            if (result.Count == 0)
            {
                return false;
            }
            string pathRepositorio = ConfigurationManager.AppSettings["repositoriofacturas"] + DateTime.Now.Year + "\\" + DateTime.Now.Month;
            foreach (string ruta in result)
            {
                byte[] file = File.ReadAllBytes(ruta);
                if (!Directory.Exists(pathRepositorio))
                {
                    Directory.CreateDirectory(pathRepositorio);
                }
                char[] delimiterChars1 = new char[1] { '\\' };
                string[] words = ruta.Split(delimiterChars1);
                string tempFullFileName = words[words.Length - 1];
                string pathRepositorio2 = Path.Combine(pathRepositorio, tempFullFileName);
                using (FileStream fs = File.Create(pathRepositorio2))
                {
                    fs.Write(file, 0, file.Length);
                }
                if (dal.InsertFacturaImagen("4", radicadoCodigo, tempFullFileName, rutaCodigo, config) == 0)
                {
                }
                File.Delete(ruta);
            }
            return true;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en AsociarImagenRadicado {ex.Message} {ex.InnerException}");
            return false;
        }
    }

    public List<ObjParametros> GetParametrosIniciales(string grupoCodigo, ConfigData config)
    {
        QueryManager dal = null;
        DataSet ds = null;
        List<ObjParametros> Parametros = null;
        try
        {
            Parametros = new List<ObjParametros>();
            dal = new QueryManager();
            ds = new DataSet();
            ds = dal.GetParametrosIniciales(config, grupoCodigo);
            ObjParametros Parm = new ObjParametros();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                switch (item["Nombre"].ToString())
                {
                    case "Naturaleza":
                        Parm.Naturaleza = item["Valor"].ToString();
                        break;
                    case "Serie":
                        Parm.Serie = item["Valor"].ToString();
                        break;
                    case "Medio":
                        Parm.Medio = item["Valor"].ToString();
                        break;
                    case "Accion":
                        Parm.Accion = item["Valor"].ToString();
                        break;
                    case "Expediente":
                        Parm.Expediente = item["Valor"].ToString();
                        break;
                }
            }
            Parametros.Add(Parm);
            return Parametros;
        }
        catch (Exception ex)
        {
            log.Error($"Se ha presentado un error en GetParametrosIniciales {ex.Message} {ex.InnerException}");
            throw;
        }
    }

    public List<ObjNaturaleza> GetNaturalezas(ConfigData config)
    {
        QueryManager dal = null;
        ObjNaturaleza naturaleza = null;
        List<ObjNaturaleza> naturalezas = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            naturalezas = new List<ObjNaturaleza>();
            data = new DataSet();
            data = dal.GetNaturalezas(config);
            foreach (DataRow item in data.Tables[0].Rows)
            {
                naturaleza = new ObjNaturaleza();
                naturaleza.NaturalezaCodigo = item.ItemArray[0].ToString();
                naturaleza.NaturalezaNombre = item.ItemArray[1].ToString();
                naturalezas.Add(naturaleza);
            }
            return naturalezas;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool ValidarProcedenciaNui(string procedenciaNui, ConfigData config)
    {
        QueryManager dal = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            data = new DataSet();
            return dal.ValidarProcedenciaNui(config, procedenciaNui);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public int ObtenerConsecutivos(int GrupoCodigo, ConfigData config)
    {
        QueryManager dal = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            data = new DataSet();
            return dal.ObtenerConsecutivos(config, GrupoCodigo);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public List<ObjDependencia> GetDependencias(ConfigData config)
    {
        QueryManager dal = null;
        ObjDependencia dependencia = null;
        List<ObjDependencia> dependencias = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            dependencias = new List<ObjDependencia>();
            data = new DataSet();
            data = dal.GetDependencias(config);
            foreach (DataRow item in data.Tables[0].Rows)
            {
                dependencia = new ObjDependencia();
                dependencia.DependenciaCodigo = item.ItemArray[0].ToString();
                dependencia.DependenciaNombre = item.ItemArray[1].ToString();
                dependencias.Add(dependencia);
            }
            return dependencias;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<ObjAccion> GetAcciones(ConfigData config)
    {
        QueryManager dal = null;
        ObjAccion accion = null;
        List<ObjAccion> acciones = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            acciones = new List<ObjAccion>();
            data = new DataSet();
            data = dal.GetAcciones(config);
            foreach (DataRow item in data.Tables[0].Rows)
            {
                accion = new ObjAccion();
                accion.AccionCodigo = item.ItemArray[0].ToString();
                accion.AccionNombre = item.ItemArray[1].ToString();
                acciones.Add(accion);
            }
            return acciones;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<ObjMedio> GetMedios(ConfigData config)
    {
        QueryManager dal = null;
        ObjMedio medio = null;
        List<ObjMedio> medios = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            medios = new List<ObjMedio>();
            data = new DataSet();
            data = dal.GetMedios(config);
            foreach (DataRow item in data.Tables[0].Rows)
            {
                medio = new ObjMedio();
                medio.MedioCodigo = item.ItemArray[0].ToString();
                medio.MedioNombre = item.ItemArray[1].ToString();
                medios.Add(medio);
            }
            return medios;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<ObjExpediente> GetExpedientes(ConfigData config)
    {
        QueryManager dal = null;
        ObjExpediente expediente = null;
        CommonLibrary common = null;
        List<ObjExpediente> expedientes = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            common = new CommonLibrary();
            expedientes = new List<ObjExpediente>();
            data = new DataSet();
            data = dal.GetExpedientes(config);
            foreach (DataRow item in data.Tables[0].Rows)
            {
                expediente = new ObjExpediente();
                expediente.ExpedienteCodigo = item.ItemArray[0].ToString();
                expediente.ExpedienteNombre = item.ItemArray[1].ToString();
                expedientes.Add(expediente);
            }
            return expedientes;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void ObtenerDatosDependencia(string Dependencia, ConfigData config, out string UserId, out string NombreDependencia)
    {
        QueryManager dal = null;
        List<ObjMedio> medios = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            medios = new List<ObjMedio>();
            data = new DataSet();
            data = dal.ObtenerDatosDependencia(Dependencia, config);
            UserId = data.Tables[0].Rows[0]["UserId"].ToString();
            NombreDependencia = data.Tables[0].Rows[0]["DependenciaNombre"].ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<ObjFactura> BuscarRadicados(string Radicador, string porImagen, long radInicial, long radFinal, string comEgresoIni, string comEgresoFin, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string numFacIni, string numFacFinal, string nombreNit, string detalle, string ubicacion, string modalidad, string unidad, string expediente, string ciudadInicial, string ciudadFinal, ConfigData config)
    {
        QueryManager dal = null;
        CommonLibrary common = null;
        List<ObjFactura> radicados = null;
        ObjFactura factura = null;
        DataSet data = null;
        try
        {
            common = new CommonLibrary();
            dal = new QueryManager();
            radicados = new List<ObjFactura>();
            data = new DataSet();
            if (fechaInicial == "")
            {
                fechaInicial = null;
            }
            if (fechaFinal == "")
            {
                fechaFinal = null;
            }
            data = dal.BuscarRadicados(Radicador, porImagen, radInicial, radFinal, comEgresoIni, comEgresoFin, fechaInicial, fechaFinal, FacnReciboIni, FacnReciboFin, facValorMenor, facValorMayor, numFacIni, numFacFinal, nombreNit, detalle, ubicacion, modalidad, unidad, expediente, ciudadInicial, ciudadFinal, config);
            foreach (DataRow row in data.Tables[0].Rows)
            {
                factura = new ObjFactura();
                factura.RadicadoCodigo = row["RadicadoCodigo"].ToString();
                DataSet ComprobantesEgreso = dal.ObtenerComprobantesEgresoAsociados(config, factura.RadicadoCodigo);
                string compContatenados = string.Empty;
                foreach (DataRow item in ComprobantesEgreso.Tables[0].Rows)
                {
                    compContatenados = compContatenados + item[0].ToString() + " , ";
                }
                factura.ComprobanteEgreso = compContatenados;
                factura.FechaRadicacion = Convert.ToDateTime(row["WFMovimientoFecha"].ToString());
                factura.ProcedenciaNombre = row["ProcedenciaNombre"].ToString();
                factura.Detalle = row["Detalle"].ToString();
                factura.NaturalezaNombre = row["NaturalezaNombre"].ToString();
                factura.MedioNombre = row["MedioNombre"].ToString();
                factura.ExpedienteNombre = row["ExpedienteNombre"].ToString();
                factura.Serie = row["serieNombre"].ToString();
                factura.Imagen = row["Imagen"].ToString();
                factura.DependenciaNombre = row["DependenciaNombre"].ToString();
                factura.WFMovimientoFecha = Convert.ToDateTime(row["wfmovimientofecha"].ToString());
                factura.FechaProcedencia = Convert.ToDateTime(row["FechaProcedencia"].ToString());
                factura.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"].ToString());
                factura.FechaRadicacion = Convert.ToDateTime(row["FechaRadicacion"].ToString());
                factura.HoraRadicacion = Convert.ToDateTime(row["HoraRadicacion"].ToString());
                factura.Facf_final = Convert.ToDateTime(row["Facf_final"].ToString());
                factura.Facf_radicado = Convert.ToDateTime(row["Facf_radicado"].ToString());
                factura.Facf_confirmacion = Convert.ToDateTime(row["Facf_confirmacion"].ToString());
                factura.DependenciaCodigo = row["DependenciaCodigo"].ToString();
                factura.MedioCodigo = row["MedioCodigo"].ToString();
                factura.DependenciaCodDestino = row["DependenciaCodDestino"].ToString();
                factura.Anexo = row["Anexo"].ToString();
                factura.DependenciaNomDestino = row["DependenciaNomDestino"].ToString();
                factura.FileName = "N/A";
                factura.Facv_tercero = row["facv_tercero"].ToString();
                factura.Conc_nombre = row["conc_nombre"].ToString();
                factura.Cntc_concepto = row["cntc_concepto"].ToString();
                factura.Facc_almacenamiento = row["facc_almacenamiento"].ToString();
                factura.Facv_imputable = row["facv_imputable"].ToString();
                factura.Facc_conciliado = row["facc_conciliado"].ToString();
                factura.Facv_responsable = row["facv_responsable"].ToString();
                factura.Facv_copago = row["facv_copago"].ToString();
                factura.Facn_recibo = row["facn_recibo"].ToString();
                factura.Terc_nombre = row["terc_nombre"].ToString();
                factura.Facc_alto_costo = row["facc_alto_costo"].ToString();
                factura.Facc_factura = row["facc_factura"].ToString();
                factura.Facn_factura2 = row["facn_factura2"].ToString();
                factura.Facc_prefijo = row["facc_prefijo"].ToString();
                factura.Facc_estado = row["facc_estado"].ToString();
                factura.Facn_numero = row["facn_numero"].ToString();
                factura.Facn_empresa = row["facn_empresa"].ToString();
                factura.Facc_documento = row["facc_documento"].ToString();
                factura.Facn_ubicacion = row["facn_ubicacion"].ToString();
                factura.ProcedenciaNUI = row["ProcedenciaNUI"].ToString();
                factura.ExpedienteCodigo = row["ExpedienteCodigo"].ToString();
                radicados.Add(factura);
            }
            return radicados;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool ValidarUsuarioPermitido(string Dependencia, ConfigData config)
    {
        QueryManager dal = null;
        try
        {
            dal = new QueryManager();
            return dal.ValidarUsuarioPermitido(config, Dependencia);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<string> ValidateFiles(string path, out string result, string cacheName)
    {
        List<string> summary = null;
        result = string.Empty;
        CommonLibrary common = null;
        try
        {
            summary = new List<string>();
            string[] files = Directory.GetFiles(path, "*.*");
            if (files.Count() > 0)
            {
                common = new CommonLibrary();
                List<ObjFactura> objList = common.FindFacturasInCache(cacheName, out result);
                List<ObjFactura> lambdaResult = null;
                string[] array = files;
                foreach (string file in array)
                {
                    char[] delimiterChars1 = new char[1] { '\\' };
                    string[] words = file.Split(delimiterChars1);
                    string tempFullFileName = words[words.Length - 1];
                    char[] delimiterChars2 = new char[2] { '.', '+' };
                    words = tempFullFileName.Split(delimiterChars2);
                    string tempFacturaNumero = words[0];
                    string tempNit = words[1];
                    string tempFileName = tempFacturaNumero + "+" + tempNit;
                    lambdaResult = new List<ObjFactura>();
                    lambdaResult = objList.Where((ObjFactura x) => x.FileName == tempFileName.ToUpper()).ToList();
                    if (lambdaResult.Count == 0)
                    {
                        summary.Add(tempFullFileName);
                        File.Delete(file);
                    }
                }
                result = "OK";
            }
            else
            {
                result = "No hay imágenes para validar.";
            }
            return summary;
        }
        catch (Exception)
        {
            summary = new List<string>();
            result = "Error al realizar el proceso de validación de las imágenes";
            return summary;
        }
    }

    public List<string> GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo, ConfigData config, ConfigData config_2, out List<string> rutas)
    {
        throw new NotImplementedException();
    }

    public string UpdateRadicado(string codigo, string detalle, List<string> compEgresoList, ConfigData config)
    {
        string result = string.Empty;
        try
        {
            if (codigo == "")
            {
                return "El campo número de radicado no puede ser modificado para realizar este proceso.";
            }
            result = ((!(detalle != "")) ? "El detalle no fue actualizado debido a que no se puede reemplazar el detalle actual por vacío. " : ((!UpdateDetalleRadicado(codigo, detalle, config)) ? "El detalle no pudo ser actualizado. " : "Detalle actualizado correctamente. "));
            if (compEgresoList.Count > 0)
            {
                result = ((!InsertComprobantesEgreso(codigo, compEgresoList, config)) ? (result + "Alguno(s) de los comprobantes posiblemente no pudieron ser insertados.") : (result + "El(Los) comprobante(s) se almacenaron correctamente."));
            }
            return result;
        }
        catch (Exception)
        {
            return "Ocurrió un problema al realizar el proceso de actualización. Por favor intente de nuevo más tarde.";
        }
    }

    private bool InsertComprobantesEgreso(string codigo, List<string> compEgresoList, ConfigData config)
    {
        QueryManager dal = null;
        try
        {
            dal = new QueryManager();
            foreach (string item in compEgresoList)
            {
                bool i = dal.InsertComprobantesEgreso(codigo, item, config);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool UpdateDetalleRadicado(string codigo, string detalle, ConfigData config)
    {
        QueryManager dal = null;
        try
        {
            dal = new QueryManager();
            int actualizo = dal.UpdateDetalleRadicado(codigo, detalle, config);
            if (actualizo > 0)
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<ObjFactura> LoadFromCache(string nombre)
    {
        CommonLibrary common = null;
        List<ObjFactura> objList = null;
        string result = string.Empty;
        try
        {
            common = new CommonLibrary();
            objList = new List<ObjFactura>();
            return common.FindFacturasInCache(nombre, out result);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<ObjCiudad> GetCiudades(ConfigData config)
    {
        QueryManager dal = null;
        List<ObjCiudad> ciudadesList = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            ciudadesList = new List<ObjCiudad>();
            data = new DataSet();
            data = dal.GetCiudades(config);
            if (data.Tables[0].Rows.Count > 0)
            {
                ObjCiudad ciudad = null;
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    ciudad = new ObjCiudad();
                    ciudad.CiudadCodigo = row["codigo"].ToString();
                    ciudad.CiudadNombre = row["nombre"].ToString();
                    ciudadesList.Add(ciudad);
                }
                return ciudadesList;
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<ObjFactura> GetResultadosBusqueda(string nombre)
    {
        CommonLibrary common = null;
        List<ObjFactura> list = null;
        string result = string.Empty;
        try
        {
            common = new CommonLibrary();
            list = new List<ObjFactura>();
            return common.FindFacturasInCache(nombre, out result);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void deleteFileTemp()
    {
        string[] ficherosCarpeta = Directory.GetFiles("C:\\prueba");
        string[] array = ficherosCarpeta;
        foreach (string ficheroActual in array)
        {
            File.Delete(ficheroActual);
        }
    }

    public List<ObjProcedencia> GetProcedencias(ConfigData config)
    {
        QueryManager dal = null;
        List<ObjProcedencia> procedenciasList = null;
        DataSet data = null;
        try
        {
            dal = new QueryManager();
            procedenciasList = new List<ObjProcedencia>();
            data = new DataSet();
            data = dal.GetProcedencias(config);
            if (data.Tables[0].Rows.Count > 0)
            {
                ObjProcedencia ciudad = null;
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    ciudad = new ObjProcedencia();
                    ciudad.ProcedenciaCodigo = row["codigo"].ToString();
                    ciudad.ProcedenciaNombre = row["nombre"].ToString();
                    procedenciasList.Add(ciudad);
                }
                return procedenciasList;
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool ClearTempImages(string path, out string result)
    {
        try
        {
            string[] ficherosCarpeta = Directory.GetFiles(path);
            string[] array = ficherosCarpeta;
            foreach (string ficheroActual in array)
            {
                File.Delete(ficheroActual);
            }
            result = "OK";
            return true;
        }
        catch (Exception)
        {
            result = "Error";
            return false;
        }
    }
}