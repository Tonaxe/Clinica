namespace Clinica.Models.dbModels
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? TipoPago { get; set; }
        public int? ResponsableId { get; set; }
        public string? Imagen { get; set; }

        public virtual Responsable? Responsable { get; set; }
        public virtual ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }
}