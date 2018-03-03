using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Entity;

namespace Framework
{
    public class ExceptionLog
    {

        #region VARIABLES
        Exception _Error = null;
        #endregion


        public int IdError { get; set; }

        public string ErrorMessage { get; set; }

        public bool RegistraError(string message, string targetSite, string source, string stackTrace, string tipo)
        {
            try
            {
                Entity.ExceptionLog err = new Entity.ExceptionLog()
                {
                    Message = message,
                    Source = source,
                    TargetSite = targetSite,
                    StackTrace = stackTrace,
                    Tipo = tipo
                };
                using (var db = new InteekServiceEntities())
                {
                    db.ExceptionLog.Add(err);
                    db.SaveChanges();

                    IdError = err.Code;
                    ErrorMessage = err.Message;
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
