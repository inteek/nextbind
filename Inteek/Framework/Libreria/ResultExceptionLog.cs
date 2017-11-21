using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Libreria
{
    public class ResultExceptionLog
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string Tipo { get; set; }
        public System.DateTime Date { get; set; }
    }
}
