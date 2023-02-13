using Prueba_Josue_Minaya.Models;
using System.Collections.Generic;

namespace Prueba_Josue_Minaya.DB.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public Orden orden { get; set; }
        public List<OrdenDetalle> ordenDetalle { get; set; }
    }
}
