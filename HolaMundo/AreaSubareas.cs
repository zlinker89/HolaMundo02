//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HolaMundo
{
    using System;
    using System.Collections.Generic;
    
    public partial class AreaSubareas
    {
        public int IdAreaSubarea { get; set; }
        public int AreaCod { get; set; }
        public int SubareaId { get; set; }
    
        public virtual SubareaSet SubareaSet { get; set; }
        public virtual AreasD AreasD { get; set; }
    }
}
