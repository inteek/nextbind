using Framework.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

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
                //var objEntity = new Entity.Entity();
                //objEntity.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, idEstatus, ruta);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, ruta, 1);
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
                //var objEntity = new Entity.Entity();
                //objEntity.AsignaTicket(id_Usuario, id_Ticket, idAgente, idEstatus);
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaTicket(id_Usuario, id_Ticket, idAgente, idEstatus);
                }

                    //if (objEntity.Error != null)
                    //{
                    //    _Error = objEntity.Error;
                    //    return false;
                    //}
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

        public List<ResultTicketsNoAsignados> ConsultaTicketsNoAsignados(int idusuario, int idGrupo)
        {
            List<ResultTicketsNoAsignados> resultado = null;
            try
            {

                using (var db = new Entity.InteekServiceEntities())
                {
                    resultado = (from x in db.ConsultaTicketsNoAsignados(idusuario, idGrupo)
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
                                     Fecha = (DateTime)x.Fecha,
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
                                     Fecha = (DateTime)x.Fecha,
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
                //var objEntity = new Entity.Entity();
                //objEntity.ActualizaTicketEnProceso(id_Ticket, idEstatus, id_Usuario);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketEnProceso(id_Ticket, idEstatus, id_Usuario);
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
                //var objEntity = new Entity.Entity();
                //objEntity.ActualizaTickedEnAprobacion(id_Ticket, idEstatus, id_Usuario, solucion);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketEnAprobacion(id_Ticket, idEstatus, id_Usuario, solucion);
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
                //var objEntity = new Entity.Entity();
                //objEntity.ActualizaTickedAFinalizado(id_Ticket, idEstatus, id_Usuario, motivorechazo);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.ActualizaTicketAFinalizado(id_Ticket, idEstatus, id_Usuario, motivorechazo);
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
                //var objEntity = new Entity.Entity();
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTickets().Select(
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
                }
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //}
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
                using (var db = new InteekServiceEntities())
                {

                    //var objEntity = new Entity.Entity();
                    resultado = db.ConsultaTicketsSupervisor(id_Usuario).Select(
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
                            Fecha = (DateTime)x.Fecha
                        }).ToList();
                }
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //}
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultTipoTicket> ConsultaTipoTickets(string descripcion,bool padre)
        {
            List<ResultTipoTicket> resultado = null;
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    if(padre)
                    {
                        resultado = db.tb_TipoServicio.Join(db.tb_TipoServicioGrupo.Join(db.tb_Grupo, tsg => tsg.id_Grupo, tg => tg.id_Grupo, (tsg, tg) => new { tsg, tg }), ts => ts.id_Servicio, aux => aux.tsg.id_TipoServicio, (ts, aux) => new { ts, aux }).
                                    Select(x => new ResultTipoTicket
                                    {
                                        idServicio = x.ts.id_Servicio,
                                        descripcionServicio = x.ts.Descripcion_servicio,
                                        claveServicio = x.ts.clave_servicio,
                                        idServicioSuperior = x.aux.tg.id_Grupo,
                                        servicioSuperior = x.aux.tg.Descripcion_grupo
                                    }).Where(x => x.servicioSuperior == descripcion).ToList();
                    }
                    else
                    {
                        var obj = db.tb_TipoServicio.Where(x => x.Descripcion_servicio == descripcion).FirstOrDefault();

                        resultado = db.tb_TipoServicio.Select(x => new ResultTipoTicket
                        {
                            idServicio = x.id_Servicio,
                            descripcionServicio = x.Descripcion_servicio,
                            claveServicio = x.clave_servicio,
                            idServicioSuperior = x.id_ServicioSuperior,
                            servicioSuperior = obj.Descripcion_servicio
                        }).Where(x => x.idServicioSuperior == obj.id_Servicio).ToList();

                    }

                    return resultado;
                }
            }
            catch(Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<int> ConsultaNoTicketMayor()
        {
            List<int> resultado = new List<int>();
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    int aux = db.tb_Ticket.Max(x => x.id_Ticket);
                    resultado.Add(aux);
                    return resultado;
                }
            }
            catch(Exception ex)
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
