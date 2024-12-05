using Proyecto_DH.Data;
using Proyecto_DH.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_DH.Service
{
    public class CasosPersonasDerechosService : ICasosPersonasDerechosService
    {
        private readonly ApplicationDbContext _context;

        public CasosPersonasDerechosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CasosPersonasDerechos>> GetAllAsync()
        {
            return await _context.CasosPersonasDerechos
                .Include(cpd => cpd.Caso)
                .Include(cpd => cpd.Persona)
                .Include(cpd => cpd.Derecho)
                .ToListAsync();
        }

        public async Task<CasosPersonasDerechos?> GetByIdAsync(int id)
        {
            return await _context.CasosPersonasDerechos
                .Include(cpd => cpd.Caso)
                .Include(cpd => cpd.Persona)
                .Include(cpd => cpd.Derecho)
                .FirstOrDefaultAsync(cpd => cpd.ID == id);
        }

        public async Task CreateAsync(CasosPersonasDerechos relacion)
        {
            _context.CasosPersonasDerechos.Add(relacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var relacion = await GetByIdAsync(id);
            if (relacion != null)
            {
                _context.CasosPersonasDerechos.Remove(relacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}