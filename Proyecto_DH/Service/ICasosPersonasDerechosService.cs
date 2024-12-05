using Proyecto_DH.Models;

namespace Proyecto_DH.Service
{
    public interface ICasosPersonasDerechosService
    {
        Task<IEnumerable<CasosPersonasDerechos>> GetAllAsync();
        Task<CasosPersonasDerechos?> GetByIdAsync(int id);
        Task CreateAsync(CasosPersonasDerechos relacion);
        Task DeleteAsync(int id);
    }
}
