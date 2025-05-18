
namespace Clinica.Models
{
    public class VisitaRequest
    {
        public string paciente { get; set; }
        public string odontologo { get; set; }
        public DateTime fechaYhora { get; set; }
        public string motivo { get; set; }
        public string observaciones { get; set; }
    }
}
