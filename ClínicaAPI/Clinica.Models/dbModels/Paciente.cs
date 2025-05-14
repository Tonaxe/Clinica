namespace Clinica.Models.dbModels
{
    public class Paciente
    {
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;
        public DateTime fecha_nacimiento { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }
        public string? tipo_pago { get; set; }
        public int? responsable_id { get; set; }
        public string? Imagen { get; set; }

        public virtual Responsable? Responsable { get; set; }
        public virtual ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }
}