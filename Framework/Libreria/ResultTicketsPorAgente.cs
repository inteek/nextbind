﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Libreria
{
    public class ResultTicketsPorAgente
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
    }
}