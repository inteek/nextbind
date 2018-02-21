using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class TipoTicket
    {
        public int idServicio { get; set; }
        public string descripcionServicio { get; set; }
        public string claveServicio { get; set; }
        public int? idServicioSuperior { get; set; }

        public string servicioSuperior { get; set; }
    }
}