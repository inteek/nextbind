using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entidades;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;

namespace WCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Ticket" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Ticket.svc o Ticket.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Ticket : ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea>
    {
        public Response<string> RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            //idestatus por defecto deber ser nuevo "1"
            try
            {
                var objFramework = new Framework.Ticket();
                objFramework.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, idEstatus, ruta);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }
                else
                {
                    ResponseError<String> result = new ResponseError<String>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }
        public Response<string> AsignaTicket(int id_Usuario, int id_Ticket, int idAgente, int idEstatus)
        {
            //idestatus por defecto debera recibir el de Asignado
            try
            {
                var objFramework = new Framework.Ticket();
                objFramework.AsignaTicket(id_Usuario, id_Ticket, idAgente, idEstatus);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }
                else
                {
                    ResponseError<String> result = new ResponseError<String>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }
        public Response<Entidades.TicketsPorArea> ConsultaTicketsPorArea(int id_Usuario, int id_Area)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTicketsPorArea> lista = objFramework.ConsultaTicketsPorArea(id_Usuario, id_Area);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TicketsPorArea> result = new Response<TicketsPorArea>();
                    result.List = objFramework.ConsultaTicketsPorArea(id_Usuario, id_Area).Select
                        (x => new Entidades.TicketsPorArea
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.TicketsPorArea> result = new ResponseError<Entidades.TicketsPorArea>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TicketsPorArea> result = new ResponseError<Entidades.TicketsPorArea>(ex);
                return result;
            }
        }
        public Response<Entidades.TicketsPorCliente> ConsultaTicketsPorCliente(int cliente)//creados
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTicketsPorCliente> lista = objFramework.ConsultaTicketsPorCliente(cliente);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TicketsPorCliente> result = new Response<Entidades.TicketsPorCliente>();
                    result.List = lista.Select
                        (x => new Entidades.TicketsPorCliente
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.TicketsPorCliente> result = new ResponseError<Entidades.TicketsPorCliente>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TicketsPorCliente> result = new ResponseError<Entidades.TicketsPorCliente>(ex);
                return result;
            }
        }
        public Response<Entidades.TicketsPorAgente> ConsultaTicketsPorAgente(int id_Usuario)//asignados
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTicketsPorAgente> lista = objFramework.ConsultaTicketsPorAgente(id_Usuario);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TicketsPorAgente> result = new Response<Entidades.TicketsPorAgente>();
                    result.List = objFramework.ConsultaTicketsPorAgente(id_Usuario).Select
                        (x => new Entidades.TicketsPorAgente
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.TicketsPorAgente> result = new ResponseError<Entidades.TicketsPorAgente>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TicketsPorAgente> result = new ResponseError<Entidades.TicketsPorAgente>(ex);
                return result;
            }
        }
        public Response<string> ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                objFramework.ActualizaTicketEnProceso(id_Ticket, idEstatus, id_Usuario);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }
                else
                {
                    ResponseError<String> result = new ResponseError<String>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }
        public Response<string> ActualizaTickedEnAprobacion(int id_Ticket, int idEstatus, int id_Usuario, int solucion)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                objFramework.ActualizaTickedEnAprobacion(id_Ticket, idEstatus, id_Usuario, solucion);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }
                else
                {
                    ResponseError<String> result = new ResponseError<String>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }
        public Response<string> ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                objFramework.ActualizaTickedAFinalizado(id_Ticket, idEstatus, id_Usuario, motivorechazo);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }
                else
                {
                    ResponseError<String> result = new ResponseError<String>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }
        public Response<Entidades.TicketsNoAsignados> ConsultaTicketsNoAsignados(int id_Usuario, int idGrupo)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTicketsNoAsignados> lista = objFramework.ConsultaTicketsNoAsignados(id_Usuario, idGrupo);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TicketsNoAsignados> result = new Response<Entidades.TicketsNoAsignados>();
                    result.List = objFramework.ConsultaTicketsNoAsignados(id_Usuario, idGrupo).Select
                        (x => new Entidades.TicketsNoAsignados
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.TicketsNoAsignados> result = new ResponseError<Entidades.TicketsNoAsignados>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TicketsNoAsignados> result = new ResponseError<Entidades.TicketsNoAsignados>(ex);
                return result;
            }
        }
        public Response<Entidades.ConsultaTickets> ConsultaTickets()
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTickets> lista = objFramework.ConsultaTickets();
                if (objFramework.Error == null)
                {
                    Response<Entidades.ConsultaTickets> result = new Response<Entidades.ConsultaTickets>();
                    result.List = objFramework.ConsultaTickets().Select
                        (x => new Entidades.ConsultaTickets
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.ConsultaTickets> result = new ResponseError<Entidades.ConsultaTickets>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.ConsultaTickets> result = new ResponseError<Entidades.ConsultaTickets>(ex);
                return result;
            }
        }
        public Response<Entidades.TicketsSupervisor> ConsultaTicketsSupervisor(int id_Usuario)
        {
            try
            {
                var objFramework = new Framework.Ticket();
                List<Framework.Libreria.ResultTicketsSupervisor> lista = objFramework.ConsultaTicketsSupervisor(id_Usuario);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TicketsSupervisor> result = new Response<Entidades.TicketsSupervisor>();
                    result.List = objFramework.ConsultaTicketsSupervisor(id_Usuario).Select
                        (x => new Entidades.TicketsSupervisor
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
                    return result;
                }
                else
                {
                    ResponseError<Entidades.TicketsSupervisor> result = new ResponseError<Entidades.TicketsSupervisor>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TicketsSupervisor> result = new ResponseError<Entidades.TicketsSupervisor>(ex);
                return result;
            }
        }
    }
}
