namespace Clinica.Models.dbModels
{
    public class Odontologo
    {
        public int id { get; set; }
        public int? usuario_id { get; set; }
        public string? especialidad { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public virtual ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }
}
