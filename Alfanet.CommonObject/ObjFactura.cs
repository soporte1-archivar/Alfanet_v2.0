using System;
using System.Collections;
using System.Xml.Serialization;


namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjFactura
    {

        [XmlElement("radicadoCodigo")]//ok
        private string radicadoCodigo;

        public string RadicadoCodigo
        {
            get { return radicadoCodigo; }
            set { radicadoCodigo = value; }
        }

        [XmlElement("wFMovimientoFecha")]//ok
        private DateTime wFMovimientoFecha;

        public DateTime WFMovimientoFecha
        {
            get { return wFMovimientoFecha; }
            set { wFMovimientoFecha = value; }
        }

        [XmlElement("procedenciaNUI")]//ok
        private string procedenciaNUI;

        public string ProcedenciaNUI
        {
            get { return procedenciaNUI; }
            set { procedenciaNUI = value; }
        }

        [XmlElement("procedenciaNombre")]//ok
        private string procedenciaNombre;

        public string ProcedenciaNombre
        {
            get { return procedenciaNombre; }
            set { procedenciaNombre = value; }
        }

        [XmlElement("detalle")]//ok
        private string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        [XmlElement("expedienteCodigo")]//ok
        private string expedienteCodigo;

        public string ExpedienteCodigo
        {
            get { return expedienteCodigo; }
            set { expedienteCodigo = value; }
        }

        [XmlElement("expedienteNombre")]//ok
        private string expedienteNombre;

        public string ExpedienteNombre
        {
            get { return expedienteNombre; }
            set { expedienteNombre = value; }
        }

        [XmlElement("serie")]//ok
        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        [XmlElement("imagen")]//ok
        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        [XmlElement("dependenciaNombre")]//quien radica //ok
        private string dependenciaNombre;

        public string DependenciaNombre
        {
            get { return dependenciaNombre; }
            set { dependenciaNombre = value; }
        }     

        [XmlElement("facn_numero")]//ok
        private string facn_numero;

        [XmlElement("facn_empresa")]//ok
        private string facn_empresa;

        [XmlElement("facc_documento")]//ok
        private string facc_documento;

        [XmlElement("facn_ubicacion")]//ok
        private string facn_ubicacion;

        [XmlElement("facv_total")]//ok
        private double facv_total;

        [XmlElement("facc_estado")]//ok
        private string facc_estado;

        [XmlElement("facc_prefijo")]//ok
        private string facc_prefijo;

        [XmlElement("facn_factura2")]//ok
        private string facn_factura2;

        [XmlElement("facc_factura")]//ok
        private string facc_factura;

        [XmlElement("facc_alto_costo")]//ok
        private string facc_alto_costo;

        [XmlElement("terc_nombre")]//ok
        private string terc_nombre;

        [XmlElement("facf_confirmacion")]//ok
        private DateTime facf_confirmacion;

        [XmlElement("facn_recibo")]//ok
        private string facn_recibo;

        [XmlElement("facv_copago")]//ok
        private string facv_copago;

        [XmlElement("facv_responsable")]//ok
        private string facv_responsable;

        [XmlElement("facc_conciliado")]//ok
        private string facc_conciliado;

        [XmlElement("facv_imputable")]//ok
        private string facv_imputable;

               [XmlElement("facf_radicado")]//ok
        private DateTime facf_radicado;

        [XmlElement("facf_final")]//ok
        private DateTime facf_final;

        [XmlElement("comprobanteEgreso")]//ok
        private string comprobanteEgreso;

        public string ComprobanteEgreso
        {
            get { return comprobanteEgreso; }
            set { comprobanteEgreso = value; }
        }

        //[XmlElement("facc_digitalizado")]//ok
        //private string facc_digitalizado;

        [XmlElement("facc_almacenamiento")]//ok
        private string facc_almacenamiento;

        [XmlElement("cntc_concepto")]//ok
        private string cntc_concepto;

        [XmlElement("conc_nombre")]//ok
        private string conc_nombre;

        [XmlElement("facv_tercero")]//ok
        private string facv_tercero;
        
        

        [XmlElement("grupoCodigo")]//ok
        private string grupoCodigo;

        public string GrupoCodigo
        {
            get { return grupoCodigo; }
            set { grupoCodigo = value; }
        }

        

        [XmlElement("fechaProcedencia")]//ok
        private DateTime fechaProcedencia;

        public DateTime FechaProcedencia
        {
            get { return fechaProcedencia; }
            set { fechaProcedencia = value; }
        }        

        [XmlElement("naturalezaCodigo")]//ok
        private string naturalezaCodigo;

        public string NaturalezaCodigo
        {
            get { return naturalezaCodigo; }
            set { naturalezaCodigo = value; }
        }

        [XmlElement("naturalezaNombre")]//ok
        private string naturalezaNombre;

        public string NaturalezaNombre
        {
            get { return naturalezaNombre; }
            set { naturalezaNombre = value; }
        }

        [XmlElement("dependenciaCodigo")]//ok
        private string dependenciaCodigo;

        public string DependenciaCodigo
        {
            get { return dependenciaCodigo; }
            set { dependenciaCodigo = value; }
        }
                
        [XmlElement("fechaVencimiento")]//ok
        private DateTime fechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }        

        [XmlElement("medioCodigo")]//ok
        private string medioCodigo;

        public string MedioCodigo
        {
            get { return medioCodigo; }
            set { medioCodigo = value; }
        }

        [XmlElement("medioNombre")]//ok
        private string medioNombre;

        public string MedioNombre
        {
            get { return medioNombre; }
            set { medioNombre = value; }
        }

        [XmlElement("dependenciaCodDestino")]//ok
        private string dependenciaCodDestino;

        public string DependenciaCodDestino
        {
            get { return dependenciaCodDestino; }
            set { dependenciaCodDestino = value; }
        }

        [XmlElement("anexo")]//ok
        private string anexo;

        public string Anexo
        {
            get { return anexo; }
            set { anexo = value; }
        }

        [XmlElement("fechaRadicacion")]//ok
        private DateTime fechaRadicacion;

        public DateTime FechaRadicacion
        {
            get { return fechaRadicacion; }
            set { fechaRadicacion = value; }
        }

        [XmlElement("horaRadicacion")]//ok
        private DateTime horaRadicacion;

        public DateTime HoraRadicacion
        {
            get { return horaRadicacion; }
            set { horaRadicacion = value; }
        }


        [XmlElement("userId")]//ok
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [XmlElement("dependenciaNomDestino")]//ok
        private string dependenciaNomDestino;

        public string DependenciaNomDestino
        {
            get { return dependenciaNomDestino; }
            set { dependenciaNomDestino = value; }
        }               

        [XmlElement("userIdAud")]//ok
        private string userIdAud;

        public string UserIdAud
        {
            get { return userIdAud; }
            set { userIdAud = value; }
        }

        [XmlElement("fileName")]//ok
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        

        public string Facv_tercero//ok
        {
            get { return facv_tercero; }
            set { facv_tercero = value; }
        }

        public string Conc_nombre//ok
        {
            get { return conc_nombre; }
            set { conc_nombre = value; }
        }

        public string Cntc_concepto//ok
        {
            get { return cntc_concepto; }
            set { cntc_concepto = value; }
        }

        public string Facc_almacenamiento//ok
        {
            get { return facc_almacenamiento; }
            set { facc_almacenamiento = value; }
        }

        //public string Facc_digitalizado//ok
        //{
        //    get { return facc_digitalizado; }
        //    set { facc_digitalizado = value; }
        //}

        public DateTime Facf_final//ok
        {
            get { return facf_final; }
            set { facf_final = value; }
        }

        public DateTime Facf_radicado//ok
        {
            get { return facf_radicado; }
            set { facf_radicado = value; }
        }

       
        public string Facv_imputable//ok
        {
            get { return facv_imputable; }
            set { facv_imputable = value; }
        }

        public string Facc_conciliado//ok
        {
            get { return facc_conciliado; }
            set { facc_conciliado = value; }
        }

        public string Facv_responsable//ok
        {
            get { return facv_responsable; }
            set { facv_responsable = value; }
        }

        public string Facv_copago//ok
        {
            get { return facv_copago; }
            set { facv_copago = value; }
        }

        public string Facn_recibo//ok
        {
            get { return facn_recibo; }
            set { facn_recibo = value; }
        }

        public DateTime Facf_confirmacion//ok
        {
            get { return facf_confirmacion; }
            set { facf_confirmacion = value; }
        }

        public string Terc_nombre//ok
        {
            get { return terc_nombre; }
            set { terc_nombre = value; }
        }

        public string Facc_alto_costo//ok
        {
            get { return facc_alto_costo; }
            set { facc_alto_costo = value; }
        }

        public string Facc_factura//ok
        {
            get { return facc_factura; }
            set { facc_factura = value; }
        }

        public string Facn_factura2//ok
        {
            get { return facn_factura2; }
            set { facn_factura2 = value; }
        }

        public string Facc_prefijo//ok
        {
            get { return facc_prefijo; }
            set { facc_prefijo = value; }
        }

        public string Facc_estado//ok
        {
            get { return facc_estado; }
            set { facc_estado = value; }
        }

        public double Facv_total//ok
        {
            get { return facv_total; }
            set { facv_total = value; }
        }

        public string Facn_numero//ok
        {
            get { return facn_numero; }
            set { facn_numero = value; }
        }

        public string Facn_empresa//ok
        {
            get { return facn_empresa; }
            set { facn_empresa = value; }
        }

        public string Facc_documento//ok
        {
            get { return facc_documento; }
            set { facc_documento = value; }
        }

        public string Facn_ubicacion//ok
        {
            get { return facn_ubicacion; }
            set { facn_ubicacion = value; }
        }

    }
}
