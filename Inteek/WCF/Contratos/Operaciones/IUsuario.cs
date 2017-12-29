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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(ServiceKnownTypesHelper))]
    public interface IUsuario<T,M,K>
    {
        // TODO: agregue aquí sus operaciones de servicio

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/validaLogin/{usuario}/{password}")]
        Response<T> validaLogin(string usuario, string password);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/RegistraDatosUsuario/{id_Perfil}/{nombre}/{apellidoPaterno}/{apellidoMaterno}/{correo}/{password}/{domicilioDir}/{domicilioCor}")]
        Response<string> RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ActualizaDatosUsuario/{id_Usuario}/{nombre}/{apellidoPaterno}/{apellidoMaterno}/{correo}/{password}/{domicilioDir}/{domicilioCor}")]
        Response<string> ActualizaDatosUsuario(int id_Usuario, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/RegistraDispositivo/{plataforma}/{id_Usuario}/{identificador}")]
        Response<string> RegistraDispositivo(string plataforma, int idUsuario, string identificador);

        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarUsuarios")]
        Response<M> ConsultarUsuarios();

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarUsuariosPorGrupo/{id_Grupo}")]
        Response<M> ConsultarUsuariosPorGrupo(int idGrupo);

        //[OperationContract]
        [OperationContract, WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultaAreasPorUsuario")]
        Response<K> ConsultaGruposPorUsuario(int idUsuario);







    }
}
