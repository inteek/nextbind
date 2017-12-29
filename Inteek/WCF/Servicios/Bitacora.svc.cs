using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entidades;
using WCF.Contratos.Datos;
using WCF.Contratos.Operaciones;

namespace WCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Bitacora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Bitacora.svc o Bitacora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Bitacora : IBitacora<Entidades.Bitacoras>
    {
        public Response<Entidades.Bitacoras> ConsultaBitacoraPorTicket(int id_Ticket)
        {
            try
            {
                var objFramework = new Framework.Bitacora();
                List<Framework.Libreria.ResultBitacora> lista = objFramework.ConsultaBitacoraPorTicket(id_Ticket);
                if (objFramework.Error == null)
                {
                    Response<Entidades.Bitacoras> result = new Response<Entidades.Bitacoras>();
                    result.List = objFramework.ConsultaBitacoraPorTicket(id_Ticket).Select
                        (x => new Entidades.Bitacoras
                        {
                            id_Bitacora = x.id_Bitacora,
                            Nombre = x.Nombre,
                            Fecha = x.Fecha,
                            Bitacora = x.Bitacora,
                            Estatus = x.Estatus,
                            id_Ticket = x.id_Ticket,
                        }).ToList();
                    return result;
                }
                else
                {
                    ResponseError<Entidades.Bitacoras> result = new ResponseError<Entidades.Bitacoras>(objFramework.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ResponseError<Entidades.Bitacoras> result = new ResponseError<Entidades.Bitacoras>(ex);
                return result;
            }
        }
    }
}
