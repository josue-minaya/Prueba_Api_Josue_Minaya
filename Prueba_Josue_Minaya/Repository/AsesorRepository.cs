using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Josue_Minaya.DB;
using Prueba_Josue_Minaya.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Repository
{
    public class AsesorRepository : IAsesorRepository
    {
        private readonly PruebaDBContext _context;
        public AsesorRepository(PruebaDBContext context)
        {
            _context = context;
        }

        public async Task CreateAndSave(Asesor asesor)
        {
            await _context.Asesors.AddAsync(asesor);
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteAndSave(int id)
        {
            var asesor = await _context.Asesors.SingleOrDefaultAsync(e => e.IdAsesor == id);
             _context.Remove(asesor);
            await _context.SaveChangesAsync();
         }

        public async Task<IEnumerable<Asesor>> Get()
        {
            return await _context.Asesors.ToListAsync();
        }

        public async Task<Asesor> GetById(int id)
        {
            return await _context.Asesors.SingleOrDefaultAsync(e => e.IdAsesor == id);
        }

        public async Task UpdateAndSave(Asesor asesor)
        {
            
                _context.Asesors.Update(asesor);
                await _context.SaveChangesAsync();
          
        }
    }
}
