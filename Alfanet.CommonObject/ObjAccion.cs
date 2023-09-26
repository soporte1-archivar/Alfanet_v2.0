using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjAccion
    {
        [XmlElement("accionCodigo")]
        private string accionCodigo;

        [XmlElement("accionNombre")]
        private string accionNombre;

        public string AccionCodigo
        {
            get { return accionCodigo; }
            set { accionCodigo = value; }
        }

        public string AccionNombre
        {
            get { return accionNombre; }
            set { accionNombre = value; }
        }
    }
}
