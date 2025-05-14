namespace Clinica.Models.dbModels
{
    public class Visita
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }
        public int? OdontologoId { get; set; }
        public DateTime FechaHora { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public string? TratamientoPrescrito { get; set; }

        public virtual Paciente? Paciente { get; set; }
        public virtual Odontologo? Odontologo { get; set; }
    }
}
