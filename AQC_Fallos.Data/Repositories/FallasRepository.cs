using AQC_Fallos.Data.Context;
using AQC_Fallos.Data.Entities;
using AQC_Fallos.Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Data.Repositories
{
    public class FallasRepository : IFallasRepository
    {
        protected readonly DBContext _context;
        private readonly ILogger<FallasRepository> _logger;

        public FallasRepository(ILogger<FallasRepository> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Falla>> GetFallas()
        {
            try
            {
                var fallas = await _context.Fallas
                        .FromSqlRaw("EXEC sp_GetFallas")
                        .ToListAsync();

                return fallas;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.InnerException, e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Falla>> GetFallaById(int id)
        {
            try
            {
                var falla = await _context.Fallas
                        .FromSqlRaw("EXEC sp_GetFallaById @idFalla = @id", new SqlParameter("@id", id))
                        .ToListAsync();

                return falla;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.InnerException, e.StackTrace);
                throw new Exception(e.Message);
            }
        }


        public async Task<int> CreateFalla(Falla nuevaFalla)
        {
            try
            {
                
                var idParameter = new SqlParameter("@idFalla", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsFalla @equipo_id = @equ_id, @descripcion = @desc, @prioridad_id = @prio_id, @idFalla = @idNew",
                    new SqlParameter("@equ_id", nuevaFalla.Equipo_id),
                    new SqlParameter("@desc", nuevaFalla.Falla_Descripcion),
                    new SqlParameter("@prio_id", nuevaFalla.Prioridad_id),
                    new SqlParameter() { ParameterName = "@idNew", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output })
                    ;

                
                var falla = (int)result;

                return falla; 
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.InnerException, e.StackTrace);
                throw new Exception("Error al insertar la falla", e);
            }
        }

    }
}
