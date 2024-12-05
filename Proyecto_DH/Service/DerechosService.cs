using Microsoft.EntityFrameworkCore;
using Proyecto_DH.Data;
using Proyecto_DH.Models;

namespace Proyecto_DH.Service
{
    public class DerechosService : IDerechosService
    {
        private readonly ApplicationDbContext _context;

        public DerechosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Derecho>> GetAllAsync()
        {
            return await _context.Derechos.ToListAsync();
        }

        public async Task<Derecho?> GetByIdAsync(int id)
        {
            return await _context.Derechos.FindAsync(id);
        }

        public async Task CreateAsync(Derecho derecho)
        {
            _context.Derechos.Add(derecho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Derecho derecho)
        {
            _context.Derechos.Update(derecho);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var derecho = await GetByIdAsync(id);
            if (derecho != null)
            {
                _context.Derechos.Remove(derecho);
                await _context.SaveChangesAsync();
            }
        }
    }
}
