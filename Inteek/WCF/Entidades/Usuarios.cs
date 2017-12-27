using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WCF.Entidades
{
    public class Usuario
    {
        public int id_Usuario { get; set; }

        public int id_Perfil { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }

        public string DomicilioDir { get; set; }

        public string DomicilioCor { get; set; }

    }
}