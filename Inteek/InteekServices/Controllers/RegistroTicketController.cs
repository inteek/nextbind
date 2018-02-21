using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;
using WCF.Entidades;

namespace InteekServices.Controllers
{
    public class RegistroTicketController : Controller
    {
        // GET: RegistroTicket
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ContenedorRegistro()
        {
            return PartialView("ContenedorRegistro");
        }

        public JsonResult ObtenerTipoTicket(string id, string padre)
        {
            ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>> serviceFactory = new ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>>();
            ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket> service = serviceFactory.GetService("Ticket.svc");

            var result = service.ConsultaTipoTickets(id,padre);
            if(result.Status == WCF.Contratos.Datos.Response<TipoTicket>.status.OK)
            {
                if (result.List.Count > 0)
                    return Json(new { error=false, icon = (padre=="#")? "ion-android-add-circle": "ion-android-arrow-dropright-circle", list = result.List});
                return null;
            }
            else
            {
                return Json(new { error = true, msg = "Error Inesperado" });
            }
        }

        public JsonResult ObtenerGrupos(string padre, string id)
        {
            ServiceFactory<IGrupo<TipoServicioGrupo, UsuariosGrupo, CausaSolucion, Grupos>> serviceFactory = new ServiceFactory<IGrupo<TipoServicioGrupo, UsuariosGrupo, CausaSolucion, Grupos>>();
            IGrupo<TipoServicioGrupo, UsuariosGrupo, CausaSolucion, Grupos> servicio = serviceFactory.GetService("Grupo.svc");

            var result = servicio.ObtenerGrupos(padre, id);
            if(result.Status == WCF.Contratos.Datos.Response<Grupos>.status.OK)
            {
                if(result.List.Count>0)
                    return Json(new { error = false,icon = (padre=="#")? "ion-android-arrow-dropright-circle" : "ion-android-add-circle", list = result.List });
                return null;
            }
            else
            {
                return Json(new { error = true, msg = "Error Inesperado" });
            }
        }

        public JsonResult ConsultaNoTicketMayor()
        {
            ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>> serviceFactory = new ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>>();
            ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket> service = serviceFactory.GetService("Ticket.svc");

            var result = service.ConsultaNoTicketMayor();
            if(result.Status == WCF.Contratos.Datos.Response<int>.status.OK)
            {
                return Json(new { error = false, id = result.List[0] + 1 });
            }
            else
            {
                return Json(new { error = true, msg = "Error inesperado" });
            }
        }

        public JsonResult RegistrarTicket(string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>> serviceFactory = new ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>>();
            ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket> service = serviceFactory.GetService("Ticket.svc");
            Usuario usuario = new Usuario();
            int _cliente;

            if (Session["UserInfo"] != null)
            {
                usuario = (Usuario)Session["UserInfo"];
                _cliente = usuario.id_Usuario;
            }
            else
                _cliente = 0;
                
            var result = service.RegistraTicket(_cliente, titulo, desc, tipo_Servicio, id_Area, 1, ruta);
            if(result.Status == WCF.Contratos.Datos.Response<string>.status.OK)
            {
                return Json(new { error = false, msg = "Se ha agregado el ticket con exito" });
            }
            else
            {
                return Json(new { error = true, msg = "Error inesperado" });
            }
        }

    }
}