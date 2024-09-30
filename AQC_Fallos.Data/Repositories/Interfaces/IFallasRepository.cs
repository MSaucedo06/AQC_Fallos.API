using AQC_Fallos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Data.Repositories.Interfaces
{
    public interface IFallasRepository
    {
        Task<IEnumerable<Falla>> GetFallas();
        Task<IEnumerable<Falla>> GetFallaById(int id);
        Task<int> CreateFalla(Falla nuevaFalla);
    }
}
