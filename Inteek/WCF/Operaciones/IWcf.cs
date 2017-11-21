using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Entidades;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWcf
    {
        // TODO: agregue aquí sus operaciones de servicio

        [OperationContract]
        Response<Usuarios> validaLogin(string usuario, string password);

        [OperationContract]
        Response<string> RegistraDatosUsuario(int id_Perfil, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor);

        [OperationContract]
        Response<string> ActualizaDatosUsuario(int id_Usuario, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string password, string domicilioDir,
                    string domicilioCor);

        [OperationContract]
        Response<string> RegistraDispositivo(string plataforma, int id_Usuario, string identificador);

        [OperationContract]
        Response<string> RegistraTicket(int cliente, string titulo, string desc, int tipo_Servicio, int id_Area, int idEstatus, string ruta);

        [OperationContract]
        Response<string> AsignaTicket(int id_Usuario, int id_Ticket, int idAgente, int idEstatus);

        [OperationContract]
        List<Result_ConsultaTicketsPorArea> ConsultaTicketsPorArea(int id_Usuario, int id_Area);

        [OperationContract]
        List<Result_ConsultaDocumentosTicket> ConsultaDocumentosTicket(int id_Ticket);

        [OperationContract]
        List<Result_ConsultaBitacora> ConsultaBitacoraPorArea(int id_Usuario, int id_Area);

        [OperationContract]
        string RegistraBitacora(int idEstatus);

        [OperationContract]
        string RegistraDocumentoTicked(int id_Ticket, string ruta);

        [OperationContract]
        List<Usuarios> ConsultarUsuarios();

        [OperationContract]
        List<Result_ConsultaTicket> ConsultaTicketsPorCliente(int cliente);

        [OperationContract]
        List<Result_ConsultaTicket> ConsultaTicketsPorAgente(int id_Usuario);

        [OperationContract]
        List<Result_ConsultaBitacora> ConsultaBitacoraPorTicked(int id_Ticket);

        [OperationContract]
        string ActualizaTicketEnProceso(int id_Ticket, int idEstatus, int id_Usuario);

        [OperationContract]
        string ActualizaTickedAFinalizado(int id_Ticket, int idEstatus, int id_Usuario, string motivorechazo);

        [OperationContract]
        List<Result_ConsultaTicket> ConsultaTicketsNoAsignados(int idusuario);
    }
}
