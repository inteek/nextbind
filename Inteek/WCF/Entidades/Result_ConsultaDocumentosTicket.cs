using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entidades
{
    public class Result_ConsultaDocumentosTicket
    {
        public int id_Documento { get; set; }

        public string Ruta { get; set; }

        public int id_ticket { get; set; }
    }
}