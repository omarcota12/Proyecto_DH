namespace Proyecto_DH.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // 'Administrador' o 'Usuario'
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
