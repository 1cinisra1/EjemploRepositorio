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
    
    public partial class cli_departamento
    {
        public cli_departamento()
        {
            this.cli_user = new HashSet<cli_user>();
        }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(100, ErrorMessage = "El campo debe contener minimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        public int idCli_Departamento { get; set; }
        public string Cli_Descripcion { get; set; }
    
        public virtual ICollection<cli_user> cli_user { get; set; }
    }
}
