namespace Clinica.Models
{
    public class RegisterRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
        public string Imagen { get; set; }
    }
}
