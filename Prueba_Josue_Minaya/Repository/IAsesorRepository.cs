using Prueba_Josue_Minaya.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Repository
{
    public interface IAsesorRepository
    {
        Task<Asesor> GetById(int id);
        Task<IEnumerable<Asesor>> Get();
        Task CreateAndSave(Asesor asesor);
        Task UpdateAndSave(Asesor asesor);
        Task DeleteAndSave(int id);


    }
}
