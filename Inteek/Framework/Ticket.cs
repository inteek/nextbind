using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Ticket
    {
        #region VARIABLES
        Exception _Error;
        #endregion

        public bool RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta)
        {
            //idestatus por defecto deber ser nuevo "1"
            try
            {
                var objEntity = new Entity.Entity();
                objEntity.RegistraTicket(cliente, titulo, desc, tipo_Servicio, id_Area, idEstatus, ruta);
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

        public Exception Error
        {
            get { return _Error; }
        }
    }
}
