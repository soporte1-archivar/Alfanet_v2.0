using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjExpediente
    {
        [XmlElement("expedienteCodigo")]
        private string expedienteCodigo;

        [XmlElement("expedienteNombre")]
        private string expedienteNombre;

        public string ExpedienteCodigo
        {
            get { return expedienteCodigo; }
            set { expedienteCodigo = value; }
        }

        public string ExpedienteNombre
        {
            get { return expedienteNombre; }
            set { expedienteNombre = value; }
        }
    }
}
