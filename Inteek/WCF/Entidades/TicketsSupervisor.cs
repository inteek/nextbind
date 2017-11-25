using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class TicketsSupervisor
    {
        public int id_Ticket { get; set; }
        public string Titulo_ticket { get; set; }
        public string Descripcion_ticket { get; set; }
        public string Usuario { get; set; }
        public string Tipo_de_servicio { get; set; }
        public string Grupo { get; set; }
        public string Usuario_Asignado { get; set; }
        public string Estatus { get; set; }
    }
}