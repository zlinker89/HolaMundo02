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
    
    public partial class GrupoSet
    {
        public GrupoSet()
        {
            this.GrupoAreas = new HashSet<GrupoAreas>();
            this.SubareaSet = new HashSet<SubareaSet>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<GrupoAreas> GrupoAreas { get; set; }
        public virtual ICollection<SubareaSet> SubareaSet { get; set; }
    }
}