using Microsoft.EntityFrameworkCore;
using Proyecto_DH.Data;
using Proyecto_DH.Models;

namespace Proyecto_DH.Service
{
    public class CasosService : ICasosService
    {
        private readonly ApplicationDbContext _context;

        public CasosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Caso>> GetAllAsync()
        {
            return await _context.Casos
                .Include(c => c.Administrador)
                .ToListAsync();
        }

        public async Task<Caso?> GetByIdAsync(int id)
        {
            return await _context.Casos
                .Include(c => c.Administrador)
                .FirstOrDefaultAsync(c => c.CasoID == id);
        }

        public async Task CreateAsync(Caso caso)
        {
            _context.Casos.Add(caso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Caso caso)
        {
            var existingCaso = await _context.Casos.FindAsync(caso.CasoID);
            if (existingCaso != null)
            {
                // Actualizar solo las propiedades necesarias
                existingCaso.Titulo = caso.Titulo;
                existingCaso.Descripcion = caso.Descripcion;
                existingCaso.FechaInicio = caso.FechaInicio;
                existingCaso.Estado = caso.Estado;

                // Guardar cambios sin agregar una nueva instancia
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var caso = await GetByIdAsync(id);
            if (caso != null)
            {
                _context.Casos.Remove(caso);
                await _context.SaveChangesAsync();
            }
        }
    }
}