using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjParametros
    {
        [XmlElement("naturaleza")]
        private string naturaleza;

        [XmlElement("serie")]
        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        [XmlElement("dependencia_destino")]
        private string dependencia_destino;

        [XmlElement("medio")]
        private string medio;

        [XmlElement("accion")]
        private string accion;

        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }

        [XmlElement("expediente")]
        private string expediente;

        public string Expediente
        {
            get { return expediente; }
            set { expediente = value; }
        }


        public string Naturaleza
        {
            get { return naturaleza; }
            set { naturaleza = value; }
        }

        public string Dependencia_destino
        {
            get { return dependencia_destino; }
            set { dependencia_destino = value; }
        }

        public string Medio
        {
            get { return medio; }
            set { medio = value; }
        }

       
    }
}
