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
    
    public partial class cli_cliente
    {
        public cli_cliente()
        {
            this.cli_usuario = new HashSet<cli_usuario>();
            this.comp_ruta = new HashSet<comp_ruta>();
            this.comp_ruta1 = new HashSet<comp_ruta>();
        }
    
        public int idCli_Cliente { get; set; }
        public string Cli_Nombre { get; set; }
        public string Cli_Ruc { get; set; }
        public string Cli_Direccion { get; set; }
        public string Cli_Tel { get; set; }
        public string Cli_Ciudad { get; set; }
        public string Cli_RSocial { get; set; }
        public string Cli_NombContacto { get; set; }
    
        public virtual ICollection<cli_usuario> cli_usuario { get; set; }
        public virtual ICollection<comp_ruta> comp_ruta { get; set; }
        public virtual ICollection<comp_ruta> comp_ruta1 { get; set; }
    }
}
