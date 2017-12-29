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
    public class LoginController : Controller
    {
        //
        // GET: /Pages/

        public ActionResult SignIn()
        {
            return PartialView("SignIn");
        }

        [HttpPost]
        public JsonResult Validate(string user, string password, bool remmemberPassword)
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> serviceFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> service = serviceFactory.GetService("Usuario.svc");
            var resultService = service.validaLogin(user, password);

            if (resultService.Status == WCF.Contratos.Datos.Response<Usuario>.status.OK)
            {
                if (resultService.List.Count > 0)
                {
                    return Json(new { error = false, noError = 0, msg = "Sesion iniciada", page = Url.Action("Index", "Home") });
                }
                else
                {
                    return Json(new { error = true, noError = 0, msg = "Usuario y/o contraseña no validos", page = "" });
                }
            }
            else 
            {
                var resultServiceEx = (ResponseError<Usuario>)resultService;
                return Json(new { error = true, noError = resultServiceEx.Error.Cadena, msg = resultServiceEx.Error.Mensaje, page = "" });
            }

        }

      

        public ActionResult SignUp()
        {
            return PartialView("SignUp");
        }

        public ActionResult ForgetPass()
        {
            return PartialView("ForgetPass");
        }

        public ActionResult LockScreen()
        {
            return PartialView("LockScreen");
        }

        public ActionResult PageNotFound()
        {
            return PartialView("PageNotFound");
        }



        public ActionResult Timeline()
        {
            return PartialView("Timeline");
        }

        public ActionResult Search()
        {
            return PartialView("Search");
        }

        public ActionResult Invoice()
        {
            return PartialView("Invoice");
        }

    }
}
