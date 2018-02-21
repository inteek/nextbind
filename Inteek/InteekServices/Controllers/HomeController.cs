using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteekServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Salir()
        {
            HttpCookie cookie = this.Request.Cookies["UserInfo"];
            if (Request.Cookies["UserInfo"] != null)
            {
                cookie["Activo"] = "0";
                this.Response.Cookies.Add(cookie);
                return Json(new { error = false, noError = 0, msg = "", page = Url.Action("LockScreen", "Login") });
            }
            else
            {
                return Json(new { error = false, noError = 0, msg = "", page = Url.Action("SignIn", "Login") });
            }
        }

        public JsonResult VerificarPerfil()
        {
            if(Session["UserInfo"]!=null)
            {
                WCF.Entidades.Usuario usuario = new WCF.Entidades.Usuario();
                usuario = (WCF.Entidades.Usuario)Session["UserInfo"];
                return Json(new { error = false, perfil = usuario.id_Perfil});
            }
            else
            {
                return Json(new { error = true, msg = "Error" });
            }
        }
    }
}