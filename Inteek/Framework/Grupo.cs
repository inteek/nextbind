using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Framework
{
    public class Grupo
    {

        #region VARIABLES
        Exception _Error;
        #endregion

        public Exception Error
        {
            get { return _Error; }
        }

        public bool AsignaGrupoUsuario(int id_Area, int id_Usuario)
        {
            try
            {
                //var objEntity = new Entity.Entity();
                //objEntity.AsignaGrupoUsuario(id_Area, id_Usuario);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaGrupoUsuario(id_Usuario, id_Area);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool AsignaSupervisorGrupo(int id_Area, int id_Usuario, bool supervisa, int id_Asociar)
        {
            try
            {
                //var objEntity = new Entity.Entity();
                //objEntity.AsignaSupervisorGrupo(id_Area, id_Usuario, supervisa, id_Asociar);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaSupervisorGrupo(id_Area, id_Usuario, supervisa, id_Asociar);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool AsignaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                //var objEntity = new Entity.Entity();
                //objEntity.AsignaTipoServicioGrupo(id_TipoServicio, id_Grupo);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.AsignaTipoServicioGrupo(id_TipoServicio, id_Grupo);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<Libreria.ResultTipoServicioGrupo> ConsultaTipoServicioGrupo(int id_Grupo)
        {
            List<Libreria.ResultTipoServicioGrupo> resultado = null;
            try
            {
                //var objEntity = new Entity.Entity();
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaTipoServicioGrupo(id_Grupo)
                        .Select(x => new Libreria.ResultTipoServicioGrupo
                        {
                            id_Servicio = x.id_Servicio,
                            Descripcion_servicio = x.Descripcion_servicio
                        }).ToList();
                }
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //}
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public bool EliminaTipoServicioGrupo(int id_TipoServicio, int id_Grupo)
        {
            try
            {
                //var objEntity = new Entity.Entity();
                //objEntity.EliminaTipoServicioGrupo(id_TipoServicio, id_Grupo);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.EliminaTipoServicioGrupo(id_TipoServicio, id_Grupo);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<Libreria.ResultUsuarioGrupo> ConsultaUsuarioGrupo(int id_Grupo)
        {
            List<Libreria.ResultUsuarioGrupo> resultado = null;
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    //var objEntity = new Entity.Entity();
                    resultado = db.ConsultaUsuarioGrupo(id_Grupo)
                        .Select(x => new Libreria.ResultUsuarioGrupo
                        {
                            id_AsociarGU = x.id_AsociarGU,
                            id_Usuario = x.id_Usuario,
                            Nombre = x.Nombre,
                            Correo = x.Correo,
                            Grupo = x.Grupo,
                            Supervisa = x.Supervisa,
                            Activo = x.Activo
                        }).ToList();
                }
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //}
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public bool EliminaUsuarioGrupo(int id_Area, int id_Usuario, int id_Asociar)
        {
            try
            {
                //var objEntity = new Entity.Entity();
                //objEntity.EliminaUsuarioGrupo(id_Area, id_Usuario, id_Asociar);
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //    return false;
                //}
                using (var db = new InteekServiceEntities())
                {
                    db.EliminaUsuarioGrupo(id_Area, id_Usuario, id_Asociar);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<Libreria.ResultCausaSolucion> ConsultaCausaSolucion()
        {
            List<Libreria.ResultCausaSolucion> resultado = null;
            try
            {
               // var objEntity = new Entity.Entity();
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ConsultaCausaSolucion()
                        .Select(x => new Libreria.ResultCausaSolucion
                        {
                            id_CausaSolucion = x.id_CausaSolucion,
                            Descripcion_CausaSol = x.Descripcion_CausaSol
                        }).ToList();
                }
                //if (objEntity.Error != null)
                //{
                //    _Error = objEntity.Error;
                //}
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<Libreria.ResultGrupos> ObtenerGrupos(string padre, string id)
        {
            List<Libreria.ResultGrupos> resultado = null;
            try
            {
                using (var db = new InteekServiceEntities())
                {
                    if(padre=="")
                    {
                        resultado = db.tb_Grupo.Select(x => new Libreria.ResultGrupos
                        {
                            idGrupo = x.id_Grupo,
                            descripcionGrupo = x.Descripcion_grupo,
                            claveGrupo = x.Clave_Grupo,
                            idGrupoSuperior = x.id_GrupoSuperior
                        }).Where(x=>x.idGrupoSuperior==null).ToList();
                    }
                    else
                    {
                        var obj = db.tb_Grupo.Where(x => x.Descripcion_grupo == id).FirstOrDefault();

                        resultado = db.tb_Grupo.Select(x => new Libreria.ResultGrupos
                        {
                            idGrupo = x.id_Grupo,
                            descripcionGrupo = x.Descripcion_grupo,
                            claveGrupo = x.Clave_Grupo,
                            idGrupoSuperior = x.id_GrupoSuperior
                        }).Where(x => x.idGrupoSuperior == obj.id_Grupo).ToList();

                    }
                }
                return resultado;
            }
            catch(Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }
    }
}
