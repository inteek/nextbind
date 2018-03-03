using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class TicketsPorCliente
    {
        public int id_Ticket { get; set; }
        public string Titulo_ticket { get; set; }
        public string Descripcion_ticket { get; set; }
        public string Tipo_de_servicio { get; set; }
        public string Grupo { get; set; }
        public string Usuario_Asignado { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string Ruta { get; set; }

        public TicketsPorCliente()
        {
            id_Ticket = 0;
            Titulo_ticket = "";
            Descripcion_ticket = "";
            Tipo_de_servicio = "";
            Grupo = "";
            Usuario_Asignado = "";
            Fecha = System.DateTime.Now;
            Estatus = "";
            Ruta = "";
        }

    }
}