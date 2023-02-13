using System.ComponentModel.DataAnnotations;

namespace Prueba_Josue_Minaya.Models
{
    public class Asesor
    {
        [Key]
        public int IdAsesor { get; set; }
        public string Nombre { get; set; }

    }
}
