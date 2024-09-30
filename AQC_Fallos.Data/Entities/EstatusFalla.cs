using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Data.Entities
{
    public class EstatusFalla
    {
        public int id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
    }
}
