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
    
    public partial class SedeSet
    {
        public SedeSet()
        {
            this.DepartamentoSedeSet = new HashSet<DepartamentoSedeSet>();
        }
    
        public int Cod { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<DepartamentoSedeSet> DepartamentoSedeSet { get; set; }
    }
}
