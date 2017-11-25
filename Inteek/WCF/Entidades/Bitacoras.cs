using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class Bitacoras
    {
        public int id_Bitacora { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Bitacora { get; set; }
        public string Estatus { get; set; }
        public int id_Ticket { get; set; }
    }
}