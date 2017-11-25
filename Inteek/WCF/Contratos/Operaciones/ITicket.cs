using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Contratos.Datos;

namespace WCF.Contratos.Operaciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITicket" en el código y en el archivo de configuración a la vez.
    [ServiceContractAttribute( ConfigurationName = "WCF.Contratos.Operaciones.ITicket")]
    [ServiceKnownType("GetKnownTypes", typeof(ServiceKnownTypesHelper))]
    public interface ITicket<T,M,K,Y>
    {
        

        //[OperationContract]
        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/RegistraTicket/{cliente}/{titulo}/{desc}/{tipo_Servicio}/{id_Area}/{idEstatus}/{ruta}")]
        //Response<string> RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AsignaTicket/{id_Usuario}/{id_Ticket}/{idAgente}/{idEstatus}")]
        //Response<string> AsignaTicket(int id_Usuario, int id_Ticket, int idAgente, int idEstatus);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTicketsPorArea/{id_Usuario}/{id_Area}")]
        //Response<Entidades.TicketsPorArea> ConsultaTicketsPorArea(int id_Usuario, int id_Area);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTicketsPorCliente?cliente={cliente}")]
        Response<Entidades.TicketsPorCliente> ConsultaTicketsPorCliente(int cliente);//VALIDAR

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTicketsPorAgente/{id_Usuario}")]
        //Response<Entidades.TicketsPorAgente> ConsultaTicketsPorAgente(int id_Usuario);//VALIDAR

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ActualizaTicketEnProceso/{id_Ticket}/{idEstatus}/{id_Usuario}")]
        //Response<string> ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ActualizaTickedEnAprobacion/{id_Ticket}/{idEstatus}/{id_Usuario}/{solucion}")]
        //Response<string> ActualizaTickedEnAprobacion(int id_Ticket, int idEstatus, int id_Usuario, int solucion);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ActualizaTickedAFinalizado/{id_Ticket}/{idEstatus}/{id_Usuario}/{motivorechazo}")]
        //Response<string> ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTicketsNoAsignados/{id_Usuario}")]
        //Response<Entidades.TicketsNoAsignados> ConsultaTicketsNoAsignados(int id_Usuario);

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTickets")]
        //Response<Entidades.ConsultaTickets> ConsultaTickets();

        ////[OperationContract]
        //[OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTicketsSupervisor/{id_Usuario}")]
        //Response<Entidades.TicketsSupervisor> ConsultaTicketsSupervisor(int id_Usuario);
    }






    public static class ServiceKnownTypesHelper
    {

        public static IEnumerable<Type> GetKnownTypes( /*ICustomAttributeProvider*/ object provider)
        {

            List<Type> types = new List<Type>();
            Type[] GenericArguments = (((System.Type)(provider)).GetGenericArguments());

            Assembly encryptionAssembly = Assembly.Load("WCF");
            if (GenericArguments != null && GenericArguments.Length > 0)
            {
                string strFullName = GenericArguments[0].FullName;
                Type typeGeneric, typeResponse;

                typeGeneric = typeof(Datos.ResponseError<>);
                typeResponse = typeGeneric.MakeGenericType(encryptionAssembly.GetType(strFullName));
                types.Add(typeResponse);
            }

            return types;
        }
    }




}


