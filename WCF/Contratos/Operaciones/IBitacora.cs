using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;
using WCF.Contratos.Datos;

namespace WCF.Contratos.Operaciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IBitacora" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(ServiceKnownTypesHelper))]
    public interface IBitacora<T>
    {
        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaBitacoraPorTicket/{id_Ticket}")]
        Response<T> ConsultaBitacoraPorTicket(int id_Ticket);
    }
}
