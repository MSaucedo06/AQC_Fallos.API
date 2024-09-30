using AQC_Fallos.Data.Entities;
using AQC_Fallos.Service.Models;
using AQC_Fallos.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AQC_Fallos.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FallasController : ControllerBase
    {
        private readonly ILogger<FallasController> _logger;
        private readonly IFallasService _fallasService;

        public FallasController(ILogger<FallasController> logger, IFallasService fallasService)
        {
            _logger = logger;
            _fallasService = fallasService;
        }

        [HttpGet(Name = "Fallas")]
        public async Task<IActionResult> GetFallas()
        {
            try
            {
                var fallas = await _fallasService.GetFallas();

                return Ok(fallas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
            
        }

        [HttpGet("{id}", Name = "FallaById")]
        public async Task<IActionResult> GetFallaById(int id)
        {
            try
            {
                var falla = await _fallasService.GetFallaById(id);

                if (falla == null)
                {
                    return NotFound();
                }

                return Ok(falla);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> CreateFalla(FallaModel nuevaFalla)
        {
            try
            {
                var falla = await _fallasService.CreateFalla(nuevaFalla);

                if(falla > 0)
                {
                    return Ok();
                }

                return BadRequest();
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }

        }

    }
    
}
