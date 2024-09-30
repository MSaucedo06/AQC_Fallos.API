using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Service.Models
{
    public class FallaModel
    {
        public int id { get; set; }
        public int Equipo_id { get; set; }
        public string? Equipo_descripcion { get; set; }
        public string? Falla_Descripcion { get; set; }
        public DateTime FechaFalla { get; set; }
        public int Prioridad_id { get; set; }
        public string? Prioridad_descripcion { get; set; }
        public int Estatus_id { get; set; }
        public string? Estatus_descripcion { get; set; }
    }
}
