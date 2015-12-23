using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    class SubareaDTO
    {
        public int Id { get; set; }
        public Nullable<int> GrupoId { get; set; }
        public string nombre { get; set; }
    }
}
