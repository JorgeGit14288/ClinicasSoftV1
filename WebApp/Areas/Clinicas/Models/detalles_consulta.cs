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
    
    public partial class detalles_consulta
    {
        public int idDetalle { get; set; }
        public int idConsulta { get; set; }
        public int idPadecimiento { get; set; }
        public string descripcion { get; set; }
    
        public virtual consultas consultas { get; set; }
        public virtual padecimientos padecimientos { get; set; }
    }
}
