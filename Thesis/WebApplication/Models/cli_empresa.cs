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
    
    public partial class cli_empresa
    {
        public cli_empresa()
        {
            this.cli_usuario = new HashSet<cli_usuario>();
        }
    
        public int idCli_Empresa { get; set; }
        public string Cli_Nombre { get; set; }
        public string Cli_Ruc { get; set; }
        public string Cli_Direccion { get; set; }
        public string Cli_Tel { get; set; }
        public string Cli_Ciudad { get; set; }
    
        public virtual ICollection<cli_usuario> cli_usuario { get; set; }
    }
}
