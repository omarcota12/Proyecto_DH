using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_DH.Models
{
    public class Administrador
    {
        [Key] // Esta anotación define la clave primaria
        public int AdministradorID { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }
        public required Usuario Usuario { get; set; }
    }
}
