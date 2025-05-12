namespace Clinica.Models
{
    public class EditarPaciente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string tipo_pago { get; set; }
        public string responsable_nombre { get; set; }
        public string responsable_apellido { get; set; }
        public string responsable_email { get; set; }
        public string imagen { get; set; }
    }
}
