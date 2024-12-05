using Proyecto_DH.Models;

namespace Proyecto_DH.Service
{
    public interface IDerechosService
    {
        Task<IEnumerable<Derecho>> GetAllAsync();
        Task<Derecho?> GetByIdAsync(int id);
        Task CreateAsync(Derecho derecho);
        Task UpdateAsync(Derecho derecho);
        Task DeleteAsync(int id);
    }
}

