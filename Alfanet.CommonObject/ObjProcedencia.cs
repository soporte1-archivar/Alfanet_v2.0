using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjProcedencia
    {
        [XmlElement("procedenciaCodigo")]
        private string procedenciaCodigo;        

        [XmlElement("procedenciaNombre")]
        private string procedenciaNombre;

        [XmlElement("procedenciaDireccion")]
        private string procedenciaDireccion;

        [XmlElement("ciudadNombre")]
        private string ciudadNombre;

        public string CiudadNombre
        {
            get { return ciudadNombre; }
            set { ciudadNombre = value; }
        }

        public string ProcedenciaDireccion
        {
            get { return procedenciaDireccion; }
            set { procedenciaDireccion = value; }
        }

        public string ProcedenciaCodigo
        {
            get { return procedenciaCodigo; }
            set { procedenciaCodigo = value; }
        }

        public string ProcedenciaNombre
        {
            get { return procedenciaNombre; }
            set { procedenciaNombre = value; }
        }
    }
}