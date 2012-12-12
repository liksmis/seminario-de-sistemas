using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel2012.Models
{
    public class habitacio
    {
        public int codigo_habitacion { set; get; }
        public int numero { set; get; }
        public int piso { set; get; }
        public decimal precio { set; get; }
        public int estado { set; get; }
        public int codigo_categoria { set; get; }
        public string categoria { set; get; }
        public bool selecionado { set; get; }
    }
}