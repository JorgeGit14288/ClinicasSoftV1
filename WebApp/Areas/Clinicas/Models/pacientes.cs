//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Clinicas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pacientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pacientes()
        {
            this.consultas = new HashSet<consultas>();
        }
    
        public int idPaciente { get; set; }
        public string dpi { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string telefono_casa { get; set; }
        public string correo { get; set; }
        public Nullable<System.DateTime> nacimiento { get; set; }
        public Nullable<decimal> peso { get; set; }
        public Nullable<decimal> altura { get; set; }
        public string alergias { get; set; }
        public string observaciones { get; set; }
        public string encargado { get; set; }
        public string tel_encargado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consultas> consultas { get; set; }
    }
}