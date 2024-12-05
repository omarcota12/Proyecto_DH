namespace Proyecto_DH.Models
{
    public class CasosPersonasDerechos
    {
        public int ID { get; set; }
        public int CasoID { get; set; }
        public Caso Caso { get; set; } = null!;
        public int PersonaID { get; set; }
        public Persona Persona { get; set; } = null!;
        public int DerechoID { get; set; }
        public Derecho Derecho { get; set; } = null!;
    }
}
