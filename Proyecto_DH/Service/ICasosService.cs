using Proyecto_DH.Models;


namespace Proyecto_DH.Service
{
    public interface ICasosService
    {
        Task<IEnumerable<Caso>> GetAllAsync();
        Task<Caso?> GetByIdAsync(int id);
        Task CreateAsync(Caso caso);
        Task UpdateAsync(Caso caso);
        Task DeleteAsync(int id);
    }

}
