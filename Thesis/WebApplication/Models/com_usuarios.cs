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
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class com_usuarios
    {
        public com_usuarios()
        {
            this.comp_ruta = new HashSet<comp_ruta>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public int idCom_Usuarios { get; set; }
        public string Com_Nombre { get; set; }
        public int Roles_idRoles { get; set; }
        public string Com_Apellido { get; set; }
        public string Com_Correo { get; set; }
        public string Com_Direccion { get; set; }
        public int Com_Cedula { get; set; }
        public string Com_Telefono { get; set; }
        public string Com_Clave { get; set; }


        public virtual roles roles { get; set; }
        public virtual ICollection<comp_ruta> comp_ruta { get; set; }
    }
}
