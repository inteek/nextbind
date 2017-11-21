using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.Entidades
{
    [DataContract]
    public class ResponseError<T> : Response<T>
    {

        [DataMember(Order = 3)]
        public Error Error { get; set; }


        public ResponseError(Exception ex)
        {
            this.Status = status.Failed;
            this.Error = new Error(ex);
        }
    }
    [DataContract]
    public class Error
    {
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public string Cadena { get; set; }
        [DataMember]
        public string Metodo { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string TargetSite { get; set; }


        public Error(Exception ex)
        {
            var objFramework = new Framework.ExceptionLog();
            try
            {
                this.Mensaje = (ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                this.TargetSite = (ex.InnerException == null ? ex.TargetSite.Name : ex.InnerException.TargetSite.Name);
                this.Metodo = (ex.InnerException == null ? ex.Source : ex.InnerException.Source);
                this.Cadena = ex.StackTrace;
                this.Tipo = ex.GetType().ToString();

                objFramework.RegistraError(this.Mensaje, this.TargetSite, this.Metodo, this.Cadena, this.Tipo);
                //if (objFramework.Error != null)
                //{
                //    EnvioCorreo();
                //}
            }
            catch (Exception e)
            {
                EnvioCorreo();
            }
        }

        public static void EnvioCorreo()
        {

            string correo_electronico = ConfigurationManager.AppSettings["PathFiles"];
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

            mail.From = new MailAddress("agalindo@inteek.mx");
            //mail.To.Add("juan_amec@hotmail.com");
            mail.To.Add(correo_electronico);
            mail.Subject = string.Format("Error en la aplicación");
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
            body += "<div>Hola</div></br>";
            body += "<p>000. Ocurrio un error en la aplicación, favor de revisar.</p>";
            body += "</div>";
            body += "</div>";
            body += "</body>";
            body += "<html>";


            mail.Body = body;


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("agalindo@inteekdev.com", "DeveloperNet.2016");
            //SmtpServer.EnableSsl = true;


            SmtpServer.Send(mail);
        }


    }

    }

