using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Entidades; 

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IWcf
    {
        
        public Response<Usuarios> validaLogin(string usuario, string password)
        {
            try
            {
                var objFramework = new Framework.Usuarios();

                List<Framework.Libreria.ResultValidaLogin> lista = objFramework.ValidaLogin(usuario, password);

                if (objFramework.Error == null)
                {
                    Response<Usuarios> result = new Response<Usuarios>();
                    result.List = objFramework.ValidaLogin(usuario, password).Select
                        (x => new Usuarios
                        {
                            id_Usuario = x.id_Usuario,
                            id_Perfil = x.id_Perfil,
                            Nombre = x.Nombre,
                            ApellidoPaterno = x.ApellidoPaterno,
                            ApellidoMaterno = x.ApellidoMaterno,
                            Correo = x.Correo,
                            DomicilioDir = x.DomicilioDir,
                            DomicilioCor = x.DomicilioCor,
                            supervisa = x.supervisa
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Usuarios> result = new ResponseError<Usuarios>(objFramework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                ResponseError<Usuarios> result = new ResponseError<Usuarios>(ex);
                return result;
            }
        }

        public Response<string> RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            
            try
            {
                var objFramework = new Framework.Usuarios();
                objFramework.RegistraDatosUsuario(id_Perfil, nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor, false);
                if (objFramework.Error == null)
                {
                    Response<String> result = new Response<String>();
                    return result;
                }else
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

        public Response<string> ActualizaDatosUsuario(int id_Usuario, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            try
            {
                Response<String> result = new Response<String>();
                return result;
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }

        public Response<string> RegistraDispositivo(string plataforma, int id_Usuario, string identificador)
        {
            string resultado = string.Empty;
            try
            {
                Response<String> result = new Response<String>();
                return result;
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }

        public Response<string> RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            //idestatus por defecto deber ser nuevo "1"
            try
            {
                Response<String> result = new Response<String>();
                return result;
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
                Response<String> result = new Response<String>();
                return result;
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }

        public List<Result_ConsultaTicketsPorArea> ConsultaTicketsPorArea(int id_Usuario, int id_Area)
        {
            List<Result_ConsultaTicketsPorArea> resultado = null;

            return resultado;
        }

        public List<Result_ConsultaDocumentosTicket> ConsultaDocumentosTicket (int id_Ticket)
        {
            List<Result_ConsultaDocumentosTicket> resultado = null;

            return resultado;
        }

        public List<Result_ConsultaBitacora> ConsultaBitacoraPorArea(int id_Usuario, int id_Area)
        {
            List<Result_ConsultaBitacora> resultado = null;

            return resultado;
        }

        public string RegistraBitacora(int idEstatus)
        {
            string resultado = string.Empty;
            try
            {
                resultado = string.Empty;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        public string RegistraDocumentoTicked(int id_Ticket, string ruta)
        {
            string resultado = string.Empty;
            try
            {
                resultado = string.Empty;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }


        public List<Usuarios> ConsultarUsuarios()
        {
            List<Usuarios> resultado = null;

            return resultado;
        }

        //PENDIENTE ConsultaDispositivosPorUsuario

        public List<Result_ConsultaTicket> ConsultaTicketsPorCliente(int cliente)
        {
            List<Result_ConsultaTicket> resultado = null;

            return resultado;
        }
        public List<Result_ConsultaTicket> ConsultaTicketsPorAgente(int id_Usuario)
        {
            List<Result_ConsultaTicket> resultado = null;

            return resultado;
        }

        public List<Result_ConsultaBitacora> ConsultaBitacoraPorTicked(int id_Ticket)
        {
            List<Result_ConsultaBitacora> resultado = null;

            return resultado;
        }

        public string ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario)
        {
            string resultado = string.Empty;
            try
            {
                resultado = string.Empty;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        public string ActualizaTickedEnAprobacion(int id_Ticket, int idEstatus, int id_Usuario, string solucion)
        {
            string resultado = string.Empty;
            try
            {
                resultado = string.Empty;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        public string ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo)
        {
            string resultado = string.Empty;
            try
            {
                resultado = string.Empty;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        public List<Result_ConsultaTicket> ConsultaTicketsNoAsignados(int idusuario)
        {
            List<Result_ConsultaTicket> resultado = null;

            return resultado;
        }
    }
}
