namespace Clinica.Models.dbModels
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string? Imagen { get; set; }

        public virtual Administrativo? Administrativo { get; set; }
        public virtual Odontologo? Odontologo { get; set; }
    }
}
