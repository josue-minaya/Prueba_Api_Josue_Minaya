using Prueba_Josue_Minaya.DB.Models;
using Prueba_Josue_Minaya.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Repository
{
    public interface IOrdenRepository
    {
        Task<List<OrdenDetalle>> GetById(int id);
        Task<IEnumerable<Orden>> GetOrden();
        Task CreateAndSave(Venta venta);

    }
}
