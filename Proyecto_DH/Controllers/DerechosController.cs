using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DH.Models;
using Proyecto_DH.Service;

namespace Proyecto_DH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DerechosController : ControllerBase
    {
        private readonly IDerechosService _derechosService;

        // Constructor que inyecta el servicio de Derechos
        public DerechosController(IDerechosService derechosService)
        {
            _derechosService = derechosService;
        }

        // Obtener todos los derechos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var derechos = await _derechosService.GetAllAsync();
            return Ok(derechos);
        }

        // Obtener un derecho por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var derecho = await _derechosService.GetByIdAsync(id);
            if (derecho == null)
            {
                return NotFound(); // Si no se encuentra el derecho, devuelve un 404
            }
            return Ok(derecho);
        }

        // Crear un nuevo derecho
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Derecho derecho)
        {
            if (derecho == null)
            {
                return BadRequest("El objeto derecho no puede ser nulo.");
            }

            await _derechosService.CreateAsync(derecho);
            return CreatedAtAction(nameof(GetById), new { id = derecho.DerechoID }, derecho);
        }

        // Actualizar un derecho existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Derecho derecho)
        {
            if (derecho == null || id != derecho.DerechoID) // Verificación de ID
            {
                return BadRequest("El ID del derecho no coincide.");
            }

            var existingDerecho = await _derechosService.GetByIdAsync(id);
            if (existingDerecho == null)
            {
                return NotFound(); // Si el derecho no existe, retorna un 404
            }

            await _derechosService.UpdateAsync(derecho);
            return NoContent(); // Retorna un 204 si la actualización es exitosa
        }

        // Eliminar un derecho
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _derechosService.DeleteAsync(id);
            return NoContent(); // Retorna un 204 si la eliminación es exitosa
        }
    }
}