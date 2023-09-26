using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.Dal;
using Alfanet.CommonObject;
using System.Data;

namespace Alfanet.Bll
{
    public class VisorImagenesBLL
    {
        public List<string> GetFacturaImagenById(string GrupoCodigo, string FacturaCodigo, CommonObject.ConfigData config, out List<string> rutas)
        {
            QueryManager dal = null;
           
            List<string> rutacodigo = null;
            DataSet data = null;
            try
            {
                dal = new QueryManager();
                rutacodigo = new List<string>();
                data = new DataSet();
                data = dal.GetFacturaImagenById(GrupoCodigo, FacturaCodigo,config);
                rutas = null;
                foreach (DataRow item in data.Tables[0].Rows)
                {

                    rutacodigo.Add(item["FacturaImagenFolio"].ToString() + "#" + item["ImagenRutaCodigo"].ToString() + "#" + item["FacturaImagenNombre"].ToString());
                }
                return rutacodigo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetRutaImagenById(string ImagenRutaCodigo, ConfigData config, out List<string> rutas)
        {
            QueryManager dal = null;

            List<string> rutacodigo = null;
            DataSet data = null;
            try
            {
                dal = new QueryManager();
                rutacodigo = new List<string>();
                data = new DataSet();
                data = dal.GetRutaImagenById(ImagenRutaCodigo, config);
                rutas = null;
                foreach (DataRow item in data.Tables[0].Rows)
                {

                    rutacodigo.Add(item["ImagenRutaPath"].ToString());
                }
                return rutacodigo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SelectRutaCodigoFacturas(string path, ConfigData config)
        {
            QueryManager dal = null;
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

        public bool InsertRutaImagen(int ImagenRutaCodigo, string ImagenRutaDescripcion, int ImagenRutaAnio, int ImagenRutaMes, int ImagenRutaGrupo, string ImagenRutaPath, ConfigData config, out int RutaCodigo)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                return dal.InsertRutaImagen( ImagenRutaCodigo,  ImagenRutaDescripcion,  ImagenRutaAnio,  ImagenRutaMes,  ImagenRutaGrupo,  ImagenRutaPath,  config, out RutaCodigo);
            }
            catch (Exception)
            {
                RutaCodigo = -1;
                return false;
            }
        }

        public bool InsertFacturaImagen(int radicadoCodigo, string GrupoCodigo, string imagenNombre, int ImagenRutaCodigo, ConfigData config)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                return dal.InsertFacturaImagen(radicadoCodigo, GrupoCodigo, imagenNombre, ImagenRutaCodigo, config);
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool EliminarImagen(int FacturaCodigo, int FacturaImagenFolio, ConfigData config)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                return dal.EliminarImagen(FacturaCodigo, FacturaImagenFolio, config);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
