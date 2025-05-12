using Microsoft.VisualBasic;

namespace DavxeShop.Models
{
    public class Pacientes
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string tipo_pago { get; set; }
        public int? responsable_id { get; set; }
        public string imagen { get; set; }
    }
}