using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjNaturaleza
    {
        [XmlElement("naturalezaCodigo")]
        private string naturalezaCodigo;

        [XmlElement("naturalezaNombre")]
        private string naturalezaNombre;

        public string NaturalezaCodigo
        {
            get { return naturalezaCodigo; }
            set { naturalezaCodigo = value; }
        }

        public string NaturalezaNombre
        {
            get { return naturalezaNombre; }
            set { naturalezaNombre = value; }
        }
    }
}
