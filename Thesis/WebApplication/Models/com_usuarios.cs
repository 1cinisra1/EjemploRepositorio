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
    
    public partial class com_usuarios
    {
        public int idCom_Usuarios { get; set; }
        public string Com_Nombre { get; set; }
        public int Roles_idRoles { get; set; }
        public string com_username { get; set; }
        public string com_clave { get; set; }
        public string confirm_com_clave { get; set; }
        public string com_correo { get; set; }
    
        public virtual roles roles { get; set; }
    }
}
