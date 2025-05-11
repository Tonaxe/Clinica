using Microsoft.VisualBasic;

namespace DavxeShop.Models
{
    public class Pacientes
    {
        public int id { get; set; }  // ID del paciente

        public string nombre { get; set; }

        public string apellido { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public string telefono { get; set; }  // Usamos string por seguridad

        public string email { get; set; }

        public string tipo_pago { get; set; }  // Ej: "PARTICULAR", "MUTUA"

        public int? responsable_id { get; set; }  // Puede ser null si no tiene

    }
}
/*
[id]
      ,[nombre]
      ,[apellido]
      ,[fecha_nacimiento]
      ,[telefono]
      ,[email]
      ,[tipo_pago]
      ,[responsable_id]
*/