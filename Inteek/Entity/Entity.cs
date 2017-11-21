using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Entity
    {
        #region VARIABLES
        
        Exception _Error;
        #endregion
        [DataMember(Order = 1)]
        public int IdError { get; set; }

        [DataMember(Order = 2)]
        public string ErrorMessage { get; set; }
        public Exception Error
        {
            get { return _Error; }
        }

        //prueba

        public List<ValidaLogin_Result> validaLogin(string usuario, string password)
        {
            try
            {
                List<ValidaLogin_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ValidaLogin(usuario, password).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ValidaLogin_Result> resultado = null;
                return resultado;
            }
        }

        //REGISTRA USUARIOS
        public bool RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.RegistraDatosUsuario(nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor, id_Perfil);
                }

                return true;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                return false;
            }

           
        }

        //ACTUALIZA DATOS USUARIO

        //REGISTRA DISPOSITIVO


        //REGISTRA TICKET
        public bool RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            //idestatus por defecto deber ser nuevo "1"
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, ruta, idEstatus);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                return false;
            }
        }

        //ASIGNA TICKET
        public bool AsignaTicket(int id_Usuario, int id_Ticket, int idAgente, int idEstatus)
        {
            //idestatus por defecto debera recibir el de Asignado
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaTicket(id_Usuario, id_Ticket, idAgente, idEstatus);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                return false;
            }
        }

        public bool RegistraError(string message, string targetSite, string source, string stackTrace, string tipo)
        {
            try
            {
                ExceptionLog err = new ExceptionLog()
                {
                    Message = message,
                    Source = source,
                    TargetSite = targetSite,
                    StackTrace = stackTrace,
                    Tipo = tipo
                };
                using (var db = new InteekServiceEntities())
                {
                    db.ExceptionLog.Add(err);
                    db.SaveChanges();

                    IdError = err.Code;
                    ErrorMessage = err.Message;
                }
                return true;
            }
            catch(Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                return false;
            }
        }

    }
}
