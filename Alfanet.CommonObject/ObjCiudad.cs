using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjCiudad
    {
        [XmlElement("ciudadCodigo")]
        private string ciudadCodigo;

        [XmlElement("ciudadNombre")]
        private string ciudadNombre;

        public string CiudadCodigo
        {
            get { return ciudadCodigo; }
            set { ciudadCodigo = value; }
        }

        public string CiudadNombre
        {
            get { return ciudadNombre; }
            set { ciudadNombre = value; }
        }
    }
}
