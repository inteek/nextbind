using Framework.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{//Prueba
    public class Ticket
    {
        #region VARIABLES
        Exception _Error;

        #endregion

        public bool RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            //idestatus por defecto deber ser nuevo "1"
            //prueba 2
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, idEstatus, ruta);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool AsignaTicket(int id_Usuario, int id_Ticket, int idAgente, int idEstatus)
        {
            //idestatus por defecto debera recibir el de Asignado
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.AsignaTicket(id_Usuario, id_Ticket, idAgente, idEstatus);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<ResultTicketsPorArea> ConsultaTicketsPorArea(int id_Usuario, int id_Area)
        {
            List<ResultTicketsPorArea> resultado = null;
            try
            {
                using (var db = new Entity.InteekServiceEntities())
                {
                    resultado = (from x in db.ConsultaTicketsPorArea(id_Usuario, id_Area)
                                 select new ResultTicketsPorArea
                                 {
                                     id_Ticket = x.id_Ticket,
                                     Titulo_ticket = x.Titulo_ticket,
                                     Descripcion_ticket = x.Descripcion_ticket,
                                     Usuario = x.Usuario,
                                     Tipo_de_servicio = x.Tipo_de_servicio,
                                     Grupo = x.Grupo,
                                     Usuario_Asignado = x.Usuario_Asignado,
                                     Estatus = x.Estatus
                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultTicketsNoAsignados> ConsultaTicketsNoAsignados(int idusuario)
        {
            List<ResultTicketsNoAsignados> resultado = null;
            try
            {

                using (var db = new Entity.InteekServiceEntities())
                {
                    resultado = (from x in db.ConsultaTicketsNoAsignados(idusuario)
                                 select new ResultTicketsNoAsignados
                                 {
                                     id_Ticket = x.id_Ticket,
                                     Titulo_ticket = x.Titulo_ticket,
                                     Descripcion_ticket = x.Descripcion_ticket,
                                     Usuario = x.Usuario,
                                     Tipo_de_servicio = x.Tipo_de_servicio,
                                     Grupo = x.Grupo,
                                     Usuario_Asignado = x.Usuario_Asignado,
                                     Estatus = x.Estatus
                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultTicketsPorCliente> ConsultaTicketsPorCliente(int cliente)//creados
        {
            List<ResultTicketsPorCliente> resultado = null;
            try
            {

                using (var db = new Entity.InteekServiceEntities())
                {
                    resultado = (from x in db.ConsultaTicketsCreados(cliente)
                                 select new ResultTicketsPorCliente
                                 {
                                     id_Ticket = x.id_Ticket,
                                     Titulo_ticket = x.Titulo_ticket,
                                     Descripcion_ticket = x.Descripcion_ticket,
                                     Tipo_de_servicio = x.Tipo_de_servicio,
                                     Grupo = x.Grupo,
                                     Usuario_Asignado = x.Usuario_Asignado,
                                     Fecha = x.Fecha,
                                     Estatus = x.Estatus,
                                     Ruta = x.Ruta
                                 }).ToList();

                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultTicketsPorAgente> ConsultaTicketsPorAgente(int id_Usuario)//creados
        {
            List<ResultTicketsPorAgente> resultado = null;
            try
            {
                using (var db = new Entity.InteekServiceEntities())
                {
                    resultado = (from x in db.ConsultaTicketsCreados(id_Usuario)
                                 select new ResultTicketsPorAgente
                                 {
                                     id_Ticket = x.id_Ticket,
                                     Titulo_ticket = x.Titulo_ticket,
                                     Descripcion_ticket = x.Descripcion_ticket,
                                     Tipo_de_servicio = x.Tipo_de_servicio,
                                     Grupo = x.Grupo,
                                     Usuario_Asignado = x.Usuario_Asignado,
                                     Fecha = x.Fecha,
                                     Estatus = x.Estatus,
                                     Ruta = x.Ruta
                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public bool ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario)
        {
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.ActualizaTicketEnProceso(id_Ticket, idEstatus, id_Usuario);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool ActualizaTickedEnAprobacion(int id_Ticket, int idEstatus, int id_Usuario, int solucion)
        {
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.ActualizaTickedEnAprobacion(id_Ticket, idEstatus, id_Usuario, solucion);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo)
        {
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.ActualizaTickedAFinalizado(id_Ticket, idEstatus, id_Usuario, motivorechazo);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<ResultTickets> ConsultaTickets()
        {
            List<ResultTickets> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                resultado = objEntity.ConsultaTickets().Select(
                    x => new ResultTickets
                    {
                        id_Ticket = x.id_Ticket,
                        Titulo_ticket = x.Titulo_ticket,
                        Descripcion_ticket = x.Descripcion_ticket,
                        Usuario = x.Usuario,
                        Tipo_de_servicio = x.Tipo_de_servicio,
                        Grupo = x.Grupo,
                        Usuario_Asignado = x.Usuario_Asignado,
                        Estatus = x.Estatus,
                    }).ToList();
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultTicketsSupervisor> ConsultaTicketsSupervisor(int id_Usuario)
        {
            List<ResultTicketsSupervisor> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                resultado = objEntity.ConsultaTicketsSupervisor(id_Usuario).Select(
                    x => new ResultTicketsSupervisor
                    {
                        id_Ticket = x.id_Ticket,
                        Titulo_ticket = x.Titulo_ticket,
                        Descripcion_ticket = x.Descripcion_ticket,
                        Usuario = x.Usuario,
                        Tipo_de_servicio = x.Tipo_de_servicio,
                        Grupo = x.Grupo,
                        Usuario_Asignado = x.Usuario_Asignado,
                        Estatus = x.Estatus,
                    }).ToList();
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public Exception Error
        {
            get { return _Error; }
        }
    }
}
