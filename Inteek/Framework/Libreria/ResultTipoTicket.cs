using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Libreria
{
    public class ResultTipoTicket
    {
        public int idServicio { get; set; }
        public string descripcionServicio { get; set; }
        public string claveServicio { get; set; }
        public int? idServicioSuperior { get; set; }
        public string servicioSuperior { get; set; }
    }
}
