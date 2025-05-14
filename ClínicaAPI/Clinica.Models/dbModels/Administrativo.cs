namespace Clinica.Models.dbModels
{
    public class Administrativo
    {
        public int id { get; set; }
        public int? usuario_id { get; set; }
        public string? puesto { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
