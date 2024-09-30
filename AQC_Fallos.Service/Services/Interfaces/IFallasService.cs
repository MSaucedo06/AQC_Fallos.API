using AQC_Fallos.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Service.Services.Interfaces
{
    public interface IFallasService
    {
        Task<IEnumerable<FallaModel>> GetFallas();
        Task<IEnumerable<FallaModel>> GetFallaById(int id);
        Task<int> CreateFalla(FallaModel nuevaFalla);
    }
}
