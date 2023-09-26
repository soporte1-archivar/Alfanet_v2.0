using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Alfanet.CommonObject
{
    public class ObjWorkFlowDocuments
    {
        [XmlElement("todos")]
        private List<ObjDocumentos> todos;

        [XmlElement("vencidos")]
        private List<ObjDocumentos> vencidos;

        [XmlElement("proximosAVencer")]
        private List<ObjDocumentos> proximosAVencer;

        [XmlElement("pendientes")]
        private List<ObjDocumentos> pendientes;

        [XmlElement("copiaExternos")]
        private List<ObjDocumentos> copiaExternos;

        [XmlElement("enviadosInternos")]
        private List<ObjDocumentos> enviadosInternos;

        [XmlElement("enviadosInternosCopia")]
        private List<ObjDocumentos> enviadosInternosCopia;

        [XmlElement("enSeguimiento")]
        private List<ObjDocumentos> enSeguimiento;

        public List<ObjDocumentos> Todos
        {
            get
            {
                return todos;
            }
            set
            {
                this.todos = value;
            }
        }
        public List<ObjDocumentos> Vencidos
        {
            get
            {
                return vencidos;
            }
            set
            {
                this.vencidos = value;
            }
        }
        public List<ObjDocumentos> ProximosAVencer
        {
            get
            {
                return proximosAVencer;
            }
            set
            {
                this.proximosAVencer = value;
            }
        }
        public List<ObjDocumentos> Pendientes
        {
            get
            {
                return pendientes;
            }
            set
            {
                this.pendientes = value;
            }
        }
        public List<ObjDocumentos> CopiaExternos
        {
            get
            {
                return copiaExternos;
            }
            set
            {
                this.copiaExternos = value;
            }
        }
        public List<ObjDocumentos> EnviadosInternos
        {
            get
            {
                return enviadosInternos;
            }
            set
            {
                this.enviadosInternos = value;
            }
        }
        public List<ObjDocumentos> EnviadosInternosCopia
        {
            get
            {
                return enviadosInternosCopia;
            }
            set
            {
                this.enviadosInternosCopia = value;
            }
        }
        public List<ObjDocumentos> EnSeguimiento
        {
            get
            {
                return enSeguimiento;
            }
            set
            {
                this.enSeguimiento = value;
            }
        }
    }
}
