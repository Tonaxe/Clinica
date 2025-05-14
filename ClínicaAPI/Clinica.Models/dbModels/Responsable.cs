namespace Clinica.Models.dbModels
{
    public class Responsable
    {
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;
        public string? parentesco { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}
