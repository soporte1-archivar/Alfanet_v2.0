using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfanet.Dal;
using Alfanet.CommonObject;
using System.Data;

namespace Alfanet.Bll
{
    public class AdminBLL
    {
        public List<ObjGrupo> selectGrupo(ConfigData config)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                ObjGrupo grupo = null;
                DataSet ds = new DataSet();
                List<ObjGrupo> lisObjGrupo = new List<ObjGrupo>();
                ds = dal.selectAdminGrupo(config);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    grupo = new ObjGrupo();
                    grupo.GrupoCodigo=dr.ItemArray[0].ToString();
                    grupo.GrupoNombre = dr.ItemArray[1].ToString();
                    grupo.GrupoCodigoPadre = dr.ItemArray[2].ToString();
                    grupo.GrupoConsecutivo = Convert.ToInt32(dr.ItemArray[3].ToString());
                    grupo.GrupoHabilitar = dr.ItemArray[4].ToString();
                    grupo.Grupopermiso = dr.ItemArray[5].ToString();
                    lisObjGrupo.Add(grupo);
                    grupo = null;
                }
                return lisObjGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string insertGrupo(ConfigData config)
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                int result = dal.insertAdminGrupo(config);
                if (result > 0)
                {
                    return "Registro insertado correctamente.";
                }
                else
                {
                    return "El registro no pudo ser insertado.";
                }
            }
            catch (Exception)
            {
                return "Error al insertar el Grupo.";
            }
        }

        public string updateGrupo()
        {
            QueryManager dal = null;
            try
            {
                dal = new QueryManager();
                return "encontro grupos";
            }
            catch (Exception)
            {
                return "Error al Consultar los Grupos.";
            }
        }
    }
}
