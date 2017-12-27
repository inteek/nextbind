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
       
        [DataMember(Order = 1)]
        public int IdError { get; set; }

        [DataMember(Order = 2)]
        public string ErrorMessage { get; set; }
        public Exception Error
        {
            get { return _Error; }
        }
        #endregion

        ////VALIDA LOGIN
        //public List<ValidaLogin_Result> validaLogin(string usuario, string password)
        //{
        //    try
        //    {
        //        List<ValidaLogin_Result> resultado = null;
        //        using (var db = new InteekServiceEntities())
        //        {
        //            resultado = db.ValidaLogin(usuario, password).ToList();
        //        }
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Error = new Exception();
        //        _Error = ex;
        //        List<ValidaLogin_Result> resultado = null;
        //        return resultado;
        //    }
        //}

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
        public bool ActualizaDatosUsuario(int id_Usuario, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaDatosUsuario(nombre, apellidoPaterno, apellidoMaterno, domicilioDir, domicilioCor, 1, id_Usuario);
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

        //CONSULTA USUARIOS
        public List<ConsultaUsuarios_Result> ConsultarUsuarios()
        {
            try
            {
                List<ConsultaUsuarios_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaUsuarios().ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaUsuarios_Result> resultado = null;
                return resultado;
            }
        }
        
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

        //CINSULTA TICKET POR AREA
        public List<ConsultaTicketsPorArea_Result> ConsultaTicketsPorArea(int id_Usuario, int id_Area)
        {
            try
            {
                List<ConsultaTicketsPorArea_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTicketsPorArea(id_Usuario, id_Area).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTicketsPorArea_Result> resultado = null;
                return resultado;
            }
        }

        //ACTUALIZA TICKET EN PROCESO
        public bool ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketEnProceso(id_Usuario, id_Ticket, idEstatus);
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

        //ACTUALIZA TICKET EN APROBACION
        public bool ActualizaTickedEnAprobacion(int id_Ticket, int idEstatus, int id_Usuario, int solucion)
        {
            //validar con Cesar
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketEnAprobacion(id_Usuario, id_Ticket, idEstatus, solucion);
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

        //ACTUALIZA TICKET A FINALIZADO
        public bool ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketAFinalizado(id_Usuario, id_Ticket, idEstatus, motivorechazo);
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

        //CONSULTA BITACORA POR TICKET
        public List<ConsultaBitacoraPorTicket_Result> ConsultaBitacoraPorTicket(int id_Ticket)
        {
            try
            {
                List<ConsultaBitacoraPorTicket_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaBitacoraPorTicket(id_Ticket).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaBitacoraPorTicket_Result> resultado = null;
                return resultado;
            }
        }

        //CONSULTA TICKETS NO ASIGNADOS
        public List<ConsultaTicketsNoAsignados_Result> ConsultaTicketsNoAsignados(int idusuario, int idGrupo)
        {
            try
            {
                List<ConsultaTicketsNoAsignados_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTicketsNoAsignados(idusuario, idGrupo).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTicketsNoAsignados_Result> resultado = null;
                return resultado;
            }
        }
        
        //CONSULTA TICKETS POR CLIENTE
        public List<ConsultaTicketsCreados_Result> ConsultaTicketsPorCliente(int cliente)
        {
            try
            {
                List<ConsultaTicketsCreados_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTicketsCreados(cliente).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTicketsCreados_Result> resultado = null;
                return resultado;
            }
        }
        //CONSULTA TICKETS POR AGENTE 
        public List<ConsultaTicketsAsignados_Result> ConsultaTicketsPorAgente(int id_Usuario)
        {
            try
            {
                List<ConsultaTicketsAsignados_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTicketsAsignados(id_Usuario).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTicketsAsignados_Result> resultado = null;
                return resultado;
            }
        }

        //CONSULTA AREAS POR USUARIO
        public List<ConsultaAreasPorUsuario_Result> ConsultaAreasPorUsuario(int id_Usuario)
        {
            try
            {
                List<ConsultaAreasPorUsuario_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaAreasPorUsuario(id_Usuario).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaAreasPorUsuario_Result> resultado = null;
                return resultado;
            }
        }

        //CONSULTA TICKETS
        public List<ConsultaTickets_Result> ConsultaTickets()
        {
            try
            {
                List<ConsultaTickets_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTickets().ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTickets_Result> resultado = null;
                return resultado;
            }
        }

        //CONSULTA TICKETS SUPERVISOR
        public List<ConsultaTicketsSupervisor_Result> ConsultaTicketsSupervisor(int id_Usuario)
        {
            try
            {
                List<ConsultaTicketsSupervisor_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTicketsSupervisor(id_Usuario).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTicketsSupervisor_Result> resultado = null;
                return resultado;
            }
        }

        //ASIGNA GRUPO USUARIO
        public bool AsignaGrupoUsuario(int id_Area, int id_Usuario)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaGrupoUsuario(id_Area, id_Usuario);
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

        //ASIGNA SUPERVISOR GRUPO
        public bool AsignaSupervisorGrupo(int id_Area, int id_Usuario, bool supervisa, int id_Asociar)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaSupervisorGrupo(id_Area, id_Usuario, supervisa, id_Asociar);
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

        //ASIGNA TIPO SERVICIO GRUPO
        public bool AsignaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaTipoServicioGrupo(id_TipoServicio, id_Grupo);
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

        //CONSULTA TIPO SERVICIO GRUPO
        public List<ConsultaTipoServicioGrupo_Result> ConsultaTipoServicioGrupo(int id_Grupo)
        {
            try
            {
                List<ConsultaTipoServicioGrupo_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTipoServicioGrupo(id_Grupo).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaTipoServicioGrupo_Result> resultado = null;
                return resultado;
            }
        }
        
        //ELIMINA TIPO SERVICIO GRUPO
        public bool EliminaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.EliminaTipoServicioGrupo(id_TipoServicio, id_Grupo);
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

        //CONSULTA USUARIO GRUPO 
        public List<ConsultaUsuarioGrupo_Result> ConsultaUsuarioGrupo(int id_Grupo)
        {
            try
            {
                List<ConsultaUsuarioGrupo_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaUsuarioGrupo(id_Grupo).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaUsuarioGrupo_Result> resultado = null;
                return resultado;
            }
        }
        
        //ELIMINA USUARIO GRUPO 
        public bool EliminaUsuarioGrupo(int id_Area, int id_Usuario, int id_Asociar)
        {
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    db.EliminaUsuarioGrupo(id_Area, id_Usuario, id_Asociar);
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
        
        //CONSULTA CAUSA SOLUCION
        public List<ConsultaCausaSolucion_Result> ConsultaCausaSolucion()
        {
            try
            {
                List<ConsultaCausaSolucion_Result> resultado = null;
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaCausaSolucion().ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                _Error = new Exception();
                _Error = ex;
                List<ConsultaCausaSolucion_Result> resultado = null;
                return resultado;
            }
        }

        //REGISTRAR ERROR
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
