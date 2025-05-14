namespace Clinica.Models.dbModels
{
    public class Administrativo
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public string? Puesto { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
