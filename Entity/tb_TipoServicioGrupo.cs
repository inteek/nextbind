
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Entity
{

using System;
    using System.Collections.Generic;
    
public partial class tb_TipoServicioGrupo
{

    public int id_TSG { get; set; }

    public Nullable<int> id_TipoServicio { get; set; }

    public Nullable<int> id_Grupo { get; set; }



    public virtual tb_Grupo tb_Grupo { get; set; }

    public virtual tb_TipoServicio tb_TipoServicio { get; set; }

}

}
