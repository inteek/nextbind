using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;
using WCF.Entidades;
using System.Net.Mail;

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
                    RecordarContraseña(user, password, remmemberPassword,resultService.List[0].Nombre,resultService.List[0].DescripcionPefil);
                    Usuario usuario = new Usuario();
                    usuario.id_Usuario = resultService.List[0].id_Usuario;
                    usuario.id_Perfil = resultService.List[0].id_Perfil;
                    usuario.Correo = user;
                    usuario.Nombre = resultService.List[0].Nombre;
                    usuario.Password = password;
                    Session["UserInfo"] = usuario;
                    return Json(new { error = false, noError = 0, msg = "Sesion iniciada", page = Url.Action("Index", "Home")});
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

        [HttpPost]
        public JsonResult AgregarUsuario(string user, string userFirst, string userLast, string email, string password)
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> serviceFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> service = serviceFactory.GetService("Usuario.svc");

            var resultado = service.VerificarCorreo(email);
            if (resultado.Status == WCF.Contratos.Datos.Response<Usuario>.status.OK)
            {
                if (resultado.List.Count == 0)
                {
                    var resultService = service.RegistraDatosUsuario(1, user, userFirst, userLast, email, password, null, null);

                    if (resultService.Status == WCF.Contratos.Datos.Response<String>.status.OK)
                    {
                        EnvioCorreo(user, email);
                        return Json(new { error = false, noError = 0, msg = "Usuario Agregado", page = Url.Action("SignIn", "Login") });

                    }
                    else
                        return Json(new { error = true, noError = 0, msg = "Error Inesperado", page = " " });
                }
                else
                    return Json(new { error = false, noError = 1, msg = "El correo ya existe", page = " " });
            }
            else
            {
                return Json(new { error = true, noError = 0, msg = "Error inesperado", page = " " });
            }
        }

        public void EnvioCorreo(string user, string email)
        {
            var oRequest = System.Web.HttpContext.Current.Request;
            string liga =  oRequest.Url.GetLeftPart(System.UriPartial.Authority)+ System.Web.VirtualPathUtility.ToAbsolute("~/Login/ActivarCuenta"); 

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

            mail.From = new MailAddress("aalmanza@inteek.com.mx");
            //mail.To.Add("juan_amec@hotmail.com");
            mail.To.Add(email);
            mail.Subject = string.Format("Por favor confirma tu cuenta");
            mail.IsBodyHtml = true;
            string body = "<!DOCTYPE html>";
            body += "<html lang='es'>";
            body += "<head>";
            body += "<meta name='viewport' content='width=device-width'>";
            body += "<style>";
            body += "@media only screen and (max-width:319px)  { body{font-size:8px}}";
            body += "@media only screen and (min-width:320px) and (max-width:767px)  { body{font-size:10px} }";
            body += "@media only screen and (min-width:768px) and (max-width:1023px)  { body{font-size:12px} }";
            body += "@media only screen and (min-width:1024px) and (max-width:1899px) { body{font-size:14px} }";
            body += "@media only screen and (min-width:1900px) { body{font-size:16px} }";
            body += "</style>";
            body += "</head>";
            body += "<body>";
            body += "<div style='width:100%;' style='margin-left: 30px; margin-top: 20px;'>";
            body += "<div style='height:180px; width:621px;'>";
            //body += "<div>Hola,<strong> " + user + "</strong></div></br>";
            body += "<div style='padding: 0;font-family:Arial,sans-serif;font-size: 20px;color: #707070;'> Hola, "+user+"</div>";
            body += "<div style='padding-top:10px;font-family:Arial,sans-serif;font-size: 25px;color: #2672ec;'>Hemos creado tu cuenta, solo falta que la actives.</div></br>";
            body += "<a href='"+liga+"?user="+user+"&email="+email+"'><button style='border:none; margin:0px;font-family:Circular,&quot;Helvetica Neue&quot;,Helvetica,Arial,sans-serif; text-decoration:none; color:rgb(255,255,255); font-size:15px; font-weight:bold; height:50%;width:30%; line-height:20px; text-align:center;vertical-align:text-top;background-color:#2672ec;'>ACTIVAR CUENTA</button></a>";
            body += "</div>";
            body += "</div>";
            body += "</body>";
            body += "<html>";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("aalmanza@inteek.com.mx", "Inteek2017");
            //SmtpServer.EnableSsl = true;

            mail.Body = body;
            SmtpServer.Send(mail);
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

        public bool CambiarEstatus(string email)
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> serviceFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> servicio = serviceFactory.GetService("Usuario.svc");

            var resultado = servicio.CambiarEstatus(email);
            if(resultado.Status == WCF.Contratos.Datos.Response<String>.status.OK)
            {
                // return Json(new { error = false, noError = 0, msg = "Cuenta Activada", page = "" });
                return true;
            }
            else
            {
                //return Json(new { error = true, noError = 0, msg = "Error Insperado", page = "" });
                return false;
            }
            
        }

        public ActionResult ActivarCuenta(string user, string email)
        {
            CambiarEstatus(email);
            return PartialView("ActivarCuenta");
        }

        public void RecordarContraseña(string user, string password, bool rememberPassword, string name, string perfil)
        {
            if (rememberPassword == true)
            {
                //ENCRIPTAR PASSWORD
                //string encriptar = Encriptar.Encriptar.Encriptar(login.password, "01234");

                //CREAR COOKIE
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["User"] = user;
                //cookie["Pass"] = password;
                cookie["Name"] = name;
                cookie["Pass"] = password;
                cookie["Perfil"] = perfil;
                cookie["Activo"] = "1";
                cookie.Shareable = true;
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }
            else if (rememberPassword == false && Request.Cookies["UserInfo"] != null)
            {
                //Eliminar cookie
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }

        }

        public JsonResult AutenticacionAutomatica()
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> serviceFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> service = serviceFactory.GetService("Usuario.svc");

            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (cookie != null)
            {
                if (cookie["Activo"] == "1")
                {
                    string user = cookie["User"];
                    string password = cookie["Pass"];
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
                else
                {
                    return Json(new { error = false, noError = 0, msg = " ", page = Url.Action("LockScreen", "Login") });
                }
            }
            return null;
        }

        public ActionResult ReestablecerPassword()
        {
            return PartialView("ReestablecerPassword");
        }

        public JsonResult SolReestablecerPassword(string email)
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> servicieFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> servicio = servicieFactory.GetService("Usuario.svc");

            var result = servicio.VerificarCorreo(email);
            if(result.Status == WCF.Contratos.Datos.Response<Usuario>.status.OK)
            {
                if(result.List.Count > 0)
                {
                    EnvioCorreoContraseña(result.List[0].Nombre, email);
                    return Json(new { error = false, noError = 0, msg = "Correo enviado correctamente", page = Url.Action("SignIn","Login")});
                }
                else
                {
                    return Json(new { error = true, noError = 0, msg = "Usuario inexistente", page = " " });
                }
            }
            else
            {
                return Json(new { error = true, noError = 0, msg = "Error inesperado", page = " " });
            }

            
        }

        public void EnvioCorreoContraseña(string user, string email)
        {
            var oRequest = System.Web.HttpContext.Current.Request;
            string liga = oRequest.Url.GetLeftPart(System.UriPartial.Authority) + System.Web.VirtualPathUtility.ToAbsolute("~/Login/ReestablecerPassword");

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

            mail.From = new MailAddress("aalmanza@inteek.com.mx");
            mail.To.Add(email);
            mail.Subject = string.Format("Reestablece tu contraseña");
            mail.IsBodyHtml = true;
            string body = "<!DOCTYPE html>";
            body += "<html lang='es'>";
            body += "<head>";
            body += "<meta name='viewport' content='width=device-width'>";
            body += "<style>";
            body += "@media only screen and (max-width:319px)  { body{font-size:8px}}";
            body += "@media only screen and (min-width:320px) and (max-width:767px)  { body{font-size:10px} }";
            body += "@media only screen and (min-width:768px) and (max-width:1023px)  { body{font-size:12px} }";
            body += "@media only screen and (min-width:1024px) and (max-width:1899px) { body{font-size:14px} }";
            body += "@media only screen and (min-width:1900px) { body{font-size:16px} }";
            body += "</style>";
            body += "</head>";
            body += "<body>";
            body += "<div style='width:100%;' style='margin-left: 30px; margin-top: 20px;'>";
            body += "<div style='height:180px; width:621px;'>";
            //body += "<div>Hola,<strong> " + user + "</strong></div></br>";
            body += "<div style='padding: 0;font-family:Arial,sans-serif;font-size: 15px;color: #707070;'> Hola, " + user + "</div>";
            body += "<div style='padding-top:10px;font-family:Arial,sans-serif;font-size: 18px;color: #2672ec;'>Escuchamos que quieres reestablecer tu contraseña, para hacerlo da click al siguiente boton el cual te redireccionara a otro sitio para que puedas realizar el cambio de tu contraseña.</div></br>";
            body += "<a href='" + liga + "?user=" + user + "&email=" + email + "'><button style='border:none; margin:0px;font-family:Circular,&quot;Helvetica Neue&quot;,Helvetica,Arial,sans-serif; text-decoration:none; color:rgb(255,255,255); font-size:15px; font-weight:bold; height:50%;width:30%; line-height:20px; text-align:center;vertical-align:text-top;background-color:#2672ec;'>REESTABLECER CONTRASEÑA</button></a>";
            body += "</div>";
            body += "</div>";
            body += "</body>";
            body += "<html>";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("aalmanza@inteek.com.mx", "Inteek2017");
            //SmtpServer.EnableSsl = true;

            mail.Body = body;
            SmtpServer.Send(mail);
        }

        public JsonResult CambioPassword(string user, string password)
        {
            ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>> servicieFactory = new ServiceFactory<IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario>>();
            IUsuario<Usuario, UsuariosGrupo, GruposPorUsuario> servicio = servicieFactory.GetService("Usuario.svc");

            var result = servicio.CambiarContraseña(user, password);
            if(result.Status == WCF.Contratos.Datos.Response<String>.status.OK)
            {
                return Json(new { error = false, noError = 0, msg = "Contraseña reestablecida correctamente", page = " " });
            }
            else
            {
                return Json(new { error = true, noError = 0, msg = "Error inesperado", page = " " });
            }
        }
    }
}