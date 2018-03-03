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
    public class AsignarTicketController : Controller
    {
        // GET: AsignarTicket
        public ActionResult AsignarTicket()
        {
            return PartialView("AsignarTicket");
        }

        public JsonResult ObtenerTickets()
        {
            ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>> serviceFactory = new ServiceFactory<ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket>>();
            ITicket<TicketsPorCliente, TicketsPorAgente, TicketsSupervisor, TicketsPorArea, TipoTicket> service = serviceFactory.GetService("Ticket.svc");

            if (Session["UserInfo"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UserInfo"];
                var resultService = service.ConsultaTicketsSupervisor(usuario.id_Usuario);
                if (resultService.Status == WCF.Contratos.Datos.Response<TicketsSupervisor>.status.OK)
                    return Json(new { error = false, msg = "Funciono", list = resultService.List });
                else
                    return Json(new { error = true, msg = "Error inesperado" });

            }
            else
            {
                return Json(new { error = true, msg = "Error, sesion inactiva" });
            }
        }

    }
}