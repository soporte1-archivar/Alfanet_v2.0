using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    [Serializable]
    public class ObjGrupo
    {
        [XmlElement("grupoCodigo")]
        private string grupoCodigo;

        [XmlElement("grupoNombre")]
        private string grupoNombre;

        [XmlElement("grupoCodigoPadre")]
        private string grupoCodigoPadre;

        [XmlElement("grupoConsecutivo")]
        private int grupoConsecutivo;

        [XmlElement("grupoHabilitar")]
        private string grupoHabilitar;

        [XmlElement("grupopermiso")]
        private string grupopermiso;

        public string GrupoCodigo
        {
            get
            {
                return grupoCodigo;
            }
            set
            {
                this.grupoCodigo = value;
            }
        }

        public string GrupoNombre
        {
            get
            {
                return grupoNombre;
            }
            set
            {
                this.grupoNombre = value;
            }
        }

        public string GrupoCodigoPadre
        {
            get
            {
                return grupoCodigoPadre;
            }
            set
            {
                this.grupoCodigoPadre = value;
            }
        }

        public int GrupoConsecutivo
        {
            get
            {
                return grupoConsecutivo;
            }
            set
            {
                this.grupoConsecutivo = value;
            }
        }

        public string GrupoHabilitar
        {
            get
            {
                return grupoHabilitar;
            }
            set
            {
                this.grupoHabilitar = value;
            }
        }

        public string Grupopermiso
        {
            get
            {
                return grupopermiso;
            }
            set
            {
                this.grupopermiso = value;
            }
        }
    }
}
