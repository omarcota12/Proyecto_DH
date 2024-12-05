
using Proyecto_DH.Models;

namespace Proyecto_DH.Service
{
    public interface IPersonasService
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task CreateAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}
