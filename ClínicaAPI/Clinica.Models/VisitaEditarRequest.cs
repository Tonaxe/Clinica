namespace Clinica.Models
{
    public class VisitaEditarRequest
    {
        public string paciente { get; set; } = null!;
        public string odontologo { get; set; } = null!;
        public DateTime fechaYhora { get; set; }
        public string motivo { get; set; } = null!;
        public string observaciones { get; set; } = null!;
        public string? tratamiento_prescrito { get; set; }
    }
}
