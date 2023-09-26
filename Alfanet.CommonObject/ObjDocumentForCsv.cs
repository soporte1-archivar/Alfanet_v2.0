using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace Alfanet.CommonObject
{
    

    [DelimitedRecord(",")]
    public class ObjDocumentForCsv
    {
        public string facn_empresa;

        public string facc_documento;

        public string facn_numero;

        public string facn_ubicacion;

        public string facv_tercero;

        public string facv_total;

        public string facc_estado;

        public string facc_prefijo;

        public string facn_factura2;

        public string facc_factura;

        public string facc_alto_costo;

        public string terc_nombre;

        public string facn_recibo;

        public string facv_copago;

        public string facv_responsable;

        public string facc_conciliado;

        public string facv_imputable;

        public string facf_confirmacion;

        public string facf_radicado;

        public string facf_final;

        public string facc_almacenamiento;

        public string cntc_concepto;

        public string conc_nombre;
    }
}
