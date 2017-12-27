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

namespace WCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario<Entidades.Usuario, Entidades.UsuariosGrupo, Entidades.GruposPorUsuario>
    {
        
        public Response<Entidades.Usuario> validaLogin(string usuario, string password)
        {
            try
            {
                var objFramework = new Framework.Usuarios();

                List<Framework.Libreria.ResultUsuarios> lista = objFramework.ValidaLogin(usuario, password);

                if (objFramework.Error == null)
                {
                    Response<Entidades.Usuario> result = new Response<Entidades.Usuario>();
                    result.List = objFramework.ValidaLogin(usuario, password).Select
                        (x => new Entidades.Usuario
                        {
                            id_Usuario = x.id_Usuario,
                            id_Perfil = x.id_Perfil,
                            Nombre = x.Nombre,
                            ApellidoPaterno = x.ApellidoPaterno,
                            ApellidoMaterno = x.ApellidoMaterno,
                            Correo = x.Correo,
                            DomicilioDir = x.DomicilioDir,
                            DomicilioCor = x.DomicilioCor
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Entidades.Usuario> result = new ResponseError<Entidades.Usuario>(objFramework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                ResponseError<Entidades.Usuario> result = new ResponseError<Entidades.Usuario>(ex);
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

        public Response<Entidades.UsuariosGrupo> ConsultarUsuariosPorGrupo(int idGrupo)
        {
            try
            {
                var objFramework = new Framework.Usuarios();
                List<Framework.Libreria.ResultConsultaUsuarios> lista = objFramework.ConsultarUsuarios();
                if (objFramework.Error == null)
                {
                    Response<Entidades.UsuariosGrupo> result = new Response<Entidades.UsuariosGrupo>();
                    result.List = objFramework.ConsultarUsuarios().Select
                        (x => new Entidades.UsuariosGrupo
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
                    ResponseError<Entidades.UsuariosGrupo> result = new ResponseError<Entidades.UsuariosGrupo>(objFramework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                ResponseError<Entidades.UsuariosGrupo> result = new ResponseError<Entidades.UsuariosGrupo>(ex);
                return result;
            }
        }

        public Response<Entidades.GruposPorUsuario> ConsultaGruposPorUsuario(int id_Usuario)
        {
            try
            {
                var objFramework = new Framework.Usuarios();
                List<Framework.Libreria.ResultAreasPorUsuario> lista = objFramework.ConsultaAreasPorUsuario(id_Usuario);
                if (objFramework.Error == null)
                {
                    Response<Entidades.GruposPorUsuario> result = new Response<Entidades.GruposPorUsuario>();
                    result.List = objFramework.ConsultaAreasPorUsuario(id_Usuario).Select
                        (x => new Entidades.GruposPorUsuario
                        {
                            id_Grupo = x.id_Grupo,
                            Descripcion_grupo = x.Descripcion_grupo
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Entidades.GruposPorUsuario> result = new ResponseError<Entidades.GruposPorUsuario>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.GruposPorUsuario> result = new ResponseError<Entidades.GruposPorUsuario>(ex);
                return result;
            }
        }



        //PENDIENTE ConsultaDispositivosPorUsuario
    }
}
