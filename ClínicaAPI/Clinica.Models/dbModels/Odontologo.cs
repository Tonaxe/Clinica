namespace Clinica.Models.dbModels
{
    public class Odontologo
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public string? Especialidad { get; set; }
        public string? HorarioAtencion { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public virtual ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }
}
