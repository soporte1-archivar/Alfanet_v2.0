using System;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjDocumentos
    {
        [XmlElement("numeroDocumento")]
        private string numeroDocumento;

        [XmlElement("procedenciaNombre")]
        private string procedenciaNombre;

        [XmlElement("procedenciaNUI")]
        private string procedenciaNUI;

        [XmlElement("fechaVencimiento")]
        private string fechaVencimiento;

        [XmlElement("dependenciaNombre")]
        private string dependenciaNombre;

        [XmlElement("wFMovimientoNotas")]
        private string wFMovimientoNotas;

        [XmlElement("wFAccionNombre")]
        private string wFAccionNombre;

        [XmlElement("radicadoDetalle")]
        private string radicadoDetalle;

        [XmlElement("naturalezaNombre")]
        private string naturalezaNombre;

        [XmlElement("fechaRadicacion")]
        private string fechaRadicacion;

        [XmlElement("numeroExterno")]
        private string numeroExterno;

        [XmlElement("fechaProcedencia")]
        private string fechaProcedencia;

        [XmlElement("medioNombre")]
        private string medioNombre;

        [XmlElement("expedienteNombre")]
        private string expedienteNombre;

        [XmlElement("dependenciaDestino")]
        private string dependenciaDestino;

        [XmlElement("anexo")]
        private string anexo;        

        [XmlElement("respuesta")]
        private string respuesta;

        [XmlElement("grupoCodigo")]
        private string grupoCodigo;

        [XmlElement("grupoNombre")]
        private string grupoNombre;

        [XmlElement("procedenciaCodigo")]
        private string procedenciaCodigo;

        [XmlElement("naturalezaCodigo")]
        private string naturalezaCodigo;

        [XmlElement("dependenciaCodigo")]
        private string dependenciaCodigo;

        [XmlElement("radicadoGuia")]
        private string radicadoGuia;

        [XmlElement("expedienteCodigo")]
        private string expedienteCodigo;

        [XmlElement("medioCodigo")]
        private string medioCodigo;

        [XmlElement("radicadoPadre")]
        private string radicadoPadre;

        [XmlElement("fechaImposicion")]
        private string fechaImposicion;

        [XmlElement("placaVehiculo")]
        private string placaVehiculo;

        [XmlElement("codInfraccion")]
        private string codInfraccion;

        [XmlElement("observaciones")]
        private string observaciones;

        [XmlElement("wfmovimientoFecha")]
        private string wfmovimientoFecha;

        [XmlElement("serieCodigo")]
        private string serieCodigo;

        [XmlElement("codDestino")]
        private string codDestino;

        [XmlElement("fileName")]
        private string fileName;

        [XmlElement("iuit")]
        private string iuit;

        [XmlElement("imagen")]
        private string imagen;

        [XmlElement("radicadoFuente")]
        private string radicadoFuente;

        [XmlElement("registroTipo")]
        private string registroTipo;

        [XmlElement("tipoDocumento")]
        private string tipoDocumento;

        [XmlElement("tipoNotificacion")]
        private string tipoNotificacion;

        [XmlElement("modalidad")]
        private string modalidad;

        [XmlElement("direccion")]
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Modalidad
        {
            get { return modalidad; }
            set { modalidad = value; }
        }

        public string TipoNotificacion
        {
            get { return tipoNotificacion; }
            set { tipoNotificacion = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }


        public string RegistroTipo
        {
            get { return registroTipo; }
            set { registroTipo = value; }
        }

        public string RadicadoFuente
        {
            get { return radicadoFuente; }
            set { radicadoFuente = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public string Iuit
        {
            get { return iuit; }
            set { iuit = value; }
        }


        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        public string SerieCodigo
        {
            get { return serieCodigo; }
            set { serieCodigo = value; }
        }

        public string WfmovimientoFecha
        {
            get { return wfmovimientoFecha; }
            set { wfmovimientoFecha = value; }
        }

       
       

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }


        public string CodInfraccion
        {
            get { return codInfraccion; }
            set { codInfraccion = value; }
        }
        
        public string PlacaVehiculo
        {
            get { return placaVehiculo; }
            set { placaVehiculo = value; }
        }


        public string FechaImposicion
        {
            get { return fechaImposicion; }
            set { fechaImposicion = value; }
        }
        

        public string RadicadoPadre
        {
            get { return radicadoPadre; }
            set { radicadoPadre = value; }
        }

        public string MedioCodigo
        {
            get { return medioCodigo; }
            set { medioCodigo = value; }
        }

        public string ExpedienteCodigo
        {
            get { return expedienteCodigo; }
            set { expedienteCodigo = value; }
        }

        public string RadicadoGuia
        {
            get { return radicadoGuia; }
            set { radicadoGuia = value; }
        }

        public string DependenciaCodigo
        {
            get { return dependenciaCodigo; }
            set { dependenciaCodigo = value; }
        }

        public string NaturalezaCodigo
        {
            get { return naturalezaCodigo; }
            set { naturalezaCodigo = value; }
        }

        public string ProcedenciaCodigo
        {
            get { return procedenciaCodigo; }
            set { procedenciaCodigo = value; }
        }

        public string GrupoNombre
        {
            get { return grupoNombre; }
            set { grupoNombre = value; }
        }

        public string GrupoCodigo
        {
            get { return grupoCodigo; }
            set { grupoCodigo = value; }
        }


        [XmlElement("leido")]
        private string leido;

        public string Leido
        {
            get { return leido; }
            set { leido = value; }
        }
        
        public string NumeroDocumento
        {
            get{return numeroDocumento;}
            set{this.numeroDocumento = value;}
        }
        public string ProcedenciaNombre
        {
            get{return procedenciaNombre;}
            set{this.procedenciaNombre = value;}
        }
        public string ProcedenciaNUI
        {
            get{return procedenciaNUI;}
            set{this.procedenciaNUI = value;}
        }
        public string FechaVencimiento
        {
            get{return fechaVencimiento;}
            set{this.fechaVencimiento = value;}
        }
        public string DependenciaNombre
        {
            get{return dependenciaNombre;}
            set{this.dependenciaNombre = value;}
        }
        public string WFMovimientoNotas
        {
            get{return wFMovimientoNotas;}
            set{this.wFMovimientoNotas = value;}
        }
        public string WFAccionNombre
        {
            get{return wFAccionNombre;}
            set{this.wFAccionNombre = value;}
        }
        public string RadicadoDetalle
        {
            get{return radicadoDetalle;}
            set{this.radicadoDetalle = value;}
        }
        public string NaturalezaNombre
        {
            get{return naturalezaNombre;}
            set{this.naturalezaNombre = value;}
        }
        public string FechaRadicacion
        {
            get{return fechaRadicacion;}
            set{this.fechaRadicacion = value;}
        }
        public string NumeroExterno
        {
            get{return numeroExterno;}
            set{this.numeroExterno = value;}
        }
        public string FechaProcedencia
        {
            get{return fechaProcedencia;}
            set{this.fechaProcedencia = value;}
        }
        public string MedioNombre
        {
            get{return medioNombre;}
            set{this.medioNombre = value;}
        }
        public string ExpedienteNombre
        {
            get{return expedienteNombre;}
            set{this.expedienteNombre = value;}
        }
        public string DependenciaDestino
        {
            get{return dependenciaDestino;}
            set{this.dependenciaDestino = value;}
        }
        public string Anexo
        {
            get{return anexo;}
            set{this.anexo = value;}
        }
        public string Respuesta
        {
            get{return respuesta;}
            set{this.respuesta = value;}
        }
    }
}
