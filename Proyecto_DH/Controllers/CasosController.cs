using Microsoft.AspNetCore.Mvc;
using Proyecto_DH.Data;
using Proyecto_DH.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_DH.Service;
namespace Proyecto_DH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasosController : ControllerBase
    {
        private readonly ICasosService _casosService;

        public CasosController(ICasosService casosService)
        {
            _casosService = casosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var casos = await _casosService.GetAllAsync();
            return Ok(casos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var caso = await _casosService.GetByIdAsync(id);
            if (caso == null) return NotFound("Caso no encontrado.");

            return Ok(caso);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Caso nuevoCaso)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _casosService.CreateAsync(nuevoCaso);
            return CreatedAtAction(nameof(GetById), new { id = nuevoCaso.CasoID }, nuevoCaso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Caso casoActualizado)
        {
            if (id != casoActualizado.CasoID) return BadRequest("El ID no coincide.");
            var caso = await _casosService.GetByIdAsync(id);

            if (caso == null) return NotFound("Caso no encontrado.");

            await _casosService.UpdateAsync(casoActualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var caso = await _casosService.GetByIdAsync(id);
            if (caso == null) return NotFound("Caso no encontrado.");

            await _casosService.DeleteAsync(id);
            return NoContent();
        }
    }
}