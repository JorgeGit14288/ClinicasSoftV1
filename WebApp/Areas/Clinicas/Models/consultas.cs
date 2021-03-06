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
    
    public partial class consultas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public consultas()
        {
            this.detalles_consulta = new HashSet<detalles_consulta>();
            this.recetas = new HashSet<recetas>();
        }
    
        public int idConsultas { get; set; }
        public int idMedico { get; set; }
        public int idPaciente { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora_inicio { get; set; }
        public Nullable<System.TimeSpan> hora_fin { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalles_consulta> detalles_consulta { get; set; }
        public virtual medicos medicos { get; set; }
        public virtual pacientes pacientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recetas> recetas { get; set; }
    }
}
