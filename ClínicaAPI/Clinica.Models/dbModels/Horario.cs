namespace Clinica.Models.dbModels
{
    public class Horario
    {
        public int Id { get; set; }
        public int? OdontologoId { get; set; }
        public string Dia { get; set; } = null!;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual Odontologo? Odontologo { get; set; }
    }
}
