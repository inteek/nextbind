using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Framework
{
    public class ExceptionLog
    {

        #region VARIABLES
        Exception _Error;
        #endregion


        public int IdError { get; set; }

        public string ErrorMessage { get; set; }

        public bool RegistraError(string message, string targetSite, string source, string stackTrace, string tipo)
        {
            var objEntity = new Entity.Entity();
            try
            {
                objEntity.RegistraError(message, targetSite, source, stackTrace, tipo);
                if (objEntity.Error != null)
                {
                    _Error = objEntity.Error;
                    IdError = objEntity.IdError;
                    ErrorMessage = objEntity.ErrorMessage;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex;
                IdError = objEntity.IdError;
                ErrorMessage = objEntity.ErrorMessage;
                return false;
            }
        }
        public Exception Error
        {
            get { return _Error; }
        }


    }
}
