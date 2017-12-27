using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entidades;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;

namespace WCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Grupo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Grupo.svc o Grupo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Grupo : IGrupo
    {
       public Response<string> AsignaGrupoUsuario(int id_Area, int id_Usuario)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                objFramework.AsignaGrupoUsuario(id_Area, id_Usuario);
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

        public Response<string> AsignaSupervisorGrupo(int id_Area, int id_Usuario, bool supervisa, int id_Asociar)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                objFramework.AsignaSupervisorGrupo(id_Area, id_Usuario, supervisa, id_Asociar);
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

        public Response<string> AsignaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                objFramework.AsignaTipoServicioGrupo(id_TipoServicio, id_Grupo);
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

        public Response<Entidades.TipoServicioGrupo> ConsultaTipoServicioGrupo(int id_Grupo)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                List<Framework.Libreria.ResultTipoServicioGrupo> lista = objFramework.ConsultaTipoServicioGrupo(id_Grupo);
                if (objFramework.Error == null)
                {
                    Response<Entidades.TipoServicioGrupo> result = new Response<Entidades.TipoServicioGrupo>();
                    result.List = objFramework.ConsultaTipoServicioGrupo(id_Grupo).Select
                        (x => new Entidades.TipoServicioGrupo
                        {
                            id_Servicio = x.id_Servicio,
                            Descripcion_servicio = x.Descripcion_servicio
                        }).ToList();

                    return result;
                }
                else
                {
                    ResponseError<Entidades.TipoServicioGrupo> result = new ResponseError<Entidades.TipoServicioGrupo>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.TipoServicioGrupo> result = new ResponseError<Entidades.TipoServicioGrupo>(ex);
                return result;
            }
        }

        public Response<string> EliminaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                objFramework.EliminaTipoServicioGrupo(id_TipoServicio, id_Grupo);
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

        public Response<Entidades.UsuariosGrupo> ConsultaUsuarioGrupo(int id_Grupo)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                List<Framework.Libreria.ResultUsuarioGrupo> lista = objFramework.ConsultaUsuarioGrupo(id_Grupo);
                if (objFramework.Error == null)
                {
                    Response<Entidades.UsuariosGrupo> result = new Response<Entidades.UsuariosGrupo>();
                    result.List = objFramework.ConsultaUsuarioGrupo(id_Grupo).Select
                        (x => new Entidades.UsuariosGrupo
                        {
                            id_AsociarGU = x.id_AsociarGU,
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

        public Response<string> EliminaUsuarioGrupo(int id_Area, int id_Usuario, int id_Asociar)
        {
            try
            {
                var objFramework = new Framework.Grupo();
                objFramework.EliminaUsuarioGrupo(id_Area, id_Usuario, id_Asociar);
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

        public Response<Entidades.CausaSolucion> ConsultaCausaSolucion()
        {
            try
            {
                var objFramework = new Framework.Grupo();
                List<Framework.Libreria.ResultCausaSolucion> lista = objFramework.ConsultaCausaSolucion();
                if (objFramework.Error == null)
                {
                    Response<Entidades.CausaSolucion> result = new Response<Entidades.CausaSolucion>();
                    result.List = objFramework.ConsultaCausaSolucion().Select
                        (x => new Entidades.CausaSolucion
                        {
                            id_CausaSolucion = x.id_CausaSolucion,
                            Descripcion_CausaSol = x.Descripcion_CausaSol,
                            
                        }).ToList();
                    return result;
                }
                else
                {
                    ResponseError<Entidades.CausaSolucion> result = new ResponseError<Entidades.CausaSolucion>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.CausaSolucion> result = new ResponseError<Entidades.CausaSolucion>(ex);
                return result;
            }
        }
    }
}
