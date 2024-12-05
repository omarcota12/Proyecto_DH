using Proyecto_DH.Data;
using Proyecto_DH.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_DH.Service
{
    public class PersonasService : IPersonasService
    {
        private readonly ApplicationDbContext _context;

        public PersonasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task CreateAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await GetByIdAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}