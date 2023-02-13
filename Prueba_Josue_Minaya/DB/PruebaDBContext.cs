using Microsoft.EntityFrameworkCore;
using Prueba_Josue_Minaya.DB.Models;
using Prueba_Josue_Minaya.Models;

namespace Prueba_Josue_Minaya.DB
{
    public class PruebaDBContext : DbContext
    {
        public PruebaDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Asesor> Asesors { get; set; }
        public DbSet<Orden> Ordens { get; set; }
        public DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public DbSet<Venta> Ventas { get; set; }


    }
}
