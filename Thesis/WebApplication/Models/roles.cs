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
    
    public partial class roles
    {
        public roles()
        {
            this.com_usuarios = new HashSet<com_usuarios>();
        }
    
        public int idRoles { get; set; }
        public string Rol_Admin { get; set; }
        public string Rol_Operador { get; set; }
    
        public virtual ICollection<com_usuarios> com_usuarios { get; set; }
    }
}
