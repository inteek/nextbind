using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;

namespace WCF.Contratos.Operaciones
{
    public class ServiceKnownTypesHelper
    {
        public static IEnumerable<Type> GetKnownTypes( /*ICustomAttributeProvider*/ object provider)
        {

            List<Type> types = new List<Type>();
            Type[] GenericArguments = (((System.Type)(provider)).GetGenericArguments());

            Assembly encryptionAssembly = Assembly.Load("WCF");
            //if (GenericArguments != null && GenericArguments.Length > 0)
            //{

            foreach (Type type in GenericArguments)
            {
                string strFullName = type.FullName;
                Type typeGeneric, typeResponse;


                typeGeneric = typeof(Datos.Response<>);
                typeResponse = typeGeneric.MakeGenericType(encryptionAssembly.GetType(strFullName));
                types.Add(typeResponse);


                typeGeneric = typeof(Datos.ResponseError<>);
                typeResponse = typeGeneric.MakeGenericType(encryptionAssembly.GetType(strFullName));
                types.Add(typeResponse);
            }
           // }

            return types;
        }

    }
}