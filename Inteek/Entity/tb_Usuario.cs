
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
    
public partial class tb_Usuario
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tb_Usuario()
    {

        this.tb_Bitacora = new HashSet<tb_Bitacora>();

        this.tb_Dispositivo = new HashSet<tb_Dispositivo>();

        this.tb_Ticket = new HashSet<tb_Ticket>();

        this.tb_Ticket1 = new HashSet<tb_Ticket>();

    }


    public int id_Usuario { get; set; }

    public Nullable<int> id_Perfil { get; set; }

    public string Nombre { get; set; }

    public string ApellidoPaterno { get; set; }

    public string ApellidoMaterno { get; set; }

    public string Correo { get; set; }

    public string Password { get; set; }

    public string DomicilioDir { get; set; }

    public string DomicilioCor { get; set; }

    public Nullable<bool> Activo { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tb_Bitacora> tb_Bitacora { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tb_Dispositivo> tb_Dispositivo { get; set; }

    public virtual tb_Perfil tb_Perfil { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tb_Ticket> tb_Ticket { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tb_Ticket> tb_Ticket1 { get; set; }

}

}
