using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class UsuarioGrupo
    {
        public int id_AsociarGU { get; set; }
        public int id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Grupo { get; set; }
        public string Supervisa { get; set; }
        public string Activo { get; set; }
    }
}