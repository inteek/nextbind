using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Contratos.Datos;

namespace WCF.Contratos.Operaciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGrupo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGrupo
    {
        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AsignaGrupoUsuario/{id_Ticket}/{id_Usuario}")]
        Response<string> AsignaGrupoUsuario(int id_Area, int id_Usuario);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AsignaSupervisorGrupo/{id_Area}/{id_Usuario}/{supervisa}/{id_Asociar}")]
        Response<string> AsignaSupervisorGrupo(int id_Area, int id_Usuario, bool supervisa, int id_Asociar);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AsignaTipoServicioGrupo/{id_TipoServicio}/{id_Grupo}")]
        Response<string> AsignaTipoServicioGrupo(int id_TipoServicio, int id_Grupo);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaTipoServicioGrupo/{id_Grupo}")]
        Response<Entidades.TipoServicioGrupo> ConsultaTipoServicioGrupo(int id_Grupo);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EliminaTipoServicioGrupo/{id_TipoServicio}/{id_Grupo}")]
        Response<string> EliminaTipoServicioGrupo(int id_TipoServicio, int id_Grupo);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaUsuarioGrupo/{id_Grupo}")]
        Response<Entidades.UsuariosGrupo> ConsultaUsuarioGrupo(int id_Grupo);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EliminaUsuarioGrupo/{id_Area}/{id_Usuario}/{id_Asociar}")]
        Response<string> EliminaUsuarioGrupo(int id_Area, int id_Usuario, int id_Asociar);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaCausaSolucion")]
        Response<Entidades.CausaSolucion> ConsultaCausaSolucion();
    }
}
