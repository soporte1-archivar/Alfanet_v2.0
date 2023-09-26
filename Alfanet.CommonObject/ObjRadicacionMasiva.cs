using System;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    public class ObjRadicacionMasiva
    {
        [XmlElement("fecha_Procedencia")]
        private DateTime fecha_Procedencia;

        public DateTime Fecha_Procedencia
        {
            get { return fecha_Procedencia; }
            set { fecha_Procedencia = value; }
        }

        [XmlElement("fecha_vencimiento")]
        private DateTime fecha_vencimiento;

        public DateTime Fecha_vencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }

        [XmlElement("procedencia")]
        private string procedencia;

        public string Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }

        [XmlElement("naturaleza")]
        private string naturaleza;

        public string Naturaleza
        {
            get { return naturaleza; }
            set { naturaleza = value; }
        }
        
        [XmlElement("expediente")]
        private string expediente;

        public string Expediente
        {
            get { return expediente; }
            set { expediente = value; }
        }
        
        [XmlElement("dependenciaDestino")]
        private string dependenciaDestino;

        public string DependenciaDestino
        {
            get { return dependenciaDestino; }
            set { dependenciaDestino = value; }
        }

        [XmlElement("accion")]
        private string accion;

        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }

        [XmlElement("numeroDocumento")]
        private string numeroDocumento;
                public string NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }

    }
}
