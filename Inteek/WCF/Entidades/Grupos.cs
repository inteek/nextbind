using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class Grupos
    {
        public int idGrupo { get; set; }
        public string descripcionGrupo { get; set; }
        public string claveGrupo { get; set; }
        public int? idGrupoSuperior { get; set; }
    }
}