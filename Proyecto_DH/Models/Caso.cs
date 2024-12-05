namespace Proyecto_DH.Models
{
    public class Caso
    {
        public int CasoID { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
        public string Estado { get; set; } = "Abierto"; // 'Abierto', 'En Proceso', 'Cerrado'
        public int AdministradorID { get; set; }
        public Administrador Administrador { get; set; } = null!;
    }
}
