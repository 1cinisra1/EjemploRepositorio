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
    
    public partial class comp_ruta
    {
        public int idComp_Bitacora { get; set; }
        public Nullable<System.DateTime> Comp_Fecha { get; set; }
        public string Comp_NumeroVisitaMes { get; set; }
        public int Com_Usuarios_idCom_Usuarios { get; set; }
        public int Com_Usuarios_Roles_idRoles { get; set; }
        public int Cli_Empresa_idCli_Empresa { get; set; }
        public string Comp_TiempoDur { get; set; }
        public string Comp_Comentario { get; set; }
        public byte[] Com_estado { get; set; }
        public byte[] Comp_estado { get; set; }
        public string Comp_HoraLlegada { get; set; }
        public string Comp_HoraSalida { get; set; }
        public string Comp_CreadoPor { get; set; }
        public string Comp_CerradoPor { get; set; }
        public int Cli_Cliente_idCli_Cliente { get; set; }
        public int Cli_Usuario_idCli_Usuario { get; set; }
    
        public virtual cli_cliente cli_cliente { get; set; }
        public virtual com_usuarios com_usuarios { get; set; }
        public virtual cli_cliente cli_cliente1 { get; set; }
    }
}
