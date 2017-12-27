using Framework.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Framework
{
    public class Usuarios
    {

        #region VARIABLES
        Exception _Error;
        #endregion

        public List<ResultUsuarios> ValidaLogin(string usuario, string password)
        {
            List<ResultUsuarios> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                using (var db = new InteekServiceEntities())
                {
                    resultado = db.ValidaLogin(usuario, password).Select(x => new ResultUsuarios { id_Usuario = x.id_Usuario, id_Perfil = (int)x.id_Perfil, Nombre = x.Nombre, ApellidoPaterno = x.ApellidoPaterno, ApellidoMaterno = x.ApellidoMaterno, Correo = x.Correo, DomicilioDir = x.DomicilioDir, DomicilioCor = x.DomicilioCor }).ToList();
                }
                   
                if(objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                }
            }
            catch(Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public bool RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.RegistraDatosUsuario(id_Perfil, nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public bool ActualizaDatosUsuario(int id_Usuario, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor)
        {
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.ActualizaDatosUsuario(id_Usuario, nombre, apellidoPaterno, apellidoMaterno, correo, password, domicilioDir, domicilioCor);
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                return false;
            }
        }

        public List<ResultConsultaUsuarios> ConsultarUsuarios()
        {
            List<ResultConsultaUsuarios> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                resultado = objEntity.ConsultarUsuarios()
                    .Select(x => new ResultConsultaUsuarios
                    {
                      id_Usuario = x.id_Usuario,
                      Nombre = x.Nombre,
                      Correo = x.Correo,
                      Grupo = x.Grupo,
                      Supervisa = x.Supervisa,
                      Activo = x.Activo
                      }).ToList();
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public List<ResultAreasPorUsuario> ConsultaAreasPorUsuario(int id_Usuario)
        {
            List<ResultAreasPorUsuario> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                resultado = objEntity.ConsultaAreasPorUsuario(id_Usuario)
                    .Select(x => new ResultAreasPorUsuario
                    {
                        id_Grupo = x.id_Grupo,
                        Descripcion_grupo = x.Descripcion_grupo,
                    }).ToList();
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                }
            }
            catch (Exception ex)
            {
                _Error = ex;
            }
            return resultado;
        }

        public Exception Error
        {
            get { return _Error; }
        }

    }
}