
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
    
public partial class tb_TicketSolucion
{

    public int id_TCS { get; set; }

    public Nullable<int> id_Ticket { get; set; }

    public Nullable<int> id_Solucion { get; set; }



    public virtual tb_Solucion tb_Solucion { get; set; }

    public virtual tb_Ticket tb_Ticket { get; set; }

}

}