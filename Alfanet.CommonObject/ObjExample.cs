using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjExample
    {
        [XmlElement("descripcion")]
        private string descripcion;

        [XmlElement("tipoSolicitud")]
        private int tipoSolicitud;

        [XmlElement("prioridadSolicitud")]
        private int prioridadSolicitud;

        [XmlElement("estadoSolicitud")]
        private int estadoSolicitud;

        [XmlElement("fechaSolicitud")]
        private DateTime fechaSolicitud;

        [XmlElement("fechaEstado")]
        private DateTime fechaEstado;

        [XmlElement("cliente")]
        private int cliente;

        [XmlElement("dataBaseEngine")]
        private int dataBaseEngine;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
        public int TipoSolicitud
        {
            get
            {
                return tipoSolicitud;
            }
            set
            {
                this.tipoSolicitud = value;
            }
        }
        public int PrioridadSolicitud
        {
            get
            {
                return prioridadSolicitud;
            }
            set
            {
                this.prioridadSolicitud = value;
            }
        }
        public int EstadoSolicitud
        {
            get
            {
                return estadoSolicitud;
            }
            set
            {
                this.estadoSolicitud = value;
            }
        }
        public DateTime FechaSolicitud
        {
            get
            {
                return fechaSolicitud;
            }
            set
            {
                this.fechaSolicitud = value;
            }
        }
        public DateTime FechaEstado
        {
            get
            {
                return fechaEstado;
            }
            set
            {
                this.fechaEstado = value;
            }
        }
        public int Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                this.cliente = value;
            }
        }
        public int DataBaseEngine
        {
            get
            {
                return dataBaseEngine;
            }
            set
            {
                this.dataBaseEngine = value;
            }
        }
    }
}
