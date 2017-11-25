using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using WCF.Contratos.Operaciones;

namespace WCF.Contratos.Datos
{
    [DataContract]
    //[KnownType(typeof(ResponseError<Entidades.TicketsPorCliente>))]
    public class Response<T>
    {
        public enum status
        {
            OK = 1,
            Failed = 2
        }

        [DataMember(Order = 1)]
        public status Status { get; set; }

        [DataMember(Order = 2)]
        public List<T> List { get; set; }

        [DataMember(Order = 3)]
        public string Comentarios { get; set; }



        #region CONSTRUCTORES
        public Response()
        {
            this.Status = status.OK;
            this.List = new List<T>();
        }
        public Response(List<T> items)
        {
            this.Status = status.OK;
            this.List = items;
        }
        #endregion


    }





}