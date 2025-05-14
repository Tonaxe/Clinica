namespace Clinica.Models.dbModels
{
    public class Horario
    {
        public int id { get; set; }
        public int? odontologo_id { get; set; }
        public string dia { get; set; } = null!;
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }

        public virtual Odontologo? Odontologo { get; set; }
    }
}
