namespace Clinica.Models.dbModels
{
    public class Visita
    {
        public int id { get; set; }
        public int? paciente_id { get; set; }
        public int? odontologo_id { get; set; }
        public DateTime fecha_hora { get; set; }
        public string? motivo { get; set; }
        public string? observaciones { get; set; }
        public string? tratamiento_prescrito { get; set; }

        public virtual Paciente? Paciente { get; set; }
        public virtual Odontologo? Odontologo { get; set; }
    }
}
