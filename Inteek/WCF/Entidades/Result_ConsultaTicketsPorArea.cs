using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class Result_ConsultaTicketsPorArea
    {
        public int id_Ticked { get; set; }

        public int id_UsuarioLevanta { get; set; }

        public string Titulo_ticket { get; set; }

        public string Descripcion_ticket { get; set; }

        public int Tipo_servicio { get; set; }

        public int id_Area { get; set; }

        public int id_UsuarioAsignado { get; set; }

        public int id_Estatus { get; set; }

        public DateTime Fecha { get; set; }
    }
}