
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WebApplication.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
public partial class cli_tipoequipo
{

    public cli_tipoequipo()
    {

        this.cli_equipo = new HashSet<cli_equipo>();

    }


    public int idCli_TipoEquipo { get; set; }
    [Required]
    public string Cli_Descripcion { get; set; }



    public virtual ICollection<cli_equipo> cli_equipo { get; set; }

}

}
