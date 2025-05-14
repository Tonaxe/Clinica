namespace Clinica.Models.dbModels
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;
        public string email { get; set; } = null!;
        public string contrasena { get; set; } = null!;
        public string rol { get; set; } = null!;
        public string? Imagen { get; set; }

        public virtual Administrativo? Administrativo { get; set; }
        public virtual Odontologo? Odontologo { get; set; }
    }
}
