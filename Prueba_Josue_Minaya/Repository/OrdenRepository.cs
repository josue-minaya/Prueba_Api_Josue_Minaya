using Microsoft.EntityFrameworkCore;
using Prueba_Josue_Minaya.DB;
using Prueba_Josue_Minaya.DB.Models;
using Prueba_Josue_Minaya.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly PruebaDBContext _context;
        public OrdenRepository(PruebaDBContext context)  
        {
            _context = context;
        }
        public async Task CreateAndSave(Venta venta)
        {
            var secuenciaVenta = 0;
            var secuenciaOrden = 0;
            var secuenciaOrdenDetalle = 0;

            try
            {
                secuenciaVenta = (from s in _context.Ventas   select s.Id).Max();
                secuenciaVenta++;

            }
            catch (System.Exception)
            {
                secuenciaVenta++ ;
            }
            try
            {
                secuenciaOrden = (from s in _context.Ordens select s.Id).Max();
                secuenciaOrden++;

            }
            catch (System.Exception)
            {
                secuenciaOrden++;
            }
            try
            {
                secuenciaOrdenDetalle = (from s in _context.OrdenDetalles select s.Id).Max();
                secuenciaOrdenDetalle++;

            }
            catch (System.Exception)
            {
                secuenciaOrdenDetalle++;
            }

            venta.Id = secuenciaVenta;
            venta.orden.Id = secuenciaOrden;
            foreach (var item in venta.ordenDetalle)
            {
                item.Id = secuenciaOrdenDetalle;
                secuenciaOrdenDetalle++;
                item.IdOrden =secuenciaOrden;
            }
            
            
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Orden>> GetOrden()
        {
           
            return await _context.Ordens.ToListAsync();
        }

        public async Task<List<OrdenDetalle>> GetById(int id)
        {
            return await _context.OrdenDetalles.Where(e => e.IdOrden == id).ToListAsync();
        }
    }
}
