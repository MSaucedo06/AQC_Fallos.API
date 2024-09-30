using AQC_Fallos.Data.Entities;
using AQC_Fallos.Data.Repositories.Interfaces;
using AQC_Fallos.Service.Models;
using AQC_Fallos.Service.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Service.Services
{
    public class FallasService : IFallasService
    {
        private readonly IFallasRepository _fallasRepository;
        private readonly IMapper _mapper;
        public FallasService(IFallasRepository fallasRepository, IMapper mapper)
        {
            _fallasRepository = fallasRepository ?? throw new ArgumentNullException(nameof(fallasRepository)); ;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FallaModel>> GetFallas()
        {
            try
            {       
                var result = await _fallasRepository.GetFallas();
                
                var fallas = _mapper.Map<IEnumerable<FallaModel>>(result);

                return fallas;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FallaModel>> GetFallaById(int id)
        {
            try
            {
                var result = await _fallasRepository.GetFallaById(id);

                var falla = _mapper.Map<IEnumerable<FallaModel>>(result);

                return falla;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<int> CreateFalla(FallaModel nuevaFalla)
        {
            try
            {                
                var falla = _mapper.Map<Falla>(nuevaFalla);

                var result = await _fallasRepository.CreateFalla(falla);                

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
