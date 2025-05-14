namespace Clinica.Models.dbModels
{
    public class Responsable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Parentesco { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}
