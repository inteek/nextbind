using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Entidades;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario
    {
        
        public Response<Entidades.Usuarios> validaLogin(string usuario, string password)
        {
            try
            {
                var objFramework = new Framework.Usuarios();

                List<Framework.Libreria.ResultUsuarios> lista = objFramework.ValidaLogin(usuario, password);

                if (objFramework.Error == null)
                {
                    Response<Entidades.Usuarios> result = new Response<Entidades.Usuarios>();
                    result.List = objFramework.ValidaLogin(usuario, password).Select
                        (x => new Entidades.Usuarios
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
                    ResponseError<Entidades.Usuarios> result = new ResponseError<Entidades.Usuarios>(objFramework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                ResponseError<Entidades.Usuarios> result = new ResponseError<Entidades.Usuarios>(ex);
                return result;
            }
        }

        public Response<string> RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            
            try
            {
                var objFramework = new Framework.Usuarios();
                objFramework.RegistraDatosUsuario(id_Perfil, nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor);
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
                var objFramework = new Framework.Usuarios();
                objFramework.ActualizaDatosUsuario(id_Usuario, nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor);
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

        //PENDIENTE
        public Response<string> RegistraDispositivo(string plataforma, int id_Usuario, string identificador)
        {
            string resultado = string.Empty;
            try
            {
                var objFramework = new Framework.Usuarios();
                Response<String> result = new Response<String>();
                return result;
            }
            catch (Exception ex)
            {
                ResponseError<String> result = new ResponseError<String>(ex);
                return result;
            }
        }

        public Response<Entidades.ConsultaUsuarios> ConsultarUsuarios()
        {
            try
            {
                var objFramework = new Framework.Usuarios();
                List<Framework.Libreria.ResultConsultaUsuarios> lista = objFramework.ConsultarUsuarios();
                if (objFramework.Error == null)
                {
                    Response<Entidades.ConsultaUsuarios> result = new Response<Entidades.ConsultaUsuarios>();
                    result.List = objFramework.ConsultarUsuarios().Select
                        (x => new Entidades.ConsultaUsuarios
                        {
                            id_Usuario = x.id_Usuario,
                            Nombre = x.Nombre,
                            Correo = x.Correo,
                            Grupo = x.Grupo,
                            Supervisa = x.Supervisa,
                            Activo = x.Activo
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Entidades.ConsultaUsuarios> result = new ResponseError<Entidades.ConsultaUsuarios>(objFramework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                ResponseError<Entidades.ConsultaUsuarios> result = new ResponseError<Entidades.ConsultaUsuarios>(ex);
                return result;
            }
        }

        public Response<Entidades.AreasPorUsuario> ConsultaAreasPorUsuario(int id_Usuario)
        {
            try
            {
                var objFramework = new Framework.Usuarios();
                List<Framework.Libreria.ResultAreasPorUsuario> lista = objFramework.ConsultaAreasPorUsuario(id_Usuario);
                if (objFramework.Error == null)
                {
                    Response<Entidades.AreasPorUsuario> result = new Response<Entidades.AreasPorUsuario>();
                    result.List = objFramework.ConsultaAreasPorUsuario(id_Usuario).Select
                        (x => new Entidades.AreasPorUsuario
                        {
                            id_Grupo = x.id_Grupo,
                            Descripcion_grupo = x.Descripcion_grupo
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Entidades.AreasPorUsuario> result = new ResponseError<Entidades.AreasPorUsuario>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.AreasPorUsuario> result = new ResponseError<Entidades.AreasPorUsuario>(ex);
                return result;
            }
        }


        //PENDIENTE ConsultaDispositivosPorUsuario
    }
}
