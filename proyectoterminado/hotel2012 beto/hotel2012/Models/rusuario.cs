using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace hotel2012.Models
{
    public class rusuario
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string pasaporte { get; set; }
        public DateTime cumpleaños { get; set; }
        [RegularExpression("^[0-9]{7}$",ErrorMessage="errror tonto")]
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string comentario { get; set; }
        public int codigo_ciudad { get; set; }
        public string nick { get; set; }
        public string password1 { get; set; }
        [Display(Name="password de verificacion")]
        public string password2 { get; set; }
    }
}