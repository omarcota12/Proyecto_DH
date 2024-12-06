using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DH.Models;
using Proyecto_DH.Service;

namespace Proyecto_DH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasService _personasService;

        public PersonasController(IPersonasService personasService)
        {
            _personasService = personasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _personasService.GetAllAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _personasService.GetByIdAsync(id);
            if (persona == null) return NotFound("Persona no encontrada.");

            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Persona nuevaPersona)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _personasService.CreateAsync(nuevaPersona);
            return CreatedAtAction(nameof(GetById), new { id = nuevaPersona.PersonaID }, nuevaPersona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Persona personaActualizada)
        {
            if (personaActualizada == null || id != personaActualizada.PersonaID)
            {
                return BadRequest("El ID de la persona no coincide.");
            }

            var existingPersona = await _personasService.GetByIdAsync(id);
            if (existingPersona == null)
            {
                return NotFound();
            }

            await _personasService.UpdateAsync(personaActualizada);
            return NoContent(); // Retorna un 204 si la actualización es exitosa
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _personasService.GetByIdAsync(id);
            if (persona == null) return NotFound("Persona no encontrada.");

            await _personasService.DeleteAsync(id);
            return NoContent();
        }
    }
}