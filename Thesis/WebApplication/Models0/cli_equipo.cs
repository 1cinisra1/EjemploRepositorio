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
    
    public partial class cli_equipo
    {
        public int idCli_Equipo { get; set; }
        public string Cli_Marca { get; set; }
        public string Cli_Modelo { get; set; }
        public string Cli_DiscoDuro { get; set; }
        public string Cli_Ram { get; set; }
        public string Cli_Procesador { get; set; }
        public string Cli_TipoEquipo { get; set; }
        public int Cli_TipoEquipo_idCli_TipoEquipo { get; set; }
    
        public virtual cli_tipoequipo cli_tipoequipo1 { get; set; }
    }
}
