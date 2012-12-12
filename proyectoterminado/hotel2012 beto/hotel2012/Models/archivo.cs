using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel2012.Models
{
    public class archivopersona
    {
        public int codigo_cliente { get; set; }
        public string nombre { get; set; }
        public string telefono{ get; set; }
        public string email{ get; set; }
        public string direccion{ get; set; }
        public string estado{ get; set; }
        public string comentario{ get; set; }
        public string pais{ get; set; }
        public string ciudad{ get; set; }
        public int codigo_persona { get; set; }
        public string paterno{ get; set; }
        public string materno{ get; set; }
        public string pasaporte { get; set; }
        public DateTime cumpleaños{ get; set; }

    }
    public class archivoempresa
    {
        public int codigo_cliente { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string comentario { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public int codigo_empresa { get; set; }
        public long  nit { get; set; }
        public string contacto { get; set; }
        public string metodo_pago { get; set; }
        //public DateTime cumpleaños { get; set; }

    }
    public class archivoagencia
    {
        public int codigo_cliente { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string comentario { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public int codigo_agencia { get; set; }
        public long nit { get; set; }
        public string contacto { get; set; }
       // public string metodo_pago { get; set; }
        //public DateTime cumpleaños { get; set; }

    }
}