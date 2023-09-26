using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjMedio
    {
        [XmlElement("medioCodigo")]
        private string medioCodigo;

        [XmlElement("medioNombre")]
        private string medioNombre;

        public string MedioCodigo
        {
            get { return medioCodigo; }
            set { medioCodigo = value; }
        }

        public string MedioNombre
        {
            get { return medioNombre; }
            set { medioNombre = value; }
        }
    }
}
