using Framework.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Framework
{
    public class Bitacora
    {
        #region VARIABLES
        Exception _Error;
        #endregion

        public List<ResultBitacora> ConsultaBitacoraPorTicket(int id_Ticket)
        {
            List<ResultBitacora> resultado = null;
            try
            {
                var objEntity = new Entity.Entity();
                resultado = objEntity.ConsultaBitacoraPorTicket(id_Ticket)
                    .Select(x => new ResultBitacora
                    {
                        id_Bitacora = x.id_Bitacora,
                        Nombre = x.Nombre,
                        Fecha = (DateTime)x.Fecha,
                        Bitacora = x.Bitacora,
                        Estatus = x.Estatus,
                        id_Ticket = (int)x.id_Ticket}).ToList();
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
