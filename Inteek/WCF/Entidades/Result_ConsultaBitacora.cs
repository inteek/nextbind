using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class Result_ConsultaBitacora
    {
        public int id_Bitacora { get; set; }
        public int id_Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int id_Descripcion { get; set; }
        public int id_Estatus { get; set; }
        public int id_Ticket { get; set; }
    }
}