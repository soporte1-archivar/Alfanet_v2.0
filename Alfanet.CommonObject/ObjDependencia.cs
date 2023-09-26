using System;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjDependencia
    {
        [XmlElement("dependenciaCodigo")]
        private string dependenciaCodigo;        

        [XmlElement("dependenciaNombre")]
        private string dependenciaNombre;

        [XmlElement("userId")]
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string DependenciaCodigo
        {
            get { return dependenciaCodigo; }
            set { dependenciaCodigo = value; }
        }

        public string DependenciaNombre
        {
            get { return dependenciaNombre; }
            set { dependenciaNombre = value; }
        }
    }
}
