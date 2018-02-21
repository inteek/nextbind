using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Libreria
{
   public class ResultGrupos
    {
        public int idGrupo { get; set; }
        public string descripcionGrupo { get; set; }
        public string claveGrupo { get; set; }
        public int? idGrupoSuperior { get; set; }
    }
}
